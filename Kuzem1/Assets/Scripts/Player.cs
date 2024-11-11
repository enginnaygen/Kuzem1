using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 100;
    public float playerXBorder;
    public float playerYBorder;

    public Bullet bulletPrefab;
    public Transform bulletParent;
    public float bulletSpeed =5;
    public float waitShoot = .5f;


    private void Start()
    {
        StartCoroutine(ShootCoroutine());
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
            gameObject.SetActive(false);
        }
        if(collision.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
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

        if (Input.GetKey(KeyCode.W))
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
        }

        transform.position += direction.normalized * Time.deltaTime * speed;
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitShoot);

            for (int i = 0; i < 3; i++)
            {
                if(i==0)
                {
                    Shoot(Vector3.up);

                }
                else if(i == 1)
                {
                    Vector3 leftUp = new Vector3(-.5f, 1, 0);
                    Shoot(leftUp);
                }
                else if(i==2)
                {
                    Vector3 rightUp = new Vector3(.5f, 1, 0);
                    Shoot(rightUp);


                }

            }
        }
        
    }
    void Shoot(Vector3 direction)
    {
        Bullet newBullet = Instantiate(bulletPrefab, bulletParent);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(bulletSpeed, direction);
    }
}
