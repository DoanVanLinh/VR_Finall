using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusManager : MonoBehaviour
{
    public GameObject[] dsBus;
    private int rdIndex = -1;
    private Vector3 vtDichChuyenDiem1 = new Vector3(13, 0, -5);
    private Vector3 vtDichChuyenDiem2 = new Vector3(0, 0, -10);
    private int indexDangTraKhach;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        quanLy();
    }

    private void quanLy()
    {
        if (isAllStop())
        {
            rdIndex = UnityEngine.Random.Range(0, dsBus.Length);
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDo.transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemVeBaiDo[dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemVeBaiDo.Length - 1].transform.position;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDo.transform.position + vtDichChuyenDiem1;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[1].transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position + vtDichChuyenDiem2;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDo.transform.position * 2 - dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu.y = dsBus[rdIndex].GetComponent<HanhTrinhBus>().transform.position.y;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu1 = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position * 2 - dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[1].transform.position;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu1.y = dsBus[rdIndex].GetComponent<HanhTrinhBus>().transform.position.y;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().trangThai = 1;
        }
        else if (checkXeTraKhach())
        {
            if (!checkForRandomBus())
            {
                do
                {
                    rdIndex = UnityEngine.Random.Range(0, dsBus.Length);
                } while (rdIndex == indexDangTraKhach);

            }

            dsBus[indexDangTraKhach].GetComponent<HanhTrinhBus>().diemDo.transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemVeBaiDo[dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemVeBaiDo.Length - 1].transform.position;
            dsBus[indexDangTraKhach].GetComponent<HanhTrinhBus>().diemVeBaiDo[dsBus[indexDangTraKhach].GetComponent<HanhTrinhBus>().diemVeBaiDo.Length - 1].transform.position = dsBus[indexDangTraKhach].GetComponent<HanhTrinhBus>().diemDo.transform.position;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDo.transform.position + vtDichChuyenDiem1;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[1].transform.position = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position + vtDichChuyenDiem2;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDo.transform.position * 2 - dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu.y = dsBus[rdIndex].GetComponent<HanhTrinhBus>().transform.position.y;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu1 = dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[0].transform.position * 2 - dsBus[rdIndex].GetComponent<HanhTrinhBus>().diemDung[1].transform.position;
            dsBus[rdIndex].GetComponent<HanhTrinhBus>().vtPhu1.y = dsBus[rdIndex].GetComponent<HanhTrinhBus>().transform.position.y;

            dsBus[rdIndex].GetComponent<HanhTrinhBus>().trangThai = 1;
        }

    }

    private bool isAllStop()
    {
        foreach (GameObject t in dsBus)
        {
            if (t.GetComponent<HanhTrinhBus>().trangThai == 1 || t.GetComponent<HanhTrinhBus>().trangThai == 4 || t.GetComponent<HanhTrinhBus>().trangThai == 2)
                return false;
        }
        return true;
    }

    private bool checkXeTraKhach()
    {
        int i = 0;
        foreach (GameObject t in dsBus)
        {
            if (t.GetComponent<HanhTrinhBus>().trangThai == 2 && Mathf.Abs(Vector3.Distance(t.GetComponent<HanhTrinhBus>().diemVeBaiDo[0].transform.position, t.GetComponent<HanhTrinhBus>().transform.position)) < 1)
            {
                indexDangTraKhach = i;
                return true;
            }
            i++;
        }
        return false;
    }

    private bool checkForRandomBus()
    {
        int dem = 0;
        foreach (GameObject t in dsBus)
        {
            if (t.GetComponent<HanhTrinhBus>().trangThai == 2 && Mathf.Abs(Vector3.Distance(t.GetComponent<HanhTrinhBus>().diemVeBaiDo[0].transform.position, t.GetComponent<HanhTrinhBus>().transform.position)) < 1)
            {
                dem++;
            }
            if (t.GetComponent<HanhTrinhBus>().trangThai == 1 || t.GetComponent<HanhTrinhBus>().trangThai == 4)
                dem++;
            if (dem == 2)
            {
                return true;
            }
        }
        return false;
    }
}
