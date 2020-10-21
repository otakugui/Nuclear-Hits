using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator Anim;

    private SpriteRenderer MySpriteRenderer;

    private SpawInimigo CurrentSpawn;
    private float Speed;

    private bool Walk = true;
    private int MyNumberInList;

    private Health hltScript;
    private float HealthTotal;

    [SerializeField] CutTree CtTree;
    private void Awake()
    {
        hltScript = GetComponent<Health>();
        if(hltScript != null)
        {
            HealthTotal = hltScript.HealthAmount;
        }
        Anim = GetComponent<Animator>();
        MySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Walk)
        {
            gameObject.transform.position = new Vector2((transform.position.x + (Time.time * Speed)), transform.position.y);
        }
    }

    public void Born(SpawInimigo myCurrentSpawn, int MyNewLayer, float NewSpeed)
    {
        
        MySpriteRenderer.sortingOrder = MyNewLayer;
        CurrentSpawn = myCurrentSpawn;
        Speed = NewSpeed;
        Walk = true;
        Anim.SetBool("Live", true);

        if (hltScript != null)
        {
            hltScript.HealthAmount = HealthTotal;
        }
    }

    public void MyNumber(int MNbr)
    {
        MyNumberInList = MNbr;
    }

    public void Defeated()
    {
        Walk = false;
        Anim.SetBool("Live", false);

        Anim.SetBool("Attack", false);
    }
    public void DefeatedTime()
    {
        CurrentSpawn.EnemyDisponivel(MyNumberInList);
        gameObject.SetActive(false);
    }

    public void Attack(bool OnOrOff)
    {
        if (OnOrOff)
        {
            Walk = false;
        }
        else
        {
            Walk = true;
        }
        Anim.SetBool("Attack", OnOrOff);
    }

    public void GiveDamage()
    {
        CtTree.GiveDamage();
    }

}
