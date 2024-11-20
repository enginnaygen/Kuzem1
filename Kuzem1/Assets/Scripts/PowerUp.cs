using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float speed = 4f;
    public void StartPowerUp()
    {

    }

    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }



}
