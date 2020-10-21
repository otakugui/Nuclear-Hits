using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    [SerializeField] EnemyMovement MyScriptOfMovement;

    private Arvore arvore;

    [SerializeField] int DmgValue =1;

    private void OnTriggerEnter2D(Collider2D Cld)
    {
        MyScriptOfMovement.Attack(true);
        arvore = Cld.GetComponent<Arvore>();
    }

    private void OnTriggerExit2D()
    {
        MyScriptOfMovement.Attack(false);
    }

    public void GiveDamage()
    {
        if(arvore != null)
        {
            arvore.TomarDano(DmgValue);
        }
    }
}
