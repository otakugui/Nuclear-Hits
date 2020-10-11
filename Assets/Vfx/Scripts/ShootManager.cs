using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] EnemyInArea ScriptOfArea;


    // Update is called once per frame
    void Update()
    {
            ScriptOfArea.ShootAtEnemy();
            gameObject.SetActive(false);

    }
}
