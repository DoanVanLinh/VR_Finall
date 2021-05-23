using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanhTrinhBus : MonoBehaviour
{
    public GameObject[] diemDung;
    public int soHanhTrinh;
    public int soHanhTrinhDo;
    public int speed;
    public int tocDoBanhXe;
    public int trangThai;// 0: chay ve, 1: chay di, 2 tra khach, 3: dung, 4: don khach,
    public Vector3 vtPhu;
    public Vector3 vtPhu1;
    public Vector3 vtPhu2;
    private GameObject[] banhXe;
    public GameObject[] diemVeBaiDo;
    public GameObject diemDo;
    private bool trangThaiCua; //true: mo, false:dong
    private bool tamDung;
    public bool[] dsGhe;



    // Start is called before the first frame update
    void Start()
    {
        banhXe = new GameObject[6];

        soHanhTrinh = 0;
        soHanhTrinhDo = 0;
        trangThaiCua = false;
        tamDung = false;

        for (int i = 0; i < 6; i++)
        {
            banhXe[i] = transform.GetChild(i).gameObject;
        }
        vtPhu2 = 2 * diemVeBaiDo[0].transform.position - diemVeBaiDo[1].transform.position;
        vtPhu2.y = transform.position.y;
        speed = 15;
        dsGhe = new bool[transform.GetChild(11).childCount];
        for (int i = 0; i < dsGhe.Length; i++)
        {
            dsGhe[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(diChuyen());
    }
    private IEnumerator diChuyen()
    {
        if (soHanhTrinh < diemDung.Length &&( trangThai == 1 ||trangThai==4))
        {
            if (soHanhTrinh == 0)
            {
                transform.LookAt(vtPhu);
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);

                }
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
            else if (soHanhTrinh == 1)
            {
                this.transform.LookAt(vtPhu1);
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);

                }
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
            else if (soHanhTrinh == 2)
            {
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, -item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);

                }
                this.transform.LookAt(diemDung[soHanhTrinh].transform);
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
            else if (soHanhTrinh == 4)
            {
                trangThai = 4;
                tamDung = true;
                if (!trangThaiCua)
                {
                    this.transform.GetChild(6).Rotate(0, 150, 0, Space.Self);
                    this.transform.GetChild(7).Rotate(0, -90, 0, Space.Self);
                    this.transform.GetChild(8).Rotate(0, 90, 0, Space.Self);
                    trangThaiCua = true;
                }
                yield return new WaitForSeconds(15);
                if (trangThaiCua)
                {
                    this.transform.GetChild(6).Rotate(0, -150, 0, Space.Self);
                    this.transform.GetChild(7).Rotate(0, 90, 0, Space.Self);
                    this.transform.GetChild(8).Rotate(0, -90, 0, Space.Self);
                    trangThaiCua = false;
                }
                if (tamDung)
                {
                    trangThai = 1;
                    foreach (var item in banhXe)
                    {
                        item.transform.RotateAround(item.transform.position, -item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);
                    }
                    this.transform.LookAt(diemDung[soHanhTrinh].transform);
                    transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                    if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                    {
                        soHanhTrinh += 1;
                    }
                    tamDung = false;
                }
            }
            else
            {
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, -item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);

                }
                transform.LookAt(diemDung[soHanhTrinh].transform);
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
        }
        if (soHanhTrinh == diemDung.Length)
        {
            trangThai = 2;
            diemVeBaiDo[diemVeBaiDo.Length - 1].transform.position = diemDo.transform.position;
            StartCoroutine(diChuyenDoXe());
        }
    }

    public IEnumerator diChuyenDoXe()
    {
        if (!trangThaiCua)
        {
            this.transform.GetChild(6).Rotate(0, 150, 0, Space.Self);
            this.transform.GetChild(7).Rotate(0, -90, 0, Space.Self);
            this.transform.GetChild(8).Rotate(0, 90, 0, Space.Self);
            trangThaiCua = true;
        }
        yield return new WaitForSeconds(15);
        if (trangThaiCua)
        {
            this.transform.GetChild(6).Rotate(0, -150, 0, Space.Self);
            this.transform.GetChild(7).Rotate(0, 90, 0, Space.Self);
            this.transform.GetChild(8).Rotate(0, -90, 0, Space.Self);
            trangThaiCua = false;
        }
        if (trangThai == 2 && soHanhTrinhDo < diemVeBaiDo.Length)
        {
            if (soHanhTrinhDo <= 1)
            {
                transform.LookAt(vtPhu2);
                transform.position = Vector3.MoveTowards(transform.position, diemVeBaiDo[soHanhTrinhDo].transform.position, Time.deltaTime * speed);
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);
                }
                if (Mathf.Abs(Vector3.Distance(diemVeBaiDo[soHanhTrinhDo].transform.position, transform.position)) < 1)
                {
                    soHanhTrinhDo += 1;
                }
            }
            else
            {
                transform.LookAt(diemVeBaiDo[soHanhTrinhDo].transform);
                transform.position = Vector3.MoveTowards(transform.position, diemVeBaiDo[soHanhTrinhDo].transform.position, Time.deltaTime * speed);
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, -item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);
                }
                if (Mathf.Abs(Vector3.Distance(diemVeBaiDo[soHanhTrinhDo].transform.position, transform.position)) < 1)
                {
                    soHanhTrinhDo += 1;
                }
            }
        }
        if (soHanhTrinhDo == diemVeBaiDo.Length)
        {
            soHanhTrinh = 0;
            soHanhTrinhDo = 0;
            trangThai = 3;
        }
    }
}
