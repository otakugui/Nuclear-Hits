using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Vida;
    public int Dano;
    public Rigidbody2D rig;
    public float velocidade;
    public float tempoNaDirecao;

    float tempo;

    void Start()
    {
    }

    public void TomarDano(int dano)
    {
        Vida -= dano;
        if (Vida <= 0)
        {
            Morrer();
        }
    }
    public void Morrer()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (velocidade > 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

        }

    }
}
