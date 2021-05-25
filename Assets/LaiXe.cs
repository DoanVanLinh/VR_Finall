using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaiXe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DiChuyen();
    }

    private void DiChuyen()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * Time.deltaTime * 10f;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= transform.forward * Time.deltaTime * 10f;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, Time.deltaTime * 10f, Space.World);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -Time.deltaTime * 10f, Space.World);
    }
}
