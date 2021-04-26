using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QingWaMove1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform left, right;
    public float Speed;
    private float leftX, rightX;

    private bool isRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftX = left.position.x;
        rightX = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    void Update()
    {
        if (isRight)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightX)
            {
                isRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftX)
            {
                isRight = true;
            }
        }
    }

}
