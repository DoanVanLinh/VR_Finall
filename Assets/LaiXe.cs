using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaiXe : MonoBehaviour
{
    public float speed;
    public float smooth;
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DiChuyen();
    }

    private void DiChuyen()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, Time.deltaTime * smooth, Space.World);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -Time.deltaTime * smooth, Space.World);
    }
}
