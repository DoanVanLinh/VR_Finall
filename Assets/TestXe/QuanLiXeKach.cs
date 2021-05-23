using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiXeKach : MonoBehaviour
{
    public Transform xes;

    public XeKhach[] xeKhach;
    private int indexXeHienTai;
    private int length;
    private void Awake()
    {
        SetTag();
        length = xes.childCount;
        xeKhach = new XeKhach[length];
        for (int i = 0; i < length; i++)
        {
            xeKhach[i] = xes.GetChild(i).GetComponent<XeKhach>();
            xeKhach[i].GetComponent<XeKhach>().hanhTrinhParent = transform.GetChild(i);
        }
    }
    private void Update()
    {
        QuanLi();
    }

    private void QuanLi()
    {
        bool checkDiChuyen = false;
        for (int i = 0; i < length; i++)
        {
            if (xeKhach[i].DiChuyen1)
            {
                checkDiChuyen = true;
                indexXeHienTai = i;
                break;
            }
        }
        if (!checkDiChuyen)
            RandomXe();

    }

    private void RandomXe()
    {
        int indexTiep = UnityEngine.Random.Range(0, length);
        if (indexTiep != indexXeHienTai)
        {
            indexXeHienTai = indexTiep;
            xeKhach[indexXeHienTai].DiChuyen1 = true;
        }
        
    }
    private void SetTag()
    {
        foreach (Transform child in transform)
        {
            child.tag = "HanhTrinh";
        }
    }
}
