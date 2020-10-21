using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    private GameObject MyHitEffect;
    [SerializeField] GameObject HitPrefab;
    [SerializeField] float damage;
    private FlechaMovement ScriptOfFlecha;
    public UnityEvent MyEventsWhenHit;

    private void Start()
    {
        ScriptOfFlecha = gameObject.GetComponent<FlechaMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyLenhador")
        {
            MyEventsWhenHit.Invoke();
            if(MyHitEffect == null)
            {
                MyHitEffect = Instantiate(HitPrefab as GameObject);
            }
            MyHitEffect.SetActive(true);
            MyHitEffect.transform.position = gameObject.transform.position;

            collision.GetComponent<Health>().TakeDamage(damage);
            ScriptOfFlecha.FlechaDisable();
        }

    }
}
