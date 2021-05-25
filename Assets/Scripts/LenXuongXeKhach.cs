using System.Collections;
using UnityEngine;

public class LenXuongXeKhach : MonoBehaviour
{
    public HanhTrinhBus[] dsBus;
    private Animator animator;
    private int rdViTriNgoi;
    public int viTriKhach; //1: Cho xe 2: Dang tren xe 3: Di chuyen trong san sau khi di bus 4: Dung tai sanh cho 5: di den diem cho bus
    public GameObject[] dsDiemXuong;
    public GameObject[] dsDenDiemCho;
    public GameObject[] dsDiemLenBus;

    private int i = 0;
    private int j = 0;
    private int k = 0;
    private float tocDoDiBo;
    private float tgDoiXuongXe;
    private float tgDoiSanh = 10;
    private int viTriXeDangDi;
    private Vector3 rdViTriDoiXe;
    private Vector3 rdViTriDungSanh;
    private bool trangThaiRdViTri;
    void Start()
    {
        animator = GetComponent<Animator>();
        tgDoiSanh = UnityEngine.Random.Range(0f, 15f);
        trangThaiRdViTri = false;
        tocDoDiBo = (float)1.5;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (viTriKhach == 1)
        {
            for (int i = 0; i < dsBus.Length; i++)
            {
                if (dsBus[i].trangThai == 4)
                {
                    viTriXeDangDi = i;
                }
            }
        }
        StartCoroutine(lenXuongXe());
    }

    private IEnumerator lenXuongXe()
    {
        //Len bus
        if (viTriKhach == 1 && Mathf.Abs(Vector3.Distance(dsBus[viTriXeDangDi].transform.position, dsBus[viTriXeDangDi].diemDung[3].transform.position)) < 1)
        {
            if (k < dsDiemLenBus.Length)
            {
                animator.SetInteger("State", 1);
                transform.LookAt(dsDiemLenBus[k].transform);
                transform.position = Vector3.MoveTowards(transform.position, dsDiemLenBus[k].transform.position, Time.deltaTime * tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsDiemLenBus[k].transform.position)) < 0.2)
                {
                    k++;
                }
            }
            else if (k == dsDiemLenBus.Length)
            {
                if (!trangThaiRdViTri)
                {
                    rdViTriDoiXe = new Vector3(UnityEngine.Random.Range(-2.22f, 0), 0, UnityEngine.Random.Range(-3f, 3f));
                    rdViTriDungSanh = new Vector3(UnityEngine.Random.Range(-3.07f, 0), 0, UnityEngine.Random.Range(-3f, 3f));
                    trangThaiRdViTri = true;
                }
                animator.SetInteger("State", 1);
                transform.LookAt(dsBus[viTriXeDangDi].transform.GetChild(9).transform);
                transform.position = Vector3.MoveTowards(transform.position, dsBus[viTriXeDangDi].transform.GetChild(9).transform.position, Time.deltaTime * tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsBus[viTriXeDangDi].transform.GetChild(9).transform.position)) < 0.2)
                {
                    if (viTriKhach == 1)
                    {
                        do
                        {
                            rdViTriNgoi = UnityEngine.Random.Range(0, dsBus[viTriXeDangDi].transform.GetChild(11).transform.childCount - 1);
                            tgDoiXuongXe = UnityEngine.Random.Range(0.1f, 6f);
                            tgDoiSanh = UnityEngine.Random.Range(1f, 10f);
                        } while (dsBus[viTriXeDangDi].dsGhe[rdViTriNgoi]);
                        dsBus[viTriXeDangDi].dsGhe[rdViTriNgoi] = true;
                    }
                    animator.SetInteger("State", 2);
                    transform.rotation = dsBus[viTriXeDangDi].transform.GetChild(11).transform.GetChild(rdViTriNgoi).transform.rotation;
                    transform.position = dsBus[viTriXeDangDi].transform.GetChild(11).transform.GetChild(rdViTriNgoi).transform.position;
                    if (rdViTriNgoi < 5)
                    {
                        transform.Rotate(0, -90, 0, Space.Self);
                    }
                    else if (rdViTriNgoi > 19)
                    {
                        transform.Rotate(0, 90, 0, Space.Self);
                    }
                    viTriKhach = 2;
                    j = 0;
                }
            }
        }
        //Lo bus
        if (viTriKhach == 1 && dsBus[viTriXeDangDi].trangThai == 1 && Mathf.Abs(Vector3.Distance(transform.position, dsBus[viTriXeDangDi].transform.GetChild(9).transform.position)) >= 0.2 && dsBus[viTriXeDangDi].soHanhTrinh == 4)
        {
            animator.SetInteger("State", 1);
            transform.LookAt(dsDenDiemCho[dsDenDiemCho.Length - 1].transform.position + rdViTriDoiXe);
            transform.position = Vector3.MoveTowards(transform.position, dsDenDiemCho[dsDenDiemCho.Length - 1].transform.position + rdViTriDoiXe, Time.deltaTime * tocDoDiBo);
            transform.Rotate(0, -120, 0, Space.Self);
            animator.SetInteger("State", -1);
        }
        // Dang ngoi tren xe di
        if (viTriKhach == 2 && dsBus[viTriXeDangDi].trangThai == 1)
        {
            transform.rotation = dsBus[viTriXeDangDi].transform.GetChild(11).transform.GetChild(rdViTriNgoi).transform.rotation;
            if (rdViTriNgoi < 5)
            {
                transform.Rotate(0, -90, 0, Space.Self);
            }
            else if (rdViTriNgoi > 19)
            {
                transform.Rotate(0, 90, 0, Space.Self);
            }
            transform.position = dsBus[viTriXeDangDi].transform.GetChild(11).transform.GetChild(rdViTriNgoi).transform.position;
        }
        //Xuong xe bus
        if (viTriKhach == 2 && dsBus[viTriXeDangDi].trangThai == 2)
        {
            animator.SetInteger("State", 3);
            if (rdViTriNgoi > 9 && rdViTriNgoi < 14)
            {
                transform.position = dsBus[viTriXeDangDi].transform.GetChild(11).transform.GetChild(rdViTriNgoi).transform.position + new Vector3(0, 0, 5);
            }
            dsBus[viTriXeDangDi].dsGhe[rdViTriNgoi] = false;
            yield return new WaitForSeconds(tgDoiXuongXe);
            transform.position = dsBus[viTriXeDangDi].transform.GetChild(10).transform.position;
            viTriKhach = 3;
        }
        //Di chuyen ve sanh cho
        if (viTriKhach == 3)
        {
            animator.SetInteger("State", 1);
            if (i < dsDiemXuong.Length - 1)
            {
                transform.LookAt(dsDiemXuong[i].transform);
                transform.position = Vector3.MoveTowards(transform.position, dsDiemXuong[i].transform.position, Time.deltaTime * tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsDiemXuong[i].transform.position)) < 0.2)
                {
                    i++;
                }
            }
            if (i == dsDiemXuong.Length - 1)
            {
                transform.LookAt(dsDiemXuong[i].transform.position + rdViTriDungSanh);
                transform.position = Vector3.MoveTowards(transform.position, dsDiemXuong[i].transform.position + rdViTriDungSanh, Time.deltaTime * tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsDiemXuong[i].transform.position + rdViTriDungSanh)) < 0.2)
                {
                    i++;
                }
            }
            if (i == dsDiemXuong.Length)
            {
                animator.SetInteger("State", -1);
                viTriKhach = 4;
                i = 0;
                k = 0;
                trangThaiRdViTri = true;
            }
        }
        //Doi o sanh
        if (viTriKhach == 4)
        {
            yield return new WaitForSeconds(tgDoiSanh);
            viTriKhach = 5;
        }
        if (viTriKhach == 5)
        {
            animator.SetInteger("State", 1);
            if (j < dsDenDiemCho.Length - 1)
            {
                transform.LookAt(dsDenDiemCho[j].transform);
                transform.position = Vector3.MoveTowards(transform.position, dsDenDiemCho[j].transform.position, Time.deltaTime*tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsDenDiemCho[j].transform.position)) < 0.2)
                {
                    j++;
                }
            }
            if (j == dsDenDiemCho.Length - 1)
            {
                transform.LookAt(dsDenDiemCho[j].transform.position + rdViTriDoiXe);
                transform.position = Vector3.MoveTowards(transform.position, dsDenDiemCho[j].transform.position + rdViTriDoiXe, Time.deltaTime * tocDoDiBo);
                if (Mathf.Abs(Vector3.Distance(transform.position, dsDenDiemCho[j].transform.position + rdViTriDoiXe)) < 0.2)
                {
                    j++;
                }
            }
            if (j == dsDenDiemCho.Length)
            {
                animator.SetInteger("State", -1);
                viTriKhach = 1;
            }
        }
    }
}

