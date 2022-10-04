using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScreen : MonoBehaviour
{
    public List<Choise> buttons = new List<Choise>();
    public Text ScreanText;
    public Button NextBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.TextScreenChange==true)
        {
            SetChoiseScreen();
            GameManager.instance.TextScreenChange=false;
        }
    }

    private void HideAllBtns()
    {
        foreach (var b in buttons)
        {
            b.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            b.gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
            b.gameObject.SetActive(false);
        }
        NextBtn.gameObject.SetActive(false);
    }
    public void SetChoiseScreen()
    {
        
        HideAllBtns();
        if (GameManager.instance.eventCode==99)
        {
            ScreanText.text = "������������Ա���¼���Ὺ�����ť������һ�׶��ƽ��ճ̡�";                    
        }




        else if (GameManager.instance.eventCode == 1)
        {
            ScreanText.text = "����һ��";

            buttons[0].SetText("��10����");
            buttons[0].GetComponent<Button>().onClick.AddListener(Event1Button0);
        }       



        else if (GameManager.instance.eventCode == 2)
        {
            ScreanText.text = "��������";

        }
    }


    


    //�����������������������������������������������������¼���ť����������������������������������������������������
    public void Event1Button0()
    {
        GameManager.instance.tempPerson.activity += 10;
        GameManager.instance.tempPerson.Event = 0;
        HideAllBtns();
        ScreanText.text = "��֪��Ϊʲô��������ù���������������Zzzzzz��";
    }
}
