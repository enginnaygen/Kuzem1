using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public int minStartHealth = 5;
    public int maxStartHealth = 15;

    int currentHealth;
    int startHealth;
    public enum EnemyType
    {
        Basic,
        Fast,
        Shooting,
        Boss,
    }

    public EnemyType enemyType;

    private Coroutine _shootCoroutine;

    public Bullet bulletPrefab;
    public float attackRate;
    public float bulletSpeed;

    public TextMeshPro healthTMP;
    [SerializeField] SpriteRenderer spriteRenderer;

    public GameObject coinPrefab;
    public GameObject powerUpPrefab;
    Player player;

    bool didSpawnCoin;
    bool isEnemyDestroyed;

    Color beforeColor;
    public void StartEnemy(Player player)
    {
        beforeColor = spriteRenderer.color;
        this.player = player;
        maxStartHealth += Random.Range(0, 10);
        startHealth += Random.Range(5,10) * player.shootDirections.Count;
        currentHealth = startHealth;
        healthTMP.text = currentHealth.ToString();

    }

    void Update()
    {
        if (enemyType == EnemyType.Shooting)
        {
            if (transform.position.y > 3)
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
            if (_shootCoroutine == null)
            {
                _shootCoroutine = StartCoroutine(ShootCoroutine());
            }
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }

    IEnumerator ShootCoroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            var dir = (player.transform.position - transform.position).normalized;
            Shoot(dir);
        }
    }
    void Shoot(Vector3 dir)
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(bulletSpeed, dir, player.gameDirector);
    }

    public void GetHit(int damage)
    {
        currentHealth -= damage;
        healthTMP.text = currentHealth.ToString();

        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(1.3f, .2f).SetLoops(2, LoopType.Yoyo);

        spriteRenderer.DOKill();
        spriteRenderer.DOColor(Color.white, .1f).SetLoops(2, LoopType.Yoyo);

        if(!isEnemyDestroyed)
        {
            if (currentHealth <= 0)
            {
                KillEnemy();



                //Destroy(gameObject);
            }

        }
       spriteRenderer.color = beforeColor;


    }

    private void KillEnemy()
    {
        if(!isEnemyDestroyed)
        {
            if (enemyType != EnemyType.Boss)
            {
                if (Random.value > .5)
                {
                    GameObject newCoin = Instantiate(coinPrefab);
                    newCoin.transform.position = transform.position + Vector3.up;
                    newCoin.GetComponent<Coin>().StartCoin();

                }
                else
                {
                    GameObject newPowerUp = Instantiate(powerUpPrefab);
                    newPowerUp.transform.position = transform.position + Vector3.up;
                    newPowerUp.GetComponent<PowerUp>().StartPowerUp();
                }
            }
            else
            {
                player.gameDirector.LevelComplated(); // burada leveli arttiriyor

            }

            isEnemyDestroyed = true;

            player.gameDirector.audioManager.EnemyDestroyAs();
        }
        


        //didSpawnCoin = true;
        gameObject.SetActive(false);
        
    }
}
