using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int Vida;
    public bool destruction = false;
    private float currentTime =0;

    private Animator MyAnim;

    // Start is called before the first frame update
    void Start()
    {
        MyAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destruction)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= 1.5f)
            {
                    MyAnim.SetBool("Died", true);
            }
        }
    }


 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="EnemyLenhador")
        {

            destruction = true;

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

}
