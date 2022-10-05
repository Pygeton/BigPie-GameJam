using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerEvent;
    public bool finish;
    void Start()
    {
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickActivity()
    {
        GameManager.instance.TextScreenShow(PlayerEvent);
    }
}
