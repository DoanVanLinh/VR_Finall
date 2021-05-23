using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = Random.Range(100, 200);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    void Rotation()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
