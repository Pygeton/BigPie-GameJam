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
    public bool finish;
    public bool pauseSwitch;
    [Header("Ŀ����")]
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

    //��ťnextpart
    public void NextPart()
    {
        pauseSwitch = true;//��ͣ��Ļ����
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
        Debug.Log("��Ϸ����");
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
        //ת��������ʱ�����
            TextScreenShow(99);//������Ļ����
            pauseSwitch = false;//�ָ���Ļ����
        PersonNextPart();//ȫԱ����
        //�ָ���Ļ
            LeanTween.color(nextPartObject.GetComponent<RectTransform>(), new Color32(0, 0, 0, 0), 0.3f);
            yield return new WaitForSeconds(0.15f);
            nextPartText.text = "";
            yield return new WaitForSeconds(0.15f);
            nextPartObject.SetActive(false);
            
    }

    private string NextPartText()
    {
        string day;
        day= "��" + ((GameManager.instance.turn - 1) / 2 + 1) + "�� ";
        if (GameManager.instance.turn % 2 == 1)
            day+= "����";
        else
            day+= "����";
        if (GameManager.instance.turn > 28)
            day = "������ֹ";
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
        delayedShow[turn + a-1] +="��"+ text + "\n";
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
                text = "˼�����(10):����ֵ>=20";
                break;
            case 3:
                text = "֧������(10):���ʲ�>=200";
                break;
            case 4:
                text = "��������(10):VINK����>=60";
                break;
            case 5:
                text = "����Э��(10):ȫ����Ա�ڳ�";
                break;
            case 6:
                text = "����(10):������>=60";
                break;
            case 7:
                text = "�����Ӱ�(25):�ڳ���Ա�����ܺ�>=200,�����ܺ�>=200";
                break;
            case 8:
                text = "�����ز�(25):�������ʽ�>=500�������ڳ�Ա��ѧ������";
                break;
            case 9:
                text = "˼ά�籩(30):����ֵ>=200";
                break;
            case 10:
                text = "ȫ��ǰ��(35):�ڳ���Ա�����ܺ�>=200�������ܺ�>=200,�����ܺ�>=200";
                break;
            case 11:
                text = "������(35)�������ʽ�>=800";
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
