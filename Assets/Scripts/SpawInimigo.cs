using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawInimigo : MonoBehaviour
{
    public GameObject lenhador_01;
    double contadorTempo = 0;
    public float tempoPraGerar = 1;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= tempoPraGerar)
        {
            Instantiate(lenhador_01, this.transform.position, this.transform.rotation);
            contadorTempo = 0;
        }

    }
}
