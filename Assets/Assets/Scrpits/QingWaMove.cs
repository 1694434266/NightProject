using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingWaMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform top, bottom;
    public float Speed;
    private float TopY, BottomY;

    private bool isUp = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TopY = top.position.y;
        BottomY = bottom.position.y;
        Destroy(top.gameObject);
        Destroy(bottom.gameObject);
    }

    void Update()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, Speed);
            if (transform.position.y > TopY)
            {
                isUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -Speed);
            if (transform.position.y < BottomY)
            {
                isUp = true;
            }
        }
    }

}
