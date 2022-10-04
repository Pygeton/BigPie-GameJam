using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Morning,Afternoon}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public State state;
    public Person1VINK p1VINK;
    public Person2Seeyn p2Seeyn;
    public Person3BigBoom p3BigBoom;
    public Person4Bony p4Bony;
    public bool TextScreenChange;//true时textscreen自动改变
    [Header("事件状态")]
    public int eventCode;
    public Person tempPerson;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }
    public void Start()
    {
        SetMorning();
    }








    public void TextScreenShow(int a,Person p)//更新屏幕
    {
        eventCode = a;
        tempPerson = p;
        TextScreenChange = true;
    }
    public void TextScreenShow(int a)//更新屏幕
    {
        eventCode = a;
        tempPerson = null;
        TextScreenChange = true;
    }

    public void SetMorning()
    {
        state = State.Morning;
        TextScreenShow(99);
        
    }
}
