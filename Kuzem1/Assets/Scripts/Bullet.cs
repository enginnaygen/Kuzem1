using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
    public void StartBullet(float bulletSpeed)
    {
        speed = bulletSpeed;
    }
    /*public Bullet(float bulletSpeed)
    {
        speed = bulletSpeed;
    }*/
    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;  
    }
}
