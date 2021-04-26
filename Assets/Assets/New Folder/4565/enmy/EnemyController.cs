using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    public bool isVertical;
    private Vector2 moveDirection;
    private Rigidbody2D rbody;
    public float changeDirectionTime = 2f;
    private float changeTimer;
    private Animator anim;
    public int hp = 20;
    private int hpTotal;

    public Slider hpSlider;
    public GameObject xc;

    // Start is called before the first frame update
    void Start()
    {
        hpTotal = hp;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame

    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer= changeDirectionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
        anim.SetFloat("MoveX",moveDirection.x);
        anim.SetFloat("MoveY",moveDirection.y);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerB"))
        {
            Destroy(other.gameObject);
            beHit();
        }
    }
    
    void beHit()
    {
        hp -= 1;
        hpSlider.value = (float)hp / hpTotal;
        StartCoroutine(changeColor());
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator changeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
