using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBDestory : MonoBehaviour
{
    float cd = 2f;
    void Start()
    {
        Destroy(this.gameObject, cd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
