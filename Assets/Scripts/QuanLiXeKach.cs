using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiXeKach : MonoBehaviour
{
    public Transform xes;
    public float timeRepeat;

    [HideInInspector]
    public List<XeKhach> xeKhach;
    [HideInInspector]
    public List<XeKhach> xeKhachCho;
    private int indexXeHienTai;
    private int length;
    private float timer;
    private void Awake()
    {
        timer = 0;
        indexXeHienTai = 0;
        SetTag();
        length = xes.childCount;
        for (int i = 0; i < length; i++)
        {
            xeKhach.Add(xes.GetChild(i).GetComponent<XeKhach>());
            xeKhach[i].GetComponent<XeKhach>().hanhTrinhParent = transform.GetChild(i);
        }
        //InvokeRepeating("RandomXe", 0f, timeRepeat);
    }
    private void Update()
    {
        QuanLi();
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Time.timeScale = 2;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Time.timeScale = 1;
    }
    private void QuanLi()
    {
        //bool checkDiChuyen = false;
        //for (int i = 0; i < length; i++)
        //{
        //    if (xeKhach[i].DiChuyen1)
        //    {
        //        checkDiChuyen = true;
        //        indexXeHienTai = i;
        //        break;
        //    }
        //}
        //if (!checkDiChuyen)
        //    RandomXe();
        timer -= Time.deltaTime;
        if (timer <= 0)
            if(CheckBenXe())
                RandomXe();
        
    }

    private void RandomXe()
    {
        XeKhach x = xeKhachCho[UnityEngine.Random.Range(0, xeKhachCho.Count)];
        indexXeHienTai = xeKhach.IndexOf(x);
        xeKhach[indexXeHienTai].DiChuyen1 = true;
        timer = timeRepeat;
    }
    private void SetTag()
    {
        foreach (Transform child in transform)
        {
            child.tag = "HanhTrinh";
        }
    }
    bool CheckBenXe()
    {
        bool check = false;
        xeKhachCho.Clear();
        foreach (XeKhach item in xeKhach)
        {
            if (!item.DiChuyen1)
            {
                xeKhachCho.Add(item);
                check = true;
            }
        }
        return check;
    }
}
