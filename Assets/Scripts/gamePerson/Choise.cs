using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Choise : MonoBehaviour
{


    public void SetText(string text)
    {
        gameObject.transform.GetChild(1).GetComponent<Text>().text = text;
        gameObject.SetActive(true);
    }

}
