using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMovement : MonoBehaviour
{
    [SerializeField] float ForcePower;
    private Rigidbody2D MyRigidBody;
    
    private Transform Enemy;


    private float angle;
    private Quaternion novaRotacao;

    public bool NewEnemy = false;
    public bool NewRotation = false;


    // Start is called before the first frame update

    void Awake()
    {
        MyRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (NewEnemy)
        {
            CallANewOponent(Enemy);
            ChangeRotation(Enemy);
            NewEnemy = false;
        }
        if (NewRotation)
        {
            ChangeRotation(Enemy);
            NewRotation = false;
        }
    }

    public void CallANewOponent(Transform enemy)
    {
        if(MyRigidBody == null)
        {

            MyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
        Enemy = enemy;
        Vector2 MyForce = (Enemy.position - transform.position).normalized;
        print(MyForce);
        MyRigidBody.velocity = new Vector2((MyForce * ForcePower).x, (MyForce * ForcePower).y);
    }

    public void ChangeRotation(Transform enemy)
    {
        Enemy = enemy;
        Vector2 MyForce = (Enemy.position - transform.position).normalized;

        angle = Mathf.Atan2(-MyForce.y, -MyForce.x) * Mathf.Rad2Deg;

        novaRotacao = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, 100);
    }



}
