using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ColocarEspirito : MonoBehaviour
{
    public void Spawn(GameObject Torre1)
    {
       Instantiate(Torre1, transform.position, Quaternion.identity);
    }


        
}

