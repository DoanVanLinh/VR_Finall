using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongHo : MonoBehaviour
{
    private GameObject kimGio;
    private GameObject kimPhut;

    private float anglePerHour;
    void Start()
    {
        kimGio = transform.GetChild(0).gameObject;
        kimPhut = transform.GetChild(1).gameObject;
        anglePerHour = 360 / 12f;
        SetGio();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetGio()
    {
        kimGio.transform.Rotate(0, 0, System.DateTime.Now.Hour * anglePerHour,Space.Self);
        kimPhut.transform.Rotate(0, 0, System.DateTime.Now.Minute/5f * anglePerHour, Space.Self);
    }
}
