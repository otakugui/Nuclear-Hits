﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int Vida;
    public bool destruction = false;
    private float currentTime =0;

    private Animator MyAnim;

    // Start is called before the first frame update
    void Awake()
    {
        MyAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destruction)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= .2f)
            {
                MyAnim.SetBool("Died", true);
            }
        }
    }


    private void OnTriggerEnter2D()
    {
        destruction = true;

    }

    public void TomarDano()
    {
        Vida--;
        if (Vida <= 0)
        {
            MyAnim.SetBool("Died", true);
        }
    }

}
