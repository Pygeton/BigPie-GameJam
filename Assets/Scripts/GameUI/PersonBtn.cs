using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PersonBtn : MonoBehaviour
{
    public List<PersonShow> PersonShows = new List<PersonShow>();
    // Start is called before the first frame update
    public Button activity;
    void Start()
    {
        PersonShows[0].SetPerson(GameManager.instance.p1VINK);
        PersonShows[1].SetPerson(GameManager.instance.p2Seeyn);
        PersonShows[2].SetPerson(GameManager.instance.p3BigBoom);
        PersonShows[3].SetPerson(GameManager.instance.p4Bony);
        activity.enabled = false;
        activity.interactable = false;
    }
    private void Update()
    {
        if(GameManager.instance.p1VINK.Finish==true&& GameManager.instance.p2Seeyn.Finish == true && GameManager.instance.p3BigBoom.Finish == true && GameManager.instance.p4Bony.Finish == true && GameManager.instance.player.finish == false && activity.enabled == false)
        {
            activity.enabled = true;
            activity.interactable = true;
        }
        else if(GameManager.instance.player.finish==true)
        {
            activity.enabled = false;
            activity.interactable = false;
        }
    }

}
