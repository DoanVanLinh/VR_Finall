using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiDen : MonoBehaviour
{
    public GameObject[] dens;

    private InteractionObject CongTac;
    public Material[] materials;
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
        if (CongTac.IsPushing)
        {
            isOn = !isOn;
            CongTac.IsPushing = false;
        }
        foreach (GameObject item in dens)
        {
            if(isOn)
                item.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(materials[0]);
            else
                item.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(materials[1]);
        }
    }
}
