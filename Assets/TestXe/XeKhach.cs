using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class XeKhach : MonoBehaviour
{

    public float speed;
    public int diemHienTai;
    public Transform hanhTrinhParent;

    private int soHanhTrinh;
    private float y;
    private bool diTien;
    private Transform[] hanhTrinh;
    private Rigidbody rig;
    private int[] diemLui;
    private Diem[] diemDoi;
    public List<GameObject> banhXe;
    private bool diChuyen;
    private bool doiKhach;

    public bool DiChuyen1 { get => diChuyen; set => diChuyen = value; }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        GetHanhTrinh(hanhTrinhParent);
        soHanhTrinh = hanhTrinh.Length;
        y = transform.position.y;
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

    }
    private void FixedUpdate()
    {
        StartCoroutine(DoiKhach());
    }
    IEnumerator DoiKhach()
    {
        int diem = -1;
        for (int i = 0; i < diemDoi.Length; i++)
        {
            if (diemHienTai - 1 == diemDoi[i].index)
            {
                doiKhach = true;
                diem = i;
                break;
            }
        }
        if (doiKhach)
        {
            yield return new WaitForSecondsRealtime(diemDoi[diem].delay);
            doiKhach = false;
        }
        TrangThai();
        if (diChuyen)
            DiChuyen();
    }

    void DiChuyen()
    {
        
        if (diemHienTai < soHanhTrinh)
        {
            diTien = true;
            foreach (int child in diemLui)
            {
                if (diemHienTai == child)
                {
                    diTien = false;
                    break;
                }
            }
            if (diTien)
                DiTien();
            else
                DiLui();
        }
        if (diemHienTai == soHanhTrinh)
        {
            diChuyen = false;
            diemHienTai = 0;
        }
        BanhXe();
    }
    void DiTien()
    {
        Quaternion targetRotation = Quaternion.LookRotation(hanhTrinh[diemHienTai].transform.position+Vector3.up*y - transform.position);
        Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime*speed/2f);
        transform.position = Vector3.MoveTowards(transform.position, hanhTrinh[diemHienTai].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, hanhTrinh[diemHienTai].position) <= 01f)
        {
            diemHienTai++;
        }
    }
    void DiLui()
    {
        Quaternion targetRotation = Quaternion.LookRotation(hanhTrinh[diemHienTai-1].transform.position + Vector3.up * y - transform.position);
        Quaternion targetRotation2 = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation2, Time.deltaTime * speed / 2f);
        //transform.LookAt(new Vector3(hanhTrinh[diemHienTai - 1].position.x,y, hanhTrinh[diemHienTai - 1].position.z));
        transform.position = Vector3.MoveTowards(transform.position, hanhTrinh[diemHienTai].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, hanhTrinh[diemHienTai].position) <= 01f)
        {
            diemHienTai++;
        }
    }
    void GetHanhTrinh(Transform hanhTrinhParent)
    {
        int length = hanhTrinhParent.childCount;
        diemLui = hanhTrinhParent.GetComponent<HanhTrinh>().DiemLui;
        diemDoi = hanhTrinhParent.GetComponent<HanhTrinh>().DiemDoi;

        hanhTrinh = new Transform[length];
        for (int i = 0; i < length; i++)
        {
            hanhTrinh[i] = hanhTrinhParent.GetChild(i);
        }
    }
    void TrangThai()
    {
        if (diChuyen)
        {
            rig.constraints = ~RigidbodyConstraints.FreezeAll;
            rig.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
            rig.constraints = RigidbodyConstraints.FreezeAll;

    }
    void BanhXe()
    {
        foreach (GameObject item in banhXe)
        {
            item.transform.Rotate(0,0,Time.deltaTime*200f);
        }
    }
}
