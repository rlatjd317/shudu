using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class fuzhipailie : MonoBehaviour
{
    public GameObject zujian_yuzhi;
    GameObject zujianzumianban_go;
    public GameObject shuzi_yuzhi;
    GameObject shuzimianban_go;
    GameObject duicuo_hengxiang_go;
    GameObject duicuo_shuxiang_go;
    public GameObject duicuo_yuzhi;
    GameObject xuanzhongkuang_go;
    Text jishiqi;
    Animator wanchengdonghua;

    private void Start()
    {
        zujianzumianban_go = GameObject.Find("zujianzumianban");
        shuzimianban_go = GameObject.Find("shuzizumianban");
        duicuo_hengxiang_go = GameObject.Find("panduan_hengxiang");
        duicuo_shuxiang_go = GameObject.Find("panduan_shuxiang");
        xuanzhongkuang_go = GameObject.Find("xuanzhongkuang");
        jishiqi = GameObject.Find("jishiqi").GetComponent<Text>();
        wanchengdonghua = GameObject.Find("wancheng").GetComponent<Animator>();
        // fuzhizujian();
        shengchengshuzi();
        shengchengduicuo();

    }
    public int yincangshu;
    bool tiaochuxunhuan;
    public void fuzhizujian()
    {
        #region 清空组件
        Transform[] zizujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        for (int i = 1; i < zizujianzu.Length; i++)
        {
            Destroy(zizujianzu[i].gameObject);
        }
        #endregion

        #region 创建组件
        for (int i = 0; i < 9; i++)
        {
            List<int> morenlist = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            List<int> listyincang = new List<int>();
            for (int j = 0; j < yincangshu; j++)
            {
                int suijishu = Random.Range(1, morenlist.Count + 1);
                listyincang.Add(morenlist[suijishu - 1]);
                morenlist.RemoveAt(suijishu - 1);
            }

            for (int j = 0; j < 9; j++)
            {
                tiaochuxunhuan = false;
                GameObject yuzhizujian = Instantiate(zujian_yuzhi, zujianzumianban_go.transform);
                yuzhizujian.name = (i + 1).ToString() + (j + 1).ToString();
                int wenbenzhi = i + j + 1;
                if (i + j >= 9)
                {
                    wenbenzhi = i + j - 9 + 1;
                }
                for (int l = 0; l < listyincang.Count; l++)
                {
                    if (j + 1 == listyincang[l])
                    {
                        tiaochuxunhuan = true;
                    }
                }
                if (tiaochuxunhuan)
                {
                    continue;
                }
                yuzhizujian.transform.GetChild(0).GetComponent<Text>().text = wenbenzhi.ToString();
                yuzhizujian.GetComponent<zujian_shuxing>().suoding = true;
            }
        }
        pailie();
        #endregion

        daluan();
    }

    void pailie()
    {
        hengxiang1 = 2;
        hengxiang2 = 4;
        hengxiangdaluan();
        hengxiang1 = 3;
        hengxiang2 = 7;
        hengxiangdaluan();
        hengxiang1 = 6;
        hengxiang2 = 8;
        hengxiangdaluan();
        shuaxinzujianyanse();
    }
    int hengxiang1;
    int hengxiang2;
    void hengxiangdaluan()
    {
        #region 横向打乱

        if (hengxiang1 != hengxiang2)
        {
            Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
            List<Transform> list1 = new List<Transform>();
            List<Transform> list2 = new List<Transform>();
            List<string> listzhi = new List<string>();
            List<bool> listzujiansuoding = new List<bool>();
            for (int i = 0; i < zujianzu.Length; i++)
            {
                if (zujianzu[i].name.Substring(0, 1) == hengxiang1.ToString())
                {
                    list1.Add(zujianzu[i]);
                }
                if (zujianzu[i].name.Substring(0, 1) == hengxiang2.ToString())
                {
                    list2.Add(zujianzu[i]);
                    string zhi = zujianzu[i].GetChild(0).GetComponent<Text>().text;
                    listzhi.Add(zhi);
                    listzujiansuoding.Add(zujianzu[i].GetComponent<zujian_shuxing>().suoding);
                }
            }
            for (int i = 0; i < list2.Count; i++)
            {
                list2[i].GetChild(0).GetComponent<Text>().text = list1[i].GetChild(0).GetComponent<Text>().text;
                list2[i].GetComponent<zujian_shuxing>().suoding = list1[i].GetComponent<zujian_shuxing>().suoding;
            }
            for (int i = 0; i < list1.Count; i++)
            {
                list1[i].GetChild(0).GetComponent<Text>().text = listzhi[i].ToString();
                list1[i].GetComponent<zujian_shuxing>().suoding = listzujiansuoding[i];
            }
        }
        #endregion
    }
    int shuxiang1;
    int shuxiang2;
    void shuxiangdaluan()
    {
        #region 竖向打乱

        if (shuxiang1 != shuxiang2)
        {
            Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
            List<Transform> list1 = new List<Transform>();
            List<Transform> list2 = new List<Transform>();
            List<string> listzhi = new List<string>();
            List<bool> listzujiansuoding = new List<bool>();
            for (int i = 0; i < zujianzu.Length; i++)
            {
                if (zujianzu[i].name.Substring(1, 1) == shuxiang1.ToString())
                {
                    list1.Add(zujianzu[i]);
                }
                if (zujianzu[i].name.Substring(1, 1) == shuxiang2.ToString())
                {
                    list2.Add(zujianzu[i]);
                    string zhi = zujianzu[i].GetChild(0).GetComponent<Text>().text;
                    listzhi.Add(zhi);
                    listzujiansuoding.Add(zujianzu[i].GetComponent<zujian_shuxing>().suoding);
                }
            }
            for (int i = 0; i < list2.Count; i++)
            {
                list2[i].GetChild(0).GetComponent<Text>().text = list1[i].GetChild(0).GetComponent<Text>().text;
                list2[i].GetComponent<zujian_shuxing>().suoding = list1[i].GetComponent<zujian_shuxing>().suoding;
            }
            for (int i = 0; i < list1.Count; i++)
            {
                list1[i].GetChild(0).GetComponent<Text>().text = listzhi[i].ToString();
                list1[i].GetComponent<zujian_shuxing>().suoding = listzujiansuoding[i];
            }
        }
        #endregion
    }
    void shengchengshuzi()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject yuzhizujian = Instantiate(shuzi_yuzhi, shuzimianban_go.transform);
            yuzhizujian.name = (i + 1).ToString();
            yuzhizujian.transform.GetComponent<Text>().text = (i + 1).ToString();
        }
    }
    List<Transform> panduan_hengxiang_zujianlist = new List<Transform>();
    List<Transform> panduan_shuxiang_zujianlis = new List<Transform>();
    void shengchengduicuo()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject yuzhizujian = Instantiate(duicuo_yuzhi, duicuo_hengxiang_go.transform);
            yuzhizujian.name = (i + 1).ToString();
            yuzhizujian.transform.Find("dui").transform.localScale = Vector3.zero;
            yuzhizujian.transform.Find("cuo").transform.localScale = Vector3.zero;
            panduan_hengxiang_zujianlist.Add(yuzhizujian.transform);

            GameObject yuzhizujian1 = Instantiate(duicuo_yuzhi, duicuo_shuxiang_go.transform);
            yuzhizujian1.name = (i + 1).ToString();
            yuzhizujian1.transform.Find("dui").transform.localScale = Vector3.zero;
            yuzhizujian1.transform.Find("cuo").transform.localScale = Vector3.zero;
            panduan_shuxiang_zujianlis.Add(yuzhizujian1.transform);
        }
    }

    bool youcuowu;
    bool youkongzhi;
    int panduan_hengshu;
    public void panduanduicuo()
    {
        huanyuanzitiyanse();
        panduan_hengshu = 0;//判断横向
        panduanhengshu();
        panduan_hengshu = 1;//判断竖向
        panduanhengshu();
        panduanjiugongge();
        panduanwancheng();
    }
    void panduanwancheng()
    {
        youkongzhi = false;

        Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        for (int i = 0; i < zujianzu.Length; i++)
        {
            if (zujianzu[i].name == "wenben")
            {
                if (zujianzu[i].GetComponent<Text>().text == "")
                {
                    youkongzhi = true; 
                    break;
                }
            }
        }
        
        if (!youkongzhi && !youcuowu)
        {
            wancheng = true;
            wanchengdonghua.transform.localScale = Vector3.one;
            wanchengdonghua.SetBool("wancheng", true);
            Debug.Log(wancheng);
        }
    }

    void huanyuanzitiyanse()
    {
        Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        for (int i = 0; i < zujianzu.Length; i++)
        {
            if (zujianzu[i].name == "wenben")
            {
                zujianzu[i].GetComponent<Text>().color = Color.black;
            }
        }
    }

    Transform dangqianzujian;
    void panduanhengshu()
    {
        youcuowu = false;
        youkongzhi = false;

        Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        List<Transform> zujianlist = new List<Transform>();
        for (int i1 = 0; i1 < 9; i1++)
        {
            if (panduan_hengshu == 0)
            {
                dangqianzujian = panduan_hengxiang_zujianlist[i1].transform;
            }
            else if (panduan_hengshu == 1)
            {
                dangqianzujian = panduan_shuxiang_zujianlis[i1].transform;
            }
            Transform wu_tr = dangqianzujian.Find("wu").GetComponent<Transform>();
            Transform dui_tr = dangqianzujian.Find("dui").GetComponent<Transform>();
            Transform cuo_tr = dangqianzujian.Find("cuo").GetComponent<Transform>();
            wu_tr.localScale = Vector3.one;
            dui_tr.localScale = Vector3.zero;
            cuo_tr.localScale = Vector3.zero;
            zujianlist.Clear();
            for (int i = 0; i < zujianzu.Length; i++)
            {
                if (zujianzu[i].name.Substring(panduan_hengshu, 1) == (i1 + 1).ToString())
                {
                    zujianlist.Add(zujianzu[i]);
                }
            }
            for (int i = 0; i < zujianlist.Count; i++)
            {
                for (int j = i + 1; j < zujianlist.Count; j++)
                {
                    if (zujianlist[i].GetChild(0).GetComponent<Text>().text != "" &&
                       zujianlist[j].GetChild(0).GetComponent<Text>().text != "")
                    {
                        string bijiao1 = zujianlist[i].GetChild(0).GetComponent<Text>().text;
                        string bijiao2 = zujianlist[j].GetChild(0).GetComponent<Text>().text;
                        if (bijiao1 == bijiao2)
                        {
                            youcuowu = true;
                            zujianlist[i].GetChild(0).GetComponent<Text>().color = Color.red;
                            zujianlist[j].GetChild(0).GetComponent<Text>().color = Color.red;
                        }
                    }
                }
                if (zujianlist[i].GetChild(0).GetComponent<Text>().text == "")
                {
                    youkongzhi = true;
                }
            }
            if (youcuowu)
            {
                wu_tr.localScale = Vector3.zero;
                dui_tr.localScale = Vector3.zero;
                cuo_tr.localScale = Vector3.one;
            }

            if (!youkongzhi && !youcuowu)
            {
                wu_tr.localScale = Vector3.zero;
                dui_tr.localScale = Vector3.one;
                cuo_tr.localScale = Vector3.zero;
            }
        }
    }
    void panduanjiugongge()

    {
        Transform[] zujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        List<Transform> zujianlist = new List<Transform>();
        zujianlist.Clear();
        for (int i = 1; i < zujianzu.Length; i++)
        {
            if (zujianzu[i].name != "wenben")
            {
                zujianlist.Add(zujianzu[i]);
            }
        }
        List<Transform> zujianlist1 = new List<Transform>();
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                youcuowu = false;
                youkongzhi = false;
                zujianlist1.Clear();

                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        string zujianname = (j * 3 + (k + 1)).ToString() + (i * 3 + (l + 1)).ToString();
                        for (int m = 0; m < zujianlist.Count; m++) 
                        {
                            if (zujianlist[m].name == zujianname)
                            {
                                zujianlist1.Add(zujianlist[m]);
                            }
                        }
                    }
                }

                for (int i1 = 0; i1 < zujianlist1.Count; i1++)
                {
                    for (int j1 = i1 + 1; j1 < zujianlist1.Count; j1++)
                    {
                        if (zujianlist1[i1].GetChild(0).GetComponent<Text>().text != "" &&
                           zujianlist1[j1].GetChild(0).GetComponent<Text>().text != "")
                        {
                            string bijiao1 = zujianlist1[i1].GetChild(0).GetComponent<Text>().text;
                            string bijiao2 = zujianlist1[j1].GetChild(0).GetComponent<Text>().text;
                            if (bijiao1 == bijiao2)
                            {

                                youcuowu = true;
                                zujianlist1[i1].GetChild(0).GetComponent<Text>().color = Color.red;
                                zujianlist1[j1].GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                        }
                    }
                    if (zujianlist1[i1].GetChild(0).GetComponent<Text>().text == "")
                    {
                        youkongzhi = true;
                    }
                }
                if (youcuowu)
                {
            //        Debug.Log("youcuowu");
                }

                if (!youkongzhi && !youcuowu)
                {
             //       Debug.Log("dui");
                }
            }
        }
    }
    bool shubiaoanzhu;
    RaycastHit2D dianji_shuzizujian;
    Vector3 mos_pos;
    bool jiluzujian;
    int xuanzeshuzi;
    GameObject fuzhiyidongzujian_go;
    GameObject xuanzhongzujian_go;
    bool xuanzhong;
    public float miao;
    public int fenzhong;
    public int xiaoshi;
    public bool kaishijishi;
    public bool wancheng;
    private void Update()
    {
        if (wancheng)
        {
            return;
        }
        if (kaishijishi)
        {
            miao += Time.deltaTime;
            if (miao >= 60)
            {
                fenzhong += 1;
                miao = 0;
            }
            if (fenzhong == 60)
            {
                xiaoshi += 1;
            }
            jishiqi.text = xiaoshi + ":" + fenzhong + ":" + miao.ToString("f2");
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            shubiaoanzhu = true;
            mos_pos = Input.mousePosition;

            if (xuanzhong)
            {
                RaycastHit2D dianjishuzi = Physics2D.Raycast(mos_pos, Vector2.zero, 0, LayerMask.GetMask("shuzi"));
                if (dianjishuzi.transform != null)
                {
                    xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = dianjishuzi.transform.name;
                    panduanduicuo();
                }
                else
                {
                    xuanzhong = false;
                    xuanzhongkuang_go.transform.localScale = Vector3.zero;
                }
            }

            RaycastHit2D fangzhizujian = Physics2D.Raycast(Input.mousePosition, Vector2.zero, 0, LayerMask.GetMask("zujian"));
            if (fangzhizujian.transform != null)
            {
                xuanzhongkuang_go.transform.localScale = Vector3.one;
                xuanzhongkuang_go.transform.position = fangzhizujian.transform.position;
                xuanzhongzujian_go = fangzhizujian.transform.gameObject;
                if (!xuanzhongzujian_go.GetComponent<zujian_shuxing>().suoding)
                {
                    xuanzhong = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D fangzhizujian = Physics2D.Raycast(Input.mousePosition, Vector2.zero, 0, LayerMask.GetMask("zujian"));
            if (fangzhizujian.transform != null)
            {
                if (xuanzeshuzi != 0)
                {
                    if (!fangzhizujian.transform.GetComponent<zujian_shuxing>().suoding)
                    {
                        fangzhizujian.transform.GetChild(0).GetComponent<Text>().text = xuanzeshuzi.ToString();
                        panduanduicuo();
                    }
                }
            }

            shubiaoanzhu = false;
            jiluzujian = false;
            xuanzeshuzi = 0;
            if (fuzhiyidongzujian_go != null)
            {
                Destroy(fuzhiyidongzujian_go);
            }
        }

        if (shubiaoanzhu)
        {
            if (!jiluzujian)
            {
                jiluzujian = true;
                dianji_shuzizujian = Physics2D.Raycast(mos_pos, Vector2.zero, 0, LayerMask.GetMask("shuzi"));
                if (dianji_shuzizujian.transform != null)
                {
                    xuanzeshuzi = int.Parse(dianji_shuzizujian.transform.name);
                    fuzhiyidongzujian_go = Instantiate(dianji_shuzizujian.transform.gameObject, GameObject.Find("Canvas").transform);
                }
            }
            if (dianji_shuzizujian.transform != null)
            {
                fuzhiyidongzujian_go.transform.position = Input.mousePosition;
            }
        }

        if (xuanzhong)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "1";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "2";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "3";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "4";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "5";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "6";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "7";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "8";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
            {
                xuanzhongzujian_go.transform.GetChild(0).GetComponent<Text>().text = "9";
            }

            panduanduicuo();

        }
    }
    void daluan()
    {
        int daluancishu = 3;
        List<int> hengxianglist = new List<int>(new int[] { 1, 2, 3 });
        List<int> shuxianglist = new List<int>(new int[] { 1, 4, 7 });
        for (int i = 0; i < daluancishu; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int suoyin = Random.Range(1, 3);
                hengxiang1 = hengxianglist[0] + j * 3;
                hengxiang2 = hengxianglist[suoyin] + j * 3;
                hengxiangdaluan();
            }

            for (int j = 0; j < 3; j++)
            {
                int suoyin = Random.Range(1, 3);
                shuxiang1 = shuxianglist[0] + i;
                shuxiang2 = shuxianglist[suoyin] + i;
                shuxiangdaluan();
            }
        }

        shuaxinzujianyanse();
    }
    void shuaxinzujianyanse()
    {
        #region 刷新组件颜色
        Transform[] zizujianzu = zujianzumianban_go.GetComponentsInChildren<Transform>();
        for (int i = 1; i < zizujianzu.Length; i++)
        {
            if (zizujianzu[i].name != "wenben")
            {
                if (zizujianzu[i].GetComponent<zujian_shuxing>().suoding == true)
                {
                    zizujianzu[i].GetComponent<Image>().color = new Color(190f / 255, 190f / 255, 190f / 255, 255);
                }
                else
                {
                    zizujianzu[i].GetComponent<Image>().color = Color.white;
                }
            }
        }
        #endregion
    }
}
