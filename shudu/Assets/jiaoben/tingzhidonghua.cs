using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tingzhidonghua : MonoBehaviour
{
    Animator donghua;
    private void Start()
    {
        donghua = GetComponent<Animator>();
    }
    public void tingzhi()
    {
        donghua.speed = 0;
    }
}
