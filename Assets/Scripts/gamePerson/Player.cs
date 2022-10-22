using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerEvent;
    public bool finish;

    void Start()
    {

        NextPart();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickActivity()
    {
        GameManager.instance.TextScreenShow(PlayerEvent);
    }
    public void NextPart()
    {
        PlayerEvent = 1000;
        finish = false;

        //rollevent
        PRollEvent();



    }

    private void PRollEvent()
    {
            
        if(Koubot.Tool.Random.RandomTool.GenerateRandomInt(0,99)>30+(GameManager.instance.turn%4)*5)
        {
            PlayerEvent = 1000;
        }
        else
        {
            int a = 9999;
            while (a == 9999)
            {
                PlayerEvent = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1001, 1007);
                switch (PlayerEvent)
                {
                    case 1001:
                            a = 1001;
                        break;
                    case 1002:
                        foreach(var p in GameManager.instance.workPersons)
                        {
                            if (p.Exist == true && p.health <= 30)
                                a = 1002;
                        }
                        break;
                    case 1003:
                        foreach (var p in GameManager.instance.workPersons)
                        {
                            if (p.Exist == true && p.spirit <= 30)
                                a = 1003;
                        }
                        break;
                    case 1004:
                        foreach (var p in GameManager.instance.workPersons)
                        {
                            if (p.Exist == true && p.mood <= 30)
                                a = 1004;
                        }
                        break;
                    case 1005:
                        if (GameManager.instance.money<=100)
                            a = 1005;
                        break;
                    case 1006:
                        if (GameManager.instance.create >= 20)
                            a = 1006;
                        break;
                    case 1007:
                            a = 1007;
                        break;
                    default: break;
                }
            }

            PlayerEvent = a;
        }
            
    }
}