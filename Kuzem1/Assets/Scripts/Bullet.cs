using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    

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
        //Destroy(this.gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;  
    }
}
