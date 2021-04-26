using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    private Animator animator;

    //玩家移动
    private Vector2 lookDirection = new Vector2();//判断玩家的方向
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX,moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
        }


        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.Space))
        {
            position.x += moveX * speed * 2 * Time.deltaTime;
            position.y += moveY * speed * 2 * Time.deltaTime;

        }
        else
        {
            position.x += moveX * speed * Time.deltaTime;
            position.y += moveY * speed * Time.deltaTime;         
        }
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            collision.gameObject.SetActive(false);
        }
    }



}
