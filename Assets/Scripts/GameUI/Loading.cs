using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{

    public Text day;
    public Text moa;
    public Slider loading;
    public Text loadingPrecent;


    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.pauseSwitch==false)
        {
            day.text = "第" + ((GameManager.instance.turn - 1) / 2 + 1) + "天";
            if (GameManager.instance.turn % 2 == 1)
                moa.text = "上午";
            else
                moa.text = "下午";

            loadingPrecent.text = GameManager.instance.loadingInt.ToString() + "%";

            loading.value = (float)GameManager.instance.loadingInt / (float)100;
        }
        
    }
}
