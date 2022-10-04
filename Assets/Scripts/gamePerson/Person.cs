using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public string personName;
    public Sprite bigHead;
    public int health;
    public int spirit;
    public int activity;
    public int Event;
    public bool Finish;
    public bool Exist;

    protected void Start()
    {
        Finish = false;
        Exist = true;
        Event = 1;
        //rollevent

    }

    // Update is called once per frame
    protected void Update()
    {
        if (Exist == false)
            Finish = true;

        if(Exist==true&&Event==0)
            Finish = true;
    }
}
