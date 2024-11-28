using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public ParticleSystem bulletCollectesPS;
    public ParticleSystem coinCollectesPS;

    [SerializeField] Transform particleParent;


    public void PlayCoinCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(coinCollectesPS);
        newPS.transform.position = pos;
        newPS.Play();
        
    }

    public void PlayBulletdFX(Vector3 pos)
    {
        var newPS = Instantiate(bulletCollectesPS, particleParent);
        newPS.transform.position = pos;
        newPS.Play();

    }

    /*public void PlayFX(Vector3 pos, ParticleSystem PS)
    {
        var newPS = Instantiate(PS);
        newPS.transform.position = pos;
        newPS.Play();

    }*/
}
