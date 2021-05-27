using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLiGhe : MonoBehaviour
{
    private InteractionObject iObj;
    private bool isSit;

    public static GameObject player;
    public static GameObject tayTrai;
    public static GameObject tayPhai;
    public static Camera cam;

    public bool IsSit { get => isSit; set => isSit = value; }

    void Start()
    {
        isSit = false;
        iObj = GetComponent<InteractionObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Ngoi();
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            player.transform.parent = null;
            isSit = false;
            iObj.IsPushing = false;
            iObj.IsTouching = false;
        }



    }
    private void LateUpdate()
    {
        if (isSit)
            player.transform.position = transform.position+Vector3.up*-0.5f;
    }
    void Ngoi()
    {
        if (iObj.IsPushing)
        { 
            player.transform.parent = transform;
            player.transform.position = transform.position;
            //player.transform.rotation = transform.rotation;
            player.transform.GetChild(0).transform.rotation = transform.rotation;
            isSit = true;
            iObj.IsPushing = false;
        }
    }
    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tayTrai = GameObject.FindGameObjectWithTag("TayTrai");
        tayPhai = GameObject.FindGameObjectWithTag("TayPhai");
        cam = Camera.main;
    }
}
