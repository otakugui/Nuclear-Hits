using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ColocarEspirito : MonoBehaviour
{
    public GameObject Torre1;
    void OnMouseUp()
    {
              Instantiate(Torre1, transform.position, Quaternion.identity);
    }

    void Spawn()
    {
        Instantiate(Torre1, transform.position, Quaternion.identity);
    }
}

