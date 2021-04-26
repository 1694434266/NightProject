using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerC : MonoBehaviour
{
    Vector2 movement = new Vector2();
    public Rigidbody2D rb;
    public Collider2D coll;
    public Collider2D disColl;
    public float speed = 5f;
    public Animator ani;
    public GameObject X;
    public GameObject up;
    public GameObject down;
    public int hp = 100;
    private int hpTotal;


    public Slider hpSlider;
    public GameObject a;
    public GameObject enterDialog;

    private bool isHurt;


    void Start()
    {
        enterDialog.SetActive(false);
        hpTotal = hp;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

   
    void Update()
    {
        if (!isHurt)
        {
            move();
            duck();
            atk();
        }
    }

    void move()
    {
        movement.x = Input.GetAxisRaw("Horizontal")*Time.deltaTime;
        movement.y = Input.GetAxisRaw("Vertical")*Time.deltaTime;
        movement.Normalize();
        if (hp > 0)
        {
        
            rb.velocity = movement * speed;
            if (Input.GetKey(KeyCode.A))
            {
                ani.SetBool("移动", true);
                transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                ani.SetBool("移动", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                ani.SetBool("移动", true);
                transform.localScale = new Vector3(-1, 1, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                ani.SetBool("上", true);
                transform.localScale = new Vector3(0.99f, 1, 0);
            }
            else
            {
                ani.SetBool("上", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                ani.SetBool("下", true);
                transform.localScale = new Vector3(-0.99f, 1, 0);
            }
            else
            {
                ani.SetBool("下", false);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                ani.SetBool("移动", false);
                ani.SetBool("上", false);
                ani.SetBool("下", false);
                rb.velocity = movement * 0;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                ani.SetBool("移动", false);
                ani.SetBool("上", false);
                ani.SetBool("下", false);
                rb.velocity = movement * 0;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                ani.SetBool("移动", false);
                ani.SetBool("上", false);
                ani.SetBool("下", false);
                rb.velocity = movement * 0;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                ani.SetBool("移动", false);
                ani.SetBool("上", false);
                ani.SetBool("下", false);
                rb.velocity = movement * 0;
            }
        }
        
        
    }
    void duck()
    {
        if (hp > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ani.SetBool("蹲下", true);
                disColl.enabled = false;
                up.SetActive(false);
                down.SetActive(false);
                X.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ani.SetBool("蹲下", false);
                disColl.enabled = true;
            }
        } 
    }
    void atk()
    {
        if (hp > 0)
        {
            if (ani.GetBool("蹲下") == false)
            {
              
                if (this.transform.localScale.x == 1 || this.transform.localScale.x == -1)
                {
                    up.SetActive(false);
                    down.SetActive(false);
                    X.SetActive(true);
                }
                if (this.transform.localScale.x == 0.99f)
                {
                    X.SetActive(false);
                    down.SetActive(false);
                    up.SetActive(true);
                }
                if (this.transform.localScale.x == -0.99f)
                {
                    X.SetActive(false);
                    up.SetActive(false);
                    down.SetActive(true);
                }
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemyB"))
        {
            Destroy(other.gameObject);
            beHit();
        }
    }
    void beHit()
    {
        hp -= 2;
        hpSlider.value = (float)hp / hpTotal;
        StartCoroutine(changeColor());
        if (hp <= 0)
        {
            rb.velocity = movement * 0;
            X.SetActive(false);
            up.SetActive(false);
            down.SetActive(false);
            StartCoroutine(die());
        }
    }
    IEnumerator changeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator die()
    {
        a.SetActive(false);
        ani.SetBool("死亡", true);
        enterDialog.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        this.gameObject.SetActive(false);
        //Time.timeScale = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-6, rb.velocity.y);
                isHurt = true;
                StartCoroutine(changeColor());
                bePeng();
                StartCoroutine(延迟());
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(6, rb.velocity.y);
                isHurt = true;
                StartCoroutine(changeColor());
                bePeng();
                StartCoroutine(延迟());
            }
            if (transform.position.y > collision.gameObject.transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, 6);
                isHurt = true;
                StartCoroutine(changeColor());
                bePeng();
                StartCoroutine(延迟());
            }
            else if (transform.position.y < collision.gameObject.transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -6);
                isHurt = true;
                StartCoroutine(changeColor());
                bePeng();
                StartCoroutine(延迟());
            }
        }
    }

    IEnumerator 延迟()
    {
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }

    void bePeng()
    {
        hp -= 5;
        hpSlider.value = (float)hp / hpTotal;
        StartCoroutine(changeColor());
        if (hp <= 0)
        {
            rb.velocity = movement * 0;
            X.SetActive(false);
            up.SetActive(false);
            down.SetActive(false);
            StartCoroutine(die());
        }
    }
}
