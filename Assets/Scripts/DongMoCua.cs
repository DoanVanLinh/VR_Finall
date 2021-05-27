using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongMoCua : MonoBehaviour
{
    public GameObject cua;
    public float angle;

    private bool trangThaiCua;//true: Mo, false: Dong
    private InteractionObject khoaCua;
    private bool kichHoat;
    // Start is called before the first frame update
    void Start()
    {
        khoaCua = GetComponent<InteractionObject>();
        trangThaiCua = false;
        kichHoat = false;
    }

    // Update is called once per frame
    void Update()
    {
        dongMoCua();
    }
    private void dongMoCua()
    {
        if (khoaCua.IsPushing)
        {
            trangThaiCua = !trangThaiCua;
            kichHoat = true;
            khoaCua.IsPushing = false;
        }
        if (trangThaiCua && kichHoat)
        {
            cua.transform.Rotate(0, angle, 0, Space.World);
            kichHoat = false;
        }
        else if (!trangThaiCua && kichHoat)
        {
            cua.transform.Rotate(0, -angle, 0, Space.World);
            kichHoat = false;
        }
    }
}
