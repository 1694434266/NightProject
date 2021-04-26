using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sshader : MonoBehaviour
{
    public GameObject player;
    public float le = 64f;
    public float vi = 32f;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite=this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetx = -(player.transform.position.x) / (le*2);
        float offsety = -(player.transform.position.y) / (vi*2);
        sprite.material.SetTextureOffset("_Mask",new Vector2(offsetx,offsety));    
    }
}
