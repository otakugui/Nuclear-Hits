using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.parent.position - transform.position )* 1* Time.deltaTime;
    }
}
