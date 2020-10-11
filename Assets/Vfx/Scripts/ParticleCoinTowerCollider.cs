using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCoinTowerCollider : MonoBehaviour
{
    CoinsUI MyCoinsUiScript;
    private void Start()
    {
        FindTheScript();


    }

    public void FindTheScript()
    {
        MyCoinsUiScript = GameObject.FindGameObjectWithTag("CoinsManager").GetComponent<CoinsUI>();
    }


    private void OnParticleCollision(GameObject other)
    {
        MyCoinsUiScript.MoreCoins();
    }
}
