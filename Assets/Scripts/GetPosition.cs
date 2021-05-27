using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    public bool isSelf;
    public Vector3 newPosition;
    private GameObject player;
    private InteractionObject iObj;
    void Start()
    {
        if (isSelf)
            newPosition = transform.position;
        iObj = GetComponent<InteractionObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)
            player = QuanLiGhe.player;
        ChangPosition();
    }
    void ChangPosition()
    {
        if (iObj.IsPushing)
        {
            player.transform.position = newPosition;
            iObj.IsPushing = false;
        }
    }
}
