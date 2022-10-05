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
        int a = Koubot.Tool.Random.RandomTool.GenerateRandomInt(1000, 1001);
        PlayerEvent = a;
    }
}