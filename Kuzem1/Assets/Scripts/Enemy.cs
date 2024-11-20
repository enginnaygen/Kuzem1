using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public int minStartHealth = 5;
    public int maxStartHealth = 15;

    int currentHealth;

    public TextMeshPro healthTMP;
    [SerializeField] SpriteRenderer spriteRenderer;

    public GameObject coinPrefab;
    public GameObject powerUpPrefab;

    bool didSpawnCoin;

  

    void Start()
    {
        currentHealth = Random.Range(minStartHealth, maxStartHealth);
        healthTMP.text = currentHealth.ToString();
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    public void GetHit(int damage)
    {
        currentHealth -= damage;
        healthTMP.text = currentHealth.ToString();

        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(1.3f, .2f).SetLoops(2, LoopType.Yoyo);

        spriteRenderer.DOKill();
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor(Color.white, .1f).SetLoops(2, LoopType.Yoyo);

        if (currentHealth <= 0 && !didSpawnCoin)
        {
            if(Random.value >.5)
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

            didSpawnCoin = true;
            gameObject.SetActive(false);



            //Destroy(gameObject);
        }   
    }
}
