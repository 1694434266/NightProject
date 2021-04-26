using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QWCon : MonoBehaviour
{
    public GameObject qgl;
    public GameObject qgr;
    public GameObject qgu;
    public GameObject qgd;

    public GameObject enemyBL;
    public GameObject enemyBR;
    public GameObject enemyBU;
    public GameObject enemyBD;

    public GameObject enemy2;

    private float atkCD = 0;
    public int hp = 50;
    private int hpTotal;

    public Slider hpSlider;
    void Start()
    {
        hpTotal = hp;
    }

    
    void Update()
    {
        atk();
    }
    void atk()
    {
        atkCD -= Time.deltaTime;
        if(atkCD <= 0)
        {
            atkCD = 0.7f;
            GameObject bulletl = Instantiate(enemyBL);
            bulletl.transform.position = qgl.transform.position;
            bulletl.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300f);
            GameObject bulletr = Instantiate(enemyBR);
            bulletr.transform.position = qgr.transform.position;
            bulletr.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300f);
            GameObject bulletu = Instantiate(enemyBU);
            bulletu.transform.position = qgu.transform.position;
            bulletu.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            GameObject bulletd = Instantiate(enemyBD);
            bulletd.transform.position = qgd.transform.position;
            bulletd.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 300f);
        }
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
            StartCoroutine(die());
        }
    }
    IEnumerator changeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator die()
    {
        enemy2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
