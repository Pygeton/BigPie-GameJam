using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class State : MonoBehaviour
{
    public Text Money;
    public Text Create;

    private void Update()
    {
        Money.text = "总资金: "+GameManager.instance.money;
        Create.text = "创想力: " + GameManager.instance.create;
    }
}
