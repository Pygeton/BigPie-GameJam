using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int turn;
    public int loadingInt;
    public int money;
    public int create;
    public int purposeNum;
    public Person1VINK p1VINK;
    public Person2Seeyn p2Seeyn;
    public Person3BigBoom p3BigBoom;
    public Person4Bony p4Bony;
    public List<Person> workPersons=new List<Person>();
    public Player player;
    public List<string> delayedShow=new List<string>();
    public bool TextScreenChange;//true时textscreen自动改变
    [Header("事件状态")]
    public int eventCode;
    public Person tempPerson;
    public bool over;
    public bool finish;
    public bool pauseSwitch;
    [Header("目标编号")]
    public int PurposeCode;
    public Text purposeText;
    public GameObject winObject;
    public GameObject lostObject;
    public GameObject startObject;
    public GameObject teachObject;
    public GameObject pauseObject;
    public GameObject nextPartObject;
    public Text nextPartText;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        winObject.SetActive(false);
        lostObject.SetActive(false) ;
        pauseObject.SetActive(false);
        nextPartObject.SetActive(false) ;
        teachObject.SetActive(false) ;
        startObject.SetActive(true);
        delayedShow.Add("");
        for (int i = 1; i < 28; i++)
        {
            string tempstring = "距离比赛结束还有" + (27 - i) / 2 + "天\n";
            delayedShow.Add(tempstring);
        }
        for (int j = 1; j < 40; j++)
        {
            string tempstring = "";
            delayedShow.Add(tempstring);
        }//防止超界


    }
    public void Start()
    {
        over = false;
        finish = false;
        pauseSwitch = false;
        TextScreenShow(99);
        turn = 1;
        purposeNum = 0;
        RollPurpose();
        workPersons.Add(p1VINK);
        workPersons.Add(p2Seeyn);
        workPersons.Add(p3BigBoom);
        workPersons.Add(p4Bony);
        Begining();
    }
    private void Begining()
    {
        int a = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 5);
        switch (a)
        {
            case 1:
                money += 50;
                create += 50;
                break;
            case 2:
                foreach(var p in workPersons)
                {
                    p.health += Koubot.Tool.Random.RandomTool.GenerateRandomInt(10, 15);
                }
                break;
            case 3:
                foreach (var p in workPersons)
                {
                    p.spirit += Koubot.Tool.Random.RandomTool.GenerateRandomInt(10, 15);
                }
                break;
            case 4:
                foreach (var p in workPersons)
                {
                    p.mood += Koubot.Tool.Random.RandomTool.GenerateRandomInt(10, 15);
                }
                break;
            case 5:
                loadingInt += Koubot.Tool.Random.RandomTool.GenerateRandomInt(5, 20);
                break;
            default: break;


        }

    }

    private void Update()
    {
        if(pauseSwitch==false)
            purposeText.text = PurposeText(PurposeCode);
        if (loadingInt>100)
            loadingInt = 100;
        if(loadingInt<0)
            loadingInt = 0;
        if (over == false && (turn >= 28 || loadingInt == 100 || workPersons.Count == 0)&&!(winObject.activeInHierarchy||lostObject.activeInHierarchy))
            over = true;

       

    }



    public void CloseStart()
    {
        startObject.SetActive(false);
        teachObject.SetActive(true);
    }

    public void CloseTeach()
    {
        teachObject.SetActive(false);
    }
    public void TextScreenShow(int a,Person p)//更新屏幕
    {
        eventCode = a;
        tempPerson = p;
    }
    public void TextScreenShow(int a)//更新屏幕
    {
        eventCode = a;
        tempPerson = null;
        TextScreenChange = true;
    }

    //按钮nextpart
    public void NextPart()
    {
        pauseSwitch = true;//暂停屏幕更新
        int a = CheckFinish();
        if (a != 0)
        {
            loadingInt += a;
            RollPurpose();
        }
        StartCoroutine(WinOrLostPart());
            
    }

    IEnumerator WinOrLostPart()
    {     
        yield return null;
        turn++;
        if (over == true && finish == false)
        {
            finish = true;
            StartCoroutine(WinLost());
        }
        else if (over == false)
        {             
            if (over == false)
                StartCoroutine(ShowNextPart()); 
        }

    }
    IEnumerator WinLost()
    {
        Debug.Log("游戏结束");
        StartCoroutine(ShowNextPart());
        yield return new WaitForSeconds(0.8f);
        if (loadingInt == 100)
            winObject.SetActive(true);
        else
            lostObject.SetActive(true);

    }
    private void PersonNextPart()
    {
        
        p1VINK.NewPart();
        p2Seeyn.NewPart();
        p3BigBoom.NewPart();
        p4Bony.NewPart();
        player.NextPart();
    }
    IEnumerator ShowNextPart()
    {
            nextPartText.text = "";
            nextPartObject.SetActive(true);
            LeanTween.color(nextPartObject.GetComponent<RectTransform>(), new Color32(0, 0, 0, 255), 0.5f);
            yield return new WaitForSeconds(0.3f);
            nextPartText.text = NextPartText();
            yield return new WaitForSeconds(1f);
        //转场黑屏的时候更新
            TextScreenShow(99);//更新屏幕文字
            pauseSwitch = false;//恢复屏幕更新
        PersonNextPart();//全员更新
        //恢复屏幕
            LeanTween.color(nextPartObject.GetComponent<RectTransform>(), new Color32(0, 0, 0, 0), 0.3f);
            yield return new WaitForSeconds(0.15f);
            nextPartText.text = "";
            yield return new WaitForSeconds(0.15f);
            nextPartObject.SetActive(false);
            
    }

    private string NextPartText()
    {
        string day;
        day= "第" + ((GameManager.instance.turn - 1) / 2 + 1) + "天 ";
        if (GameManager.instance.turn % 2 == 1)
            day+= "上午";
        else
            day+= "下午";
        if (GameManager.instance.turn > 28)
            day = "比赛截止";
        return day;
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }
    public void ClosePause()
    {
        pauseObject.SetActive(false);
    }
    public void SetDelayedText(int a,string text)
    {
        delayedShow[turn + a-1] +="·"+ text + "\n";
    }


    public string PurposeText(int a)
    {
        string text = "";
        switch (a)
        {
            case 1:
                text = "体力活(10):在场的其中一个人员健康>=60";
                break;
            case 2:
                text = "思考题材(10):创想值>=20";
                break;
            case 3:
                text = "支持正版(10):总资产>=200";
                break;
            case 4:
                text = "精力充沛(10):VINK精力>=60";
                break;
            case 5:
                text = "齐心协力(10):全部人员在场";
                break;
            case 6:
                text = "鼓舞(10):大保心情>=60";
                break;
            case 7:
                text = "紧急加班(25):在场人员精力总和>=200,心情总和>=200";
                break;
            case 8:
                text = "美术素材(25):工作室资金>=500或者有在场员工学过美术";
                break;
            case 9:
                text = "思维风暴(30):创想值>=200";
                break;
            case 10:
                text = "全速前进(35):在场人员精力总和>=200，健康总和>=200,心情总和>=200";
                break;
            case 11:
                text = "钞能力(35)工作室资金>=800";
                break;
            default: break;
        }
        return text;

    }

    public void RollPurpose()
    {
        purposeNum++;
        int a = 99;
        while(a==99)
        {
            if (purposeNum <= 4)
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 6);
                if (b != PurposeCode)
                    a = b;
            }
            else if (purposeNum == 5)
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(7, 9);
                if (b != PurposeCode)
                    a = b;
            }
            else if (purposeNum == 6)
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(10, 11);
                if (b != PurposeCode)
                    a = b;
            }
            else
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 11);
                if (b != PurposeCode)
                    a = b;
            }
                
        }
        
        PurposeCode = a;           
    }


    private int CheckFinish()
    {
        int finishPoint = 0;
        switch (PurposeCode)
        {
            case 1:
                bool c = false;
                foreach(var p in workPersons)
                {
                    if(p.health>=60&&p.Exist)
                    {
                        c = true;
                    }
                }
                if(c==true)
                    finishPoint = 10;
                break;
            case 2:
                if(create>= 20)
                      finishPoint = 10;
                break;
            case 3:
                if(money>=200)
                {
                    money -= 200;
                    finishPoint = 10;
                }
                    
                break;
            case 4:
                if(p1VINK.spirit>=60)
                    finishPoint=10;
                break;
            case 5:
                int a = 0;
                foreach(var p in workPersons)
                {
                    if(p.Exist==true)
                        a++;
                }
                if(a==4)
                    finishPoint = 10;
                break;
            case 6:
                if (p3BigBoom.mood >= 60)
                    finishPoint = 10;
                break;
            case 7:
                int a1 = 0;
                int a2=0;
                foreach(var p in workPersons)
                {
                    if(p.Exist ==true)
                    {
                        a1 += p.spirit;
                        a2 += p.mood;
                    }
                    if (a1 >= 200 && a2 >= 200)
                        finishPoint = 25;
                }
                break;
            case 8:
                bool b = false;
                foreach (var p in workPersons)
                {
                    if (p.Draw == true)
                        b = true;
                }
                if (money >= 500||b==true)
                {
                    
                    if(b==false)
                         money -= 500;
                    finishPoint = 25;
                }
                    
                break;
            case 9:
                if (create >= 200)
                    finishPoint = 30;
                break;
            case 10:
                int b1 = 0;
                int b2 = 0;
                int b3 = 0;
                foreach (var p in workPersons)
                {
                    if (p.Exist == true)
                    {
                        b1 += p.spirit;
                        b2 += p.health;
                        b3 += p.mood;
                    }
                    if (b1 >= 200 && b2 >= 200&&b3>=200)
                        finishPoint = 35;
                }
                break;
            case 11:
                if(money >= 800)
                {
                    money -= 800;
                    finishPoint = 35;
                }
                     
                break;
            default: break;
        }
        return finishPoint;
    }

}
