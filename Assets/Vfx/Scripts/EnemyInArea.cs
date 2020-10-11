using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyInArea : MonoBehaviour
{
    private List<GameObject> ObjectsInTown = new List<GameObject>();
    [SerializeField] string EnemyTag;
    [SerializeField] float YToAddInVector;

    private Transform TempObj;

    [SerializeField] Transform FlechaBorn;
    private float DefinitiveY;

    private Animator MyAnim;


    [SerializeField] GameObject FlechaPrefab;
    private List<ListOfFlechas> Flechas = new List<ListOfFlechas>();

    private float NearPosition;


    private float CurrentTime = 0;
    private bool IsShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        MyAnim = gameObject.GetComponent<Animator>();
        DefinitiveY = (transform.position.y + YToAddInVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectsInTown.Count != 0)
        {
            MyAnim.SetBool("AnimationOfShoot", true);
        }
        else
        {
            MyAnim.SetBool("AnimationOfShoot", false);
        }

        if (IsShooting)
        {
            CurrentTime += Time.deltaTime;
            if(CurrentTime >= .3f)
            {
                IsShooting = false;
                CurrentTime = 0;
            }
        }
    }

    public void ShootAtEnemy()
    {
        NearPosition = -100;
        foreach (GameObject gobj in ObjectsInTown)
        {
            if(gobj.transform.position.x > NearPosition)
            {
                TempObj = gobj.transform;
                NearPosition = gobj.transform.position.x;
            }
        }
        if (!IsShooting)
        {
            NovaFlecha();
            IsShooting = true;
            CurrentTime = 0;
        }
    }

    private void NovaFlecha()
    {

        bool AcheiUmaFlecha = false;
        if(Flechas.Count != 0)
        {
            foreach (ListOfFlechas Ins in Flechas)
            {
                if (!Ins.InUse && !AcheiUmaFlecha)
                {
                    AcheiUmaFlecha = true;
                    Ins.Flecha.transform.position = FlechaBorn.position;
                    Ins.Flecha.SetActive(true);
                    Ins.Flecha.GetComponent<FlechaMovement>().ChangeRotation(TempObj);
                }
            }
        }


        

        if (!AcheiUmaFlecha)
        {

            ListOfFlechas TmpListOfFlechas = new ListOfFlechas();
            TmpListOfFlechas.Flecha = Instantiate(FlechaPrefab as GameObject);
            TmpListOfFlechas.InUse = true;


            Flechas.Add(TmpListOfFlechas);


            TmpListOfFlechas.Flecha.transform.position = FlechaBorn.position;
            TmpListOfFlechas.Flecha.SetActive(true);


            TmpListOfFlechas.Flecha.GetComponent<FlechaMovement>().ChangeRotation(TempObj);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == EnemyTag)
        {
            ObjectsInTown.Remove(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == EnemyTag)
        {
            ObjectsInTown.Add(collision.gameObject);
        }
    }
    
}


[System.Serializable]
public class ListOfFlechas
{
    public GameObject Flecha;
    public bool InUse;
}