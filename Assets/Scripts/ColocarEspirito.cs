using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarEspirito : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject indio;
    // Start is called before the first frame update
    private bool CanPlaceMonster()
    {
        return indio == null;
    }

    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            //3
            indio = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }

}
