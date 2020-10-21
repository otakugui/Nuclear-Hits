using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawInimigo : MonoBehaviour
{
    public GameObject lenhador_01;
    public float contadorTempo = 0;
    public float tempoPraGerar = 1;

    // Start is called before the first frame update
    private List<GameObject> EnemyOfThisLane = new List<GameObject>();
    private List<bool> EnemyInUse = new List<bool>();
    private List<EnemyMovement> ListOfEnemiesScripts = new List<EnemyMovement>();
    private SpawInimigo MyOwnScript;

    [SerializeField] int LayerToBorn;

    private void Awake()
    {
        MyOwnScript = GetComponent<SpawInimigo>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= tempoPraGerar)
        {
            contadorTempo = 0;
            NewEnemy(.005f);
            
        }

    }


    public void NewEnemy(float Speed)
    {
        if(EnemyInUse.Count != 0)
        {
            bool achou = false;
            int ct = 0;
            foreach(bool Indisponivel in EnemyInUse)
            {
                if(!achou && !Indisponivel)
                {
                    achou = true;

                    EnemyOfThisLane[ct].transform.position = this.transform.position;
                    EnemyOfThisLane[ct].SetActive(true);
                    ListOfEnemiesScripts[ct].Born(MyOwnScript, LayerToBorn, Speed);
                    EnemyInUse[ct] = true;
                }
                ct++;
            }

            if (!achou)
            {
                BornSomeEnemy(Speed, (EnemyInUse.Count - 1));
            }
        }
        else
        {
            BornSomeEnemy(Speed, 0);
        }
    }


    private void BornSomeEnemy(float Speed, int Position)
    {
        GameObject TmpLenhador = Instantiate(lenhador_01, this.transform.position, this.transform.rotation);
        EnemyMovement EmMv = TmpLenhador.GetComponent<EnemyMovement>();
        EmMv.Born(MyOwnScript, LayerToBorn, Speed);
        EmMv.MyNumber(Position);
        EnemyInUse.Add(true);
        EnemyOfThisLane.Add(TmpLenhador);
        ListOfEnemiesScripts.Add(EmMv);
    }

    public void EnemyDisponivel(int Nbr)
    {
        EnemyInUse[Nbr] = false;
    }
}
