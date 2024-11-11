using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material;
    [SerializeField] float offsetSpeed = .01f;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += Vector2.up * offsetSpeed * Time.deltaTime;
    }
}
