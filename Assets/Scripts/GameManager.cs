using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int turn;
    public int loadingInt;
    public int money;
    public int create;
    public Person1VINK p1VINK;
    public Person2Seeyn p2Seeyn;
    public Person3BigBoom p3BigBoom;
    public Person4Bony p4Bony;
    public List<Person> workPersons=new List<Person>();
    public Player player;
    public bool TextScreenChange;//trueʱtextscreen�Զ��ı�
    [Header("�¼�״̬")]
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
        TextScreenShow(99);
        turn = 1;
        workPersons.Add(p1VINK);
        workPersons.Add(p2Seeyn);
        workPersons.Add(p3BigBoom);
        workPersons.Add(p4Bony);
    }


    private void Update()
    {
        if(loadingInt>100)
            loadingInt = 100;
        if(loadingInt<0)
            loadingInt = 0;
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
        //�ж�Ŀ���Ƿ���

        p1VINK.NewPart();
        p2Seeyn.NewPart();
        p3BigBoom.NewPart();
        p4Bony.NewPart();
        player.NextPart();
        
    }
}
