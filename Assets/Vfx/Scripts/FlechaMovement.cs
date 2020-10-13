using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMovement : MonoBehaviour
{
    [SerializeField] float ForcePower;
    private Rigidbody2D MyRigidBody;
    
    private Transform Enemy;
    private int MyNumberInList = 0;

    private float angle, currentTime;
    private Quaternion novaRotacao;

    public bool NewEnemy = false;
    public bool NewRotation = false;

    private EnemyInArea EnemyinAreaScript;

    private bool Alive = true;

    // Start is called before the first frame update

    void Awake()
    {
        MyRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 3.5f)
        {
            FlechaDisable();
        }

        if (NewEnemy)
        {
            CallANewOponent(Enemy, MyNumberInList, EnemyinAreaScript);
            ChangeRotation(Enemy, MyNumberInList, EnemyinAreaScript);
            NewEnemy = false;
        }
        if (NewRotation)
        {
            ChangeRotation(Enemy, MyNumberInList, EnemyinAreaScript);
            NewRotation = false;
        }
    }

    public void CallANewOponent(Transform enemy, int myNumber, EnemyInArea script)
    {
        EnemyinAreaScript = script;
        MyNumberInList = myNumber;
        if (MyRigidBody == null)
        {

            MyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
        Enemy = enemy;
        Vector2 MyForce = (Enemy.position - transform.position).normalized;

        MyRigidBody.velocity = new Vector2((MyForce * ForcePower).x, (MyForce * ForcePower).y);
    }

    public void ChangeRotation(Transform enemy, int myNumber, EnemyInArea script)
    {
        EnemyinAreaScript = script;
        MyNumberInList = myNumber;
        Enemy = enemy;
        Vector2 MyForce = (Enemy.position - transform.position).normalized;

        angle = Mathf.Atan2(-MyForce.y, -MyForce.x) * Mathf.Rad2Deg;

        novaRotacao = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, 100);
    }


    public void FlechaDisable()
    {
        currentTime = 0;
        Alive = false;
        EnemyinAreaScript.FlechaEnable(MyNumberInList);
        gameObject.SetActive(false);
    }
}
