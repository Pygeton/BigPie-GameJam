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
        //RollEvent();
        Event = 1;
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

    public void SetDelay(int turn, Attribute attr, int adjust, bool exist)
    {
        delayTurn.Add(turn);
        delayAttributeType.Add(attr);
        delayAttributeAdjust.Add(adjust);
        delayExist.Add(exist);
    }
}
