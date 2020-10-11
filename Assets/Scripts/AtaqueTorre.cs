using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueTorre : MonoBehaviour
{
    public int Alcance;
    public float Ataque;
    public float TempoAtaque;
    public float Tempo = 0;
    public GameObject Inimigos;
    public GameObject InimigosMarcado;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Tempo * Time.deltaTime);
    }
}
