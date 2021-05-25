using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongMoCuaXuongBus : MonoBehaviour
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
        if (khoaCua.IsPushing)
        {
            trangThaiCua = !trangThaiCua;
            kichHoat = true;
            khoaCua.IsPushing = false;
        }
        if (trangThaiCua && kichHoat)
        {
            bus.transform.GetChild(7).Rotate(0, -90, 0, Space.Self);
            bus.transform.GetChild(8).Rotate(0, 90, 0, Space.Self);
            kichHoat = false;
        }
        else if (!trangThaiCua && kichHoat)
        {
            bus.transform.GetChild(7).Rotate(0, 90, 0, Space.Self);
            bus.transform.GetChild(8).Rotate(0, -90, 0, Space.Self);
            kichHoat = false;
        }
    }
}
