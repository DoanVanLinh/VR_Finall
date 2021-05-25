using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaiXeBus : MonoBehaviour
{
    public GameObject xeBus;
    public GameObject nguoiLai;
    private InteractionObject nutKhoiDong;
    private bool trangThaiLai;
    private Vector3 vtBanDau;
    // Start is called before the first frame update
    void Start()
    {
        trangThaiLai = false;
        nutKhoiDong = GetComponent<InteractionObject>();
        vtBanDau = nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        khoiDongXe();
    }

    private void khoiDongXe()
    {
        if (nutKhoiDong.IsPushing)
        {
            trangThaiLai = !trangThaiLai;
            nutKhoiDong.IsPushing = false;
        }
        if (trangThaiLai)
        {
            nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).transform.position = xeBus.transform.GetChild(xeBus.transform.childCount - 1).transform.position;
            Debug.Log(xeBus.transform.GetChild(xeBus.transform.childCount - 1).transform.position);
            LaiXe();
        }
        else
        {
            //nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.position.y = vtBanDau.y;
        }
    }

    private void LaiXe()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            xeBus.transform.position += transform.forward * Time.deltaTime * 15f;
            nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).transform.position += transform.forward * Time.deltaTime * 15f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            xeBus.transform.position -= transform.forward * Time.deltaTime * 15f;
            nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).transform.position -= transform.forward * Time.deltaTime * 15f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xeBus.transform.Rotate(Vector3.up, Time.deltaTime * 15f, Space.World);
            nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).Rotate(Vector3.up, Time.deltaTime * 15f, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xeBus.transform.Rotate(Vector3.up, -Time.deltaTime * 15f, Space.World);
            nguoiLai.transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).Rotate(Vector3.up, -Time.deltaTime * 15f, Space.World);
        }
    }
}
