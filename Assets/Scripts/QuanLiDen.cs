using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiDen : MonoBehaviour
{
    public GameObject[] dens;//danh sach cac den can bat/tat

    private InteractionObject CongTac;
    public Material[] materials;//chat lieu cua bong den (bat/tat)
    private bool isOn;

    void Start()
    {
        CongTac = GetComponent<InteractionObject>();

        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();
    }
    void OnOff()
    {
        if (CongTac.IsPushing)//khi an cong tac
        {
            isOn = !isOn;//dang bat thanh tat, dang tat thanh bat
            CongTac.IsPushing = false;
        }
        foreach (GameObject item in dens)//duyet qua danh sach cac den
        {
            if(isOn)//neu dang muon bat
                item.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(materials[0]);//thuc hien bat
            else
                item.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(materials[1]);
        }
    }
}
