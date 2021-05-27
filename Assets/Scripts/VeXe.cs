using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeXe : MonoBehaviour
{
    private GameObject tayTrai;
    private GameObject tayPhai;

    private InteractionObject veXe;
    private bool isTake;
    private Camera cam;
    void Start()
    {
        isTake = false;
        cam = Camera.main;
        veXe = GetComponent<InteractionObject>();
    }

    // Update is called once per frame
    void Update()
    {
        FindAim();
        LayVe();
    }
    private void FindAim()
    {
        if(tayTrai==null)   
            tayTrai = QuanLiGhe.tayTrai;
        if(tayPhai==null)
            tayPhai = QuanLiGhe.tayPhai;
        if (cam == null)
            cam = QuanLiGhe.cam;
    }
    private void LateUpdate()
    {
        if (isTake)
        {
            veXe.transform.position = tayPhai.transform.position;
            transform.LookAt(cam.transform.position);
        }
    }
    private void LayVe()
    {
        if (veXe.IsPushing)
        {
            isTake = true;
            //veXe.transform.localRotation = new Quaternion(-90, 0, 0, 0);
            veXe.enabled = false;
            veXe.IsPushing = false;
        }
    }
}
