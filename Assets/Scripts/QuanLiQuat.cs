using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiQuat : MonoBehaviour
{
    public Quat []quats;
    private InteractionObject CongTac;
    void Start()
    {
        CongTac = GetComponent<InteractionObject>();
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
            
            foreach (Quat item in quats)
            {
                item.enabled = !item.enabled;
            }
            CongTac.IsPushing = false;
        }
    }
}
