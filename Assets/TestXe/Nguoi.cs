using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nguoi : MonoBehaviour
{
    [Header("Ide = 1    Sit = 2    Walk = 3")]
    public int status;

    private Animator ani;
    private bool isIde;
    private bool isWalk;
    private bool isSit;
    void Start()
    {
        switch (status)
        {
            case 1:
                isIde = true;
                break;
            case 2:
                isSit = true;
                break;
            case 3:
                isWalk = true;
                break;
        }
        ani = GetComponent<Animator>();
        ControllAni();
    }

    // Update is called once per frame
    void Update()
    {
        ControllAni();
    }
    void ControllAni()
    {
        if (isIde)
            SetAni("Stand",ref isIde);
        if (isWalk)
            SetAni("Walk",ref isWalk);
        if (isSit)
            SetAni("Sit",ref isSit);
    }
    private void SetAni(string s,ref bool b)
    {
        ani.SetTrigger(s);
        b = false;
    }
}
