using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanhTrinh :MonoBehaviour
{
    [SerializeField]
    private int[] diemLui;

    [SerializeField]
    private Diem[] diemDoi;
    public int[] DiemLui { get => diemLui; set => diemLui = value; }
    public Diem[] DiemDoi { get => diemDoi; set => diemDoi = value; }

    private void Start()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
[System.Serializable]
public class Diem
{
    public int index;
    public float delay;
}
