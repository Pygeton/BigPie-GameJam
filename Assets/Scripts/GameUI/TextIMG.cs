using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextIMG : MonoBehaviour
{
    // Start is called before the first frame update
    public Image TextIMGShow;
    public List<Sprite> Sprites = new List<Sprite>();
    void Update()
    {
        if (GameManager.instance.tempPerson == null)
            TextIMGShow.sprite = Sprites[0];
        else if(GameManager.instance.tempPerson == GameManager.instance.p1VINK)
            TextIMGShow.sprite = Sprites[1];
        else if (GameManager.instance.tempPerson == GameManager.instance.p2Seeyn)
            TextIMGShow.sprite = Sprites[2];
        else if (GameManager.instance.tempPerson == GameManager.instance.p3BigBoom)
            TextIMGShow.sprite = Sprites[3];
        else if (GameManager.instance.tempPerson == GameManager.instance.p4Bony)
            TextIMGShow.sprite = Sprites[4];

    }
}
