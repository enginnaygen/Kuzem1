using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 100;
    public float playerXBorder;
    public float playerYBorder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
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
}
