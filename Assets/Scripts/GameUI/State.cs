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
        Money.text = "���ʽ�: "+GameManager.instance.money;
        Create.text = "������: " + GameManager.instance.create;
    }
}
