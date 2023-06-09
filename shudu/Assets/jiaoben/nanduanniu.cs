using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class nanduanniu : MonoBehaviour
{
    Animator wancheng_ani;
    private void Start()
    {
        wancheng_ani = GameObject.Find("wancheng").GetComponent<Animator>();
    }
    public void dianjianniu()
    {
        fuzhipailie jiaoben = GameObject.Find("youxi_guanliqi").GetComponent<fuzhipailie>();
        switch (transform.name)
        {
            case "jiandan":
                jiaoben.yincangshu = 1;
                break;
            case "zhongdeng":
                jiaoben.yincangshu = 5;
                break;
            case "kunnan":
                jiaoben.yincangshu = 7;
                break;
        }
        FindAnyObjectByType<fuzhipailie>().fuzhizujian();
        FindAnyObjectByType<fuzhipailie>().miao = 0;
        FindAnyObjectByType<fuzhipailie>().fenzhong = 0;
        FindAnyObjectByType<fuzhipailie>().xiaoshi = 0;
        FindAnyObjectByType<fuzhipailie>().kaishijishi = true;
        FindAnyObjectByType<fuzhipailie>().wancheng = false;
        wancheng_ani.SetBool("wancheng", false);
        wancheng_ani.speed = 1;
    }
}
