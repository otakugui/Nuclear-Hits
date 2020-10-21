using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthAmount;
    private EnemyMovement EnmScript;

    private void Start()
    {
        EnmScript = GetComponent<EnemyMovement>();
    }

    public void TakeDamage(float Damage)
    {
        HealthAmount -= Damage;

        if(HealthAmount <= 0)
        {
            EnmScript.Defeated();
        }
    }
}
