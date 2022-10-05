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
            int a = 9999;
            while (a == 9999)
            {
                PlayerEvent = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1000,1001);
            switch (PlayerEvent)
               {
                case 1000:
                        a = 1000;
                    break;
                case 1001:
                    if (GameManager.instance.p1VINK.Exist==true)
                        a = 1001;
                    break;
                default:break;
                }
            }
                
            PlayerEvent = a;
    }
}