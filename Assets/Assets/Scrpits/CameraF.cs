using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public Transform player;

    public Camera camera;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
        camera = this.GetComponent<Camera>();
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
