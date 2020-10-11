using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour
{
    private float currentTime;
    
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 1)
        {
            currentTime = 0;
            gameObject.SetActive(false);
        }
    }
}
