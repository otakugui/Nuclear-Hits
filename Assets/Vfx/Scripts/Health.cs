using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float HealthAmount;


    public void TakeDamage(float Damage)
    {
        HealthAmount -= Damage;

        if(HealthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
