using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public Color hightLightColor;


    private bool isPushing;
    private bool isTouching;
    private Transform mesh;

    public bool IsTouching { get => isTouching; set => isTouching = value; }
    public bool IsPushing { get => isPushing; set => isPushing = value; }

    void Start()
    {
        mesh = transform.GetChild(0);
        mesh.GetChild(1).GetComponent<MeshFilter>().mesh = mesh.GetChild(0).GetComponent<MeshFilter>().mesh;
        mesh.GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_OutlineColor", hightLightColor);
        mesh.GetChild(1).transform.localScale = mesh.GetChild(0).transform.localScale;
        mesh.GetChild(1).transform.position = mesh.GetChild(0).transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching&&(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                isPushing = true;
    }

}
