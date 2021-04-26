using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float atkCD = 0;
    public GameObject firex2;
    public GameObject fireup2;
    public GameObject firedown2;

    public GameObject firex;
    public GameObject fireup;
    public GameObject firedown;

    public AudioClip atcAudio;
    public GameObject bulletLs;
    public GameObject qgL1;
    public GameObject qgL2;

    public GameObject bulletRs;
    public GameObject qgR1;
    public GameObject qgR2;

    public GameObject bulletDs;
    public GameObject qgD1;
    public GameObject qgD2;

    public GameObject bulletUs;
    public GameObject qgU1;
    public GameObject qgU2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        atk();
    }
    void atk()
    {
        if (firedown2.activeInHierarchy == true || fireup2.activeInHierarchy == true || firex2.activeInHierarchy == true)
        {
            if (Input.GetKey(KeyCode.J))
            {
                AudioSource.PlayClipAtPoint(atcAudio, transform.position);
                firex.SetActive(true);
                atkCD -= Time.deltaTime;
                if (atkCD <= 0)
                {
                    if (this.transform.localScale.x == 1)
                    {
                        atkCD = 0.4f;
                        Vector3 qgl2 = qgL2.transform.position;
                        Vector3 qgl1 = qgL1.transform.position;
                        Vector3 dir = qgl2 - qgl1;
                        dir = dir.normalized;
                        GameObject bullet = Instantiate(bulletLs);
                        bullet.transform.position = qgL1.transform.position;
                        bullet.GetComponent<Rigidbody2D>().AddForce(dir * 1200f);
                    }
                }
                if (atkCD <= 0)
                {
                    if (this.transform.localScale.x == -1)
                    {
                        atkCD = 0.4f;
                        Vector3 qgr2 = qgR2.transform.position;
                        Vector3 qgr1 = qgR1.transform.position;
                        Vector3 dir = qgr2 - qgr1;
                        dir = dir.normalized;
                        GameObject bullet = Instantiate(bulletRs);
                        bullet.transform.position = qgR1.transform.position;
                        bullet.GetComponent<Rigidbody2D>().AddForce(dir * 1200f);
                    }
                }

            }
            else
            {
                firex.SetActive(false);
            }
            if (Input.GetKey(KeyCode.J))
            {
                fireup.SetActive(true);
                atkCD -= Time.deltaTime;
                if (atkCD <= 0 && transform.localScale.x == 0.99f)
                {
                    atkCD = 0.4f;
                    Vector3 qgu2 = qgU2.transform.position;
                    Vector3 qgu1 = qgU1.transform.position;
                    Vector3 dir = qgu2 - qgu1;
                    dir = dir.normalized;
                    GameObject bullet = Instantiate(bulletUs);
                    bullet.transform.position = qgU1.transform.position;
                    bullet.GetComponent<Rigidbody2D>().AddForce(dir * 1200f);

                }
            }
            else
            {
                fireup.SetActive(false);
            }
            if (Input.GetKey(KeyCode.J))
            {
                firedown.SetActive(true);
                atkCD -= Time.deltaTime;
                if (atkCD <= 0)
                {
                    if (this.transform.localScale.x == -0.99f)
                    {
                        atkCD = 0.4f;
                        Vector3 qgd2 = qgD2.transform.position;
                        Vector3 qgd1 = qgD1.transform.position;
                        Vector3 dir = qgd2 - qgd1;
                        dir = dir.normalized;
                        GameObject bullet = Instantiate(bulletDs);
                        bullet.transform.position = qgD1.transform.position;
                        bullet.GetComponent<Rigidbody2D>().AddForce(dir * 1200f);
                    }

                }
            }
            else
            {
                firedown.SetActive(false);
            }
        }
        
    }
}
