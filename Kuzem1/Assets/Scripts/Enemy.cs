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
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = Random.Range(minStartHealth, maxStartHealth);
        healthTMP.text = currentHealth.ToString();
    }

    // Update is called once per frame
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

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
