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
    private float y;


    // Start is called before the first frame update
    void Start()
    {
        banhXe = new GameObject[6];
        y = transform.position.y;
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
        //Xe chay
        if (soHanhTrinh < diemDung.Length && (trangThai == 1 || trangThai == 4))
        {
            //Lui xe
            if (soHanhTrinh == 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(vtPhu + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //transform.LookAt(vtPhu);
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
                Quaternion targetRotation = Quaternion.LookRotation(vtPhu1 + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //this.transform.LookAt(vtPhu1);
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
            else if (soHanhTrinh == 2)//Tien xe
            {
                foreach (var item in banhXe)
                {
                    item.transform.RotateAround(item.transform.position, -item.transform.forward * 10f * Time.deltaTime * tocDoBanhXe, 10f);

                }
                Quaternion targetRotation = Quaternion.LookRotation(diemDung[soHanhTrinh].transform.position + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //this.transform.LookAt(diemDung[soHanhTrinh].transform);
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
            else if (soHanhTrinh == 4)//Dung doi khach
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
                    Quaternion targetRotation = Quaternion.LookRotation(diemDung[soHanhTrinh].transform.position + Vector3.up * y - transform.position);
                    Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                    //this.transform.LookAt(diemDung[soHanhTrinh].transform);
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
                Quaternion targetRotation = Quaternion.LookRotation(diemDung[soHanhTrinh].transform.position + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //transform.LookAt(diemDung[soHanhTrinh].transform);
                transform.position = Vector3.MoveTowards(transform.position, diemDung[soHanhTrinh].transform.position, Time.deltaTime * speed);
                if (Mathf.Abs(Vector3.Distance(diemDung[soHanhTrinh].transform.position, transform.position)) < 1)
                {
                    soHanhTrinh += 1;
                }
            }
        }
        if (soHanhTrinh == diemDung.Length)//Di het hanh trinh don khach
        {
            trangThai = 2;
            diemVeBaiDo[diemVeBaiDo.Length - 1].transform.position = diemDo.transform.position;
            StartCoroutine(diChuyenDoXe());
        }
    }

    public IEnumerator diChuyenDoXe()
    {
        //Tro ve bai do
        if (Mathf.Abs(Vector3.Distance(transform.position, diemDung[diemDung.Length - 1].transform.position)) <= 1)
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
        }
        if (trangThai == 2 && soHanhTrinhDo < diemVeBaiDo.Length)
        {
            if (soHanhTrinhDo <= 1)
            {
                Quaternion targetRotation = Quaternion.LookRotation(vtPhu2 + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //transform.LookAt(vtPhu2);
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
                Quaternion targetRotation = Quaternion.LookRotation(diemVeBaiDo[soHanhTrinhDo].transform.position + Vector3.up * y - transform.position);
                Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 3f);
                //transform.LookAt(diemVeBaiDo[soHanhTrinhDo].transform);
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
        if (soHanhTrinhDo == diemVeBaiDo.Length)//Den bai do
        {
            soHanhTrinh = 0;
            soHanhTrinhDo = 0;
            trangThai = 3;
        }
    }
}
