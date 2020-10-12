using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int Vida;

    private Animator MyAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="EnemyLenhador")
        {
            //perde vida
            TomarDano();

        }
    }

    public void TomarDano()
    {
        Vida--;
        if (Vida <= 0)
        {
            MyAnim.SetBool("Died", true);
        }
    }


    //caso o dano nao funcione, destroi direto
    //private void OnTriggerEnter2D(Collider2D collision)
    //{if (collision.CompareTag("Inimigo"))
}
