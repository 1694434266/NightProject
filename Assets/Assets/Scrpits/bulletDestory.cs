using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestory : MonoBehaviour
{
    float cd = 1f;
    void Start()
    {
        Destroy(this.gameObject, cd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
