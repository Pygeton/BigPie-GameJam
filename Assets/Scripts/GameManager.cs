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
    public bool TextScreenChange;//trueʱtextscreen�Զ��ı�
    [Header("�¼�״̬")]
    public int eventCode;
    public Person tempPerson;
    public bool over;
    [Header("Ŀ����")]
    public int PurposeCode;
    public List<int> purposeList;
    public Text purposeText;
    public GameObject winObject;
    public GameObject lostObject;
    public GameObject pauseObject;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        winObject.SetActive(false);
        lostObject.SetActive(false) ;
        pauseObject.SetActive(false);
        delayedShow.Add("");
        for (int i = 1; i < 28; i++)
        {
            string tempstring = "���������������" + (27 - i) / 2 + "��\n";
            delayedShow.Add(tempstring);
        }
        for (int j = 1; j < 40; j++)
        {
            string tempstring = "";
            delayedShow.Add(tempstring);
        }//��ֹ����


    }
    public void Start()
    {
        over = false;
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
        purposeText.text = PurposeText(PurposeCode);
        if (loadingInt>100)
            loadingInt = 100;
        if(loadingInt<0)
            loadingInt = 0;
        if (over == false && (turn >= 28 || loadingInt == 100 || workPersons.Count == 0))
            over = true;

        if (over == true)
        {
            over=false; 
            if (loadingInt == 100)
                winObject.SetActive(true);
            else
                lostObject.SetActive(true);
        }

    }





    public void TextScreenShow(int a,Person p)//������Ļ
    {
        eventCode = a;
        tempPerson = p;
    }
    public void TextScreenShow(int a)//������Ļ
    {
        eventCode = a;
        tempPerson = null;
        TextScreenChange = true;
    }

    public void NextPart()
    {
        TextScreenShow(99);
        turn++;
        int a = CheckFinish();
        if (a!= 0)
        {
            loadingInt += a;
            RollPurpose();
        }

       
            p1VINK.NewPart();
            p2Seeyn.NewPart();
            p3BigBoom.NewPart();
            p4Bony.NewPart();
            player.NextPart();

        
        
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
        delayedShow[turn + a-1] += text + "\n";
    }


    public string PurposeText(int a)
    {
        string text = "";
        switch (a)
        {
            case 1:
                text = "������(10):�ڳ�������һ����Ա����>=60";
                break;
            case 2:
                text = "˼�����(10):����ֵ>=50";
                break;
            case 3:
                text = "֧������(10):���ʲ�>=100";
                break;
            case 4:
                text = "��������(10):VINK����>=60";
                break;
            case 5:
                text = "����Э��(10):ȫ����Ա�ڳ�";
                break;
            case 6:
                text = "����(10):������>=40";
                break;
            case 7:
                text = "�����Ӱ�(25):�ڳ���Ա�����ܺ�>=150,�����ܺ�>=150";
                break;
            case 8:
                text = "�����ز�(25):�������ʽ�>=500�������ڳ�Ա��ѧ������";
                break;
            case 9:
                text = "˼ά�籩(30):����ֵ>=300";
                break;
            case 10:
                text = "ȫ��ǰ��(35):�ڳ���Ա�����ܺ�>=150�������ܺ�>=150,�����ܺ�>=150";
                break;
            case 11:
                text = "������(35)�������ʽ�>=700";
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
                if (!purposeList.Contains(b))
                    a = b;
            }
            else if (purposeNum == 5)
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(7, 9);
                if (!purposeList.Contains(b))
                    a = b;
            }
            else if (purposeNum == 6)
            {
                int b = Koubot.Tool.Random.RandomTool.GenerateRandomInt(10, 11);
                if (!purposeList.Contains(b))
                    a = b;
            }
            else
                a = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 11);
        }
        
        PurposeCode = a;           
    }


    private int CheckFinish()
    {
        int finishPoint = 0;
        switch (PurposeCode)
        {
            case 1:
                foreach(var p in workPersons)
                {
                    if(p.health>=60&&p.Exist)
                        finishPoint = 10;
                }
                break;
            case 2:
                if(create>= 50)
                      finishPoint = 10;
                break;
            case 3:
                if(money>=100)
                {
                    money -= 100;
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
                if (p3BigBoom.mood >= 40)
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
                    if (a1 >= 150 && a2 >= 150)
                        finishPoint = 25;
                }
                break;
            case 8:
                if (money >= 500)
                {
                    //�������������Ҫ��Ǯ
                    money -= 500;
                    finishPoint = 25;
                }
                    
                break;
            case 9:
                if (create >= 300)
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
                    if (b1 >= 150 && b2 >= 150&&b3>=150)
                        finishPoint = 35;
                }
                break;
            case 11:
                if(money >= 700)
                {
                    money -= 700;
                    finishPoint = 35;
                }
                     
                break;
            default: break;
        }
        return finishPoint;
    }

}
