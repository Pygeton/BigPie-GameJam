using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Attribute { Health,Spirit,Mood,Money,Create,RunAway,LoadingInt,Null}
public class Person : MonoBehaviour
{
    public string personName;
    public Sprite bigHead;
    public int health;
    public int spirit;
    public int mood;
    public int Event;
    public bool Finish;
    public bool Exist;
    public bool Draw;
    public bool runAway;//������·
    [Header("�ӳٽ���")]
    [SerializeField] private List<int> delayTurn;
    [SerializeField] private List<Attribute> delayAttributeType;
    [SerializeField] private List<int> delayAttributeAdjust;
    [SerializeField] private List<bool> delayExist;


    protected void Start()
    {
        Draw = false;
        runAway = false;
        NewPart();
    }
    // Update is called once per frame
    protected void Update()
    {
        if (Exist == false)
            Finish = true;
        if(Event == 0)
            Finish = true;
        if (runAway == true && GameManager.instance.workPersons.Contains(this))
            GameManager.instance.workPersons.Remove(this);
        if (runAway == true)
            Exist = !runAway;
    }

    public void NewPart()
    {
        if (runAway == false)
        {
            Exist = true;
            //������ʱ����
            SettleDelay();
            Finish = false;

            //rollevent
            if (Exist == true)
            { RollEvent(); }
            else
                Event = 0;
        }
        




    }


    private void SettleDelay()
    {
        for (int i = 0; i < delayTurn.Count; i++)
        {
            if (delayTurn[i] == GameManager.instance.turn)
                SettleSingleDelay(delayAttributeType[i], delayAttributeAdjust[i], delayExist[i]);
        }
    }
    private void SettleSingleDelay(Attribute dattr, int dadjust, bool exist)
    {
        Exist=exist;
        if (dattr == Attribute.Health)
        {
            health += dadjust;
        }
        else if (dattr == Attribute.Spirit)
        {
            spirit += dadjust;
        }
        else if (dattr == Attribute.Mood)
        {
            mood += dadjust;
        }
        else if(dattr == Attribute.Money)
        {
            GameManager.instance.money += dadjust;
        }
        else if (dattr == Attribute.Create)
        {
            GameManager.instance.create += dadjust;
        }
        else if (dattr == Attribute.LoadingInt)
        {
            GameManager.instance.loadingInt += dadjust;
        }
        else if(dattr == Attribute.RunAway)
        {
            runAway = true;
        }
    }

    private void RollEvent()
    {
        
        if (Koubot.Tool.Random.RandomTool.GenerateRandomInt(0, 99) < 50)
            Event = 100;
        else
        {
            int a = 9999;
            if (health <= 0)
                a = 10;
            else if (mood <= 0)
                a = 22;
            else if (spirit <= 0)
                a = 8;
            while (a == 9999)
            {
                Event = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 22);
                
                switch (Event)
                {
                    case 1://��������
                        if (health < 50)
                            a = 1;
                        break;
                    case 2://����
                        if (spirit <= 30)
                            a = 2;
                        break;
                    case 3://ή�Ҳ���
                        if (spirit <= 10)
                            a = 3;
                        break;
                    case 4://����֮��
                        a = 4;
                        break;
                    case 5://��������
                        a = 5;
                        break;
                    case 6://ج��
                        a = 6;
                        break;
                    case 7://We gonna party��
                        a = 7;
                        break;
                    case 9://���ܿ�ŭ
                        if (personName == "��" && mood <= 30)
                            a = 9;
                        break;
                    case 11://ͣ��
                            a = 11;
                        break;
                    case 12://�������
                        if(Koubot.Tool.Random.RandomTool.GenerateRandomInt(1,100)<30)
                            a = 12;
                        break;
                    case 13://���һ���
                        if (personName == "��yn" || personName == "��")
                            a = 13;
                        break;
                    case 14://����
                            a = 14;
                        break;
                    case 15://�׼�
                        /*Ŀǰʵ�ַ���δ֪���μ��ĵ�*/
                            a=15;
                        break;
                    case 16://����
                        if (mood <= 30)
                            a = 16;
                        break;
                    case 17://ѧ����
                        if (personName == "��yn" || personName == "��")
                            a = 17;
                        break;
                    case 18:
                        a = 18;
                        break;
                    case 19:
                        a = 19;
                        break;
                    case 20:
                        a = 20;
                        break;
                    case 21:
                        a = 21;
                        break;
                    case 23:
                        a = 21;
                        break;


                    default: break;
                }

            }
            Event = a;
        }
    }

    public void SetDelay(int turn, Attribute attr, int adjust, bool exist)
    {
        delayTurn.Add(GameManager.instance.turn+turn);
        delayAttributeType.Add(attr);
        delayAttributeAdjust.Add(adjust);
        delayExist.Add(exist);
    }
}
