using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    Vector3 direction;

    void Update()
    {
        MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<Enemy>().GetHit(damage);
        }

        if(collision.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
    }
    public void StartBullet(float bulletSpeed, Vector3 direction)
    {
        speed = bulletSpeed;
        this.direction = direction;
    }
 
  
    private void MoveBullet()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
