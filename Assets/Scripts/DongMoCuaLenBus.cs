using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongMoCuaLenBus : MonoBehaviour
{
    private bool trangThaiCua;//true: Mo, false: Dong
    public GameObject bus;
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
        if (khoaCua.IsPushing)//Khi an vao khoa cua
        {
            trangThaiCua = !trangThaiCua;//Neu dang dong thi thanh mo, dang mo thi thanh dong
            kichHoat = true;//khi an nut
            khoaCua.IsPushing = false;
        }
        if (trangThaiCua && kichHoat)//Khi can mo cua va da an nut khoa cua
        {
            bus.transform.GetChild(6).Rotate(0, 120, 0, Space.Self);//thuc hien xoay canh cua quanh truc voi goc 120
            kichHoat = false;
        }
        else if (!trangThaiCua && kichHoat)//khi can dong cua va da an nut khoa cua
        {
            bus.transform.GetChild(6).Rotate(0, -120, 0, Space.Self);//thuc hien xuat canh cua quanh truc voi goc -120
            kichHoat = false;
        }
    }
}
