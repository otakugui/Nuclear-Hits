using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Vida;
    public int Dano;
    public  Arvore Arvore; 
    
    void Start()
    {
        Arvore = GetComponent<Arvore>();
    }
   

    // Update is called once per frame
    void Update()
    {
       
    }

    void Atacar()
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




}
