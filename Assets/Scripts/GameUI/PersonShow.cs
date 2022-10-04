using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonShow : MonoBehaviour
{
    private Person person;
    public Image bigHead;
    public Text personName;
    public Text personHealth;
    public Text personSpirit;
    public Text personMood;
    public Text exist;
    public Text eventSwitch;
    private void Update()
    {
        personHealth.text ="健康: "+ person.health.ToString();
        personSpirit.text = "精力: " + person.spirit.ToString();
        personMood.text = "心情: " + person.mood.ToString();
        if(person.Exist==false)
        {
            exist.text = "不在";
            eventSwitch.text = "";
        }
      
        if(person.Event!=0)
        {

            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Button>().interactable = true;
            exist.text = "";
            eventSwitch.text = "！";
        }

        if(person.Finish==true)
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Button>().interactable = false;
            eventSwitch.text = "";
        }

        if(GameManager.instance.tempPerson==person&&person.Finish)
        {
            GetComponent<Image>().color = new Color32(0, 225, 218, 225);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void SetPerson(Person p)
    {
        person = p;
        bigHead.sprite = p.bigHead;
        personName.text = person.personName;
    }

    public void Click()
    {
        GameManager.instance.TextScreenShow(person.Event, person);
    }
}
