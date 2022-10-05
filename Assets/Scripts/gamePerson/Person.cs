using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Attribute { Health,Spirit,Mood,Null}
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

    [Header("延迟结算")]
    [SerializeField] private List<int> delayTurn;
    [SerializeField] private List<Attribute> delayAttributeType;
    [SerializeField] private List<int> delayAttributeAdjust;
    [SerializeField] private List<bool> delayExist;


    protected void Start()
    {
        NewPart();
    }
    // Update is called once per frame
    protected void Update()
    {
        if (Exist == false)
            Finish = true;
        if(Event == 0)
            Finish = true;

    }

    public void NewPart()
    {

        Finish = false;
        Exist = true;
        //rollevent
        RollEvent();
        
        //结算延时函数
        SettleDelay();

    }


    private void SettleDelay()
    {
        for (int i = 0; i < delayTurn.Count; i++)
        {
            if (delayTurn[i] == GameManager.instance.turn)
                SettleSingleDelay(delayAttributeType[i], delayAttributeAdjust[i], delayExist[i]);
        }
    }
    private void SettleSingleDelay(Attribute dattr, int dadjust, bool dexist)
    {
        Exist = dexist;
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
        else
        {

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
            while (a == 9999)
            {
                Event = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1, 16);
                
                switch (Event)
                {
                    case 1://翻江倒海
                        if (health < 50)
                            a = 1;
                        break;
                    case 2://虚弱
                        if (spirit <= 30)
                            a = 2;
                        break;
                    case 3://萎靡不振
                        if (spirit <= 10)
                            a = 3;
                        break;
                    case 4://不速之客
                        a = 4;
                        break;
                    case 5://紧急进修
                        a = 5;
                        break;
                    case 6://噩耗
                        a = 6;
                        break;
                    case 7://We gonna party！
                        a = 7;
                        break;
                    case 8://两眼一黑
                        if (mood <= 0)
                            a = 8;
                        break;
                    case 9://无能狂怒
                        if (personName == "大保" && mood <= 30)
                            a = 9;
                        break;
                    case 11://停电
                            a = 11;
                        break;
                    case 12://飞来横祸
                            a = 12;
                        break;
                    case 13://自我怀疑
                        if (personName == "嗣yn" || personName == "大保")
                            a = 13;
                        break;
                    case 14://故障
                            a = 14;
                        break;
                    case 15://献计
                        /*目前实现方法未知，参见文档*/
                        break;
                    case 16://开摆
                        if (mood <= 30)
                            a = 16;
                        break;
                    default: break;

                }

            }
            Event = a;
        }
    }

    public void SetDelay(int turn, Attribute attr, int adjust, bool exist)
    {
        delayTurn.Add(turn);
        delayAttributeType.Add(attr);
        delayAttributeAdjust.Add(adjust);
        delayExist.Add(exist);
    }
}
