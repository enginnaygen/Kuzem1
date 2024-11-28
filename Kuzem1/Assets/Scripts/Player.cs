using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletParent;
    public GameDirector gameDirector;
    //public ParticleSystem coinParticle;

    public float speed = 100;
    public float playerXBorder;
    public float playerYBorder;
    public int startHealth;
    int currentHealth;
   
    public float bulletSpeed =5;
    public float waitShoot = .5f;

    public List<Vector3> shootDirections;

    public SpriteRenderer healthBarFill;

    Vector3 mousePivotPosition;

    Coroutine shootCoroutine;


    public void ReStartPlayer()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0f, -2.8f, 0);
        currentHealth = startHealth;
        UpdateHealthBarFill(1);

        if(shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }
        shootCoroutine = StartCoroutine(ShootCoroutine());

        shootDirections.Clear();
        shootDirections.Add(Vector3.up);
    }

    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            currentHealth -= 1;

            UpdateHealthBarFill((float)currentHealth / startHealth);

            if(currentHealth <= 0)
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        if(collision.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("Coin"))
        {
            gameDirector.coinManager.IncreaseCoinCount(1);
            //gameDirector.fxManager.PlayFX(collision.transform.position, coinParticle);
            gameDirector.fxManager.PlayCoinCollectedFX(collision.transform.position);
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("PowerUp"))
        {
            shootDirections.Add(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized);
            collision.gameObject.SetActive(false);
        }

    }

    void UpdateHealthBarFill(float ratio)
    {
        healthBarFill.transform.localScale = new Vector3(ratio, transform.localScale.y, transform.localScale.z);
        //healthBarFill.transform.DOScale(ratio, .5f);
        healthBarFill.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
        if(ratio < .5f)
        {
            healthBarFill.color = Color.red;
        }
        else
        {
            healthBarFill.color = Color.green;
        }

    }

    private void ClampPlayerPosition()
    {
        Vector3 pos = transform.position;
        if (pos.x > playerXBorder)
        {

            pos.x = playerXBorder;
        }
        else if (pos.x < -playerXBorder)
        {

            pos.x = -playerXBorder;
        }
        if (pos.y > playerYBorder)
        {

            pos.y = playerYBorder;
        }
        else if (pos.y < -playerYBorder)
        {

            pos.y = -playerYBorder;
        }

        transform.position = pos;
    }

    private void MovePlayer()
    {
        Vector3 direction = Vector3.zero;

        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if(Input.GetMouseButtonDown(0))
        {
            //mousePivotPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePivotPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePivotPosition;
            direction = Input.mousePosition - mousePivotPosition;
        }
        /*if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }*/

        transform.position += direction.normalized * Time.deltaTime * speed;
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitShoot);

            for (int i = 0;i < shootDirections.Count; i++)
            {
                Shoot(shootDirections[i]);

            }
        }
        
    }
    void Shoot(Vector3 direction)
    {
        Bullet newBullet = Instantiate(bulletPrefab, bulletParent);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(bulletSpeed, direction, gameDirector);
    }
}
