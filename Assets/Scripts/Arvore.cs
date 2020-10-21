using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int Vida;
    public bool destruction = false;
    //private float currentTime =0;
    public string DiedAnimationName = "Died";
    public int DiedAnimationHash;
    private Animator MyAnim;

    // Start is called before the first frame update
    void Awake()
    {
        MyAnim = gameObject.GetComponent<Animator>();
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print(collision.tag);
    //    //destruction = true;
    //    if(collision.tag == "Cutter")
    //    {
    //        TomarDano();
    //    }
    //}

    public void TomarDano(int Dmg)
    {
        Vida -= Dmg;
        if (Vida <= 0)
        {
            MyAnim.SetBool(DiedAnimationHash, true);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        DiedAnimationHash = Animator.StringToHash(DiedAnimationName);
    }
#endif

}
