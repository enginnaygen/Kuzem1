using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem bulletParticle;
    public float speed;
    public int damage = 1;

    Vector3 direction;
    GameDirector gameDirector;

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
            //gameDirector.fxManager.PlayFX(transform.position,bulletParticle);
            gameDirector.fxManager.PlayBulletdFX(transform.position);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
    public void StartBullet(float bulletSpeed, Vector3 direction, GameDirector gameDirector)
    {
        speed = bulletSpeed;
        this.direction = direction;
        this.gameDirector = gameDirector;
    }
 
  
    private void MoveBullet()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
