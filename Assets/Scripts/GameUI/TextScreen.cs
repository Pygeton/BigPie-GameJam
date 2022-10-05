using Koubot.Tool.Random;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScreen : MonoBehaviour
{
    public List<Choise> buttons = new List<Choise>();
    public Text screenText;
    public Button nextBtn;
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

        if(GameManager.instance.player.finish==true&&!nextBtn.gameObject.activeInHierarchy)
            nextBtn.gameObject.SetActive(true);
        if (GameManager.instance.player.finish == false && nextBtn.gameObject.activeInHierarchy)
            nextBtn.gameObject.SetActive(false);

    }

    private void HideAllBtns()
    {
        foreach (var b in buttons)
        {
            b.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            b.gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
            b.gameObject.SetActive(false);
        }
        nextBtn.gameObject.SetActive(false);
    }
    private void Finish()//��ǰ��������¼�����
    {
        HideAllBtns();
        if(GameManager.instance.tempPerson != null)
            GameManager.instance.tempPerson.Event = 0;
        else
            GameManager.instance.player.finish = true;
    }
    public void SetChoiseScreen()
    {
        HideAllBtns();

        switch (GameManager.instance.eventCode)
        {
            case 99:
                {
                    if (GameManager.instance.delayedShow[GameManager.instance.turn-1] == "")
                        screenText.text = "������������Ա���¼���Ὺ�����ť������һ�׶��ƽ��ճ̡�";
                    else
                        screenText.text = GameManager.instance.delayedShow[GameManager.instance.turn-1];
                    break;
                }
            case 1:
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "�ڿ���;��ͻȻ�е������﷭��������ǿ�ҵ���ʹ����Ϯ��������ǳԻ����ӵ��˼��Գ�θ��...";
                    buttons[0].SetText("�Ե�ҩ��һ����");
                    buttons[1].SetText("����ȥ����ҽ����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E1B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E1B1);
                    break;
                }
            case 2:
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "�о���Щƣ����ע������Щ������...";
                    buttons[0].SetText("���ⲻ�󣬼����ɰ�");
                    buttons[1].SetText("��ƿ���ȶ�һ��������");
                    buttons[2].SetText("������Ϣһ�º���");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E2B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E2B1);
                    buttons[2].GetComponent<Button>().onClick.AddListener(E2B2);
                    break;
                }
            case 3://ή�Ҳ���
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "�о��ǳ�ƣ������ȫ�޷�����ע�����������۾�һ�վ�Ҫ˯����...";
                    buttons[0].SetText("�ȶ༸ƿ���ȣ��ܳžͳ�");
                    buttons[1].SetText("Ҳ�����Ϣ��");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E3B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E3B1);
                    break;
                }
            case 4://����֮��
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "���ֻ����𣬽�ͨ�绰��ԭ���Ǹ�ĸ��Ҫ���Լ����ڵĳ��п����Լ������ǿ�������ܽ�...";
                    buttons[0].SetText("���ʱ�����һ�¸�ĸ��");
                    buttons[1].SetText("ʱ��ܽ��������´ΰ�");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E4B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E4B1);
                    break;
                }
            case 5://��������
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "��Ϊ�Լ��ļ�����׽���������˿��������ѣ�Ҳ������Ҫ��ͣ����ѧϰһ��...";
                    buttons[0].SetText("���ʱ��ѧϰһ�����֪ʶ");
                    buttons[1].SetText("�Ϳ������Ա���н���");
                    buttons[2].SetText("�����Լ���˼��һ�����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E5B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E5B1);
                    buttons[2].GetComponent<Button>().onClick.AddListener(E5B2);
                    break;
                }
                
            case 6://ج��
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "��ˢ����Ȧ��ʱ���֪һ����Ϣ����������������ԭ��������ȥ����...";
                    buttons[0].SetText("����Ϊ�䣬��Զ����");
                    buttons[1].SetText("Լ���չ�ͬ������ȥ��һ����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E6B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E6B1);
                    break;
                }
                
            case 7://We gonna party��
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "�յ��������ѵ�һͨ�绰��ԭ������������ȥ�μ�һ���ɶԣ����ź�����˼��";
                    buttons[0].SetText("��������");
                    buttons[1].SetText("���Ǳ��˷�ʱ����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E7B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E7B1);
                    break;
                }
                
            case 8://����һ��
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "�ľ����վ����ǲ����ظ���ֻ��������һ�ڣ����һ�������˹�ȥ...";
                    buttons[0].SetText("���»���");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E8B0);
                    break;
                }
            case 9://���ܿ�ŭ
                {
                    screenText.text = "�󱣵Ŀ�������ƿ�������ǳ��ջ�Խ��Խ������Ȼ��һȭ�����˵��ԣ�";
                    buttons[0].SetText("��һȭ���Ҵ�ط���");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E9B0);
                    break;
                }
            case 10://���
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "ͻȻ�е��Լ����ؿڷǳ����ܣ���һ�룬�������˵��ϣ���Ҳû������...";
                    buttons[0].SetText("̫ͻȻ��");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E10B0);
                    break;
                }
            case 11://��ͣ��
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "������һ�룬ͻȻ��Ļһ�ڣ���ȷ����һ�£����������ֶ�ͣ���ˣ���������...";
                    buttons[0].SetText("����ɶ���ɲ�����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E11B0);
                    if (GameManager.instance.tempPerson.personName == "����")
                    {
                        buttons[1].SetText("�򿪱ʼǱ�����");
                        buttons[1].GetComponent<Button>().onClick.AddListener(E11B1);
                    }
                    break;
                }
            case 12://�������
                screenText.text = "������˾�������۾�����" + GameManager.instance.tempPerson.personName + "���������Ѿ��޴�׷���ˣ���֮�������������ײ�˶����˵Ļ����ᣬ����ֻ��ȥҽԺ�ˡ�";
                buttons[0].SetText("���ǵ�ù...");
                buttons[0].GetComponent<Button>().onClick.AddListener(E12B0);
                break;
            case 13://���һ���
                {
                    screenText.text = "���ھ����󾫵ĵ�·������ֹ���ģ�������Ҳ����Խ��������Լ��Ļ����ܶ��˿䣬����ȴ�����Լ��ܲ˵�����";
                    buttons[0].SetText("���������");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E13B0);
                    break;
                }
            case 14://����
                screenText.text = GameManager.instance.tempPerson.personName + "�ĵ���ͻȻ�����ˣ�Ȼ��������ô������û�з�Ӧ��������ν����...";
                buttons[0].SetText("�͵�����ά�޵����ά�ޣ���ǰ�׶��޷����п�����");
                buttons[1].SetText("��Ǯ������ά��һ��");
                buttons[0].GetComponent<Button>().onClick.AddListener(E14B0);
                buttons[1].GetComponent<Button>().onClick.AddListener(E14B1);
                if (GameManager.instance.tempPerson.name == "VINK")
                {
                    buttons[2].SetText("�Լ��𿪵��Կ���");
                    buttons[2].GetComponent<Button>().onClick.AddListener(E14B2);
                }
                break;
            case 15://�׼�
                /*Ŀǰʵ�ַ���δ֪���μ��ĵ�*/
                break;
            case 16://����
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "������ǳ���⣬������ɻ��ˣ�������ֻ�뿪�ڡ�";
                    buttons[0].SetText("���ڣ�");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E16B0);
                    break;
                }
            case 17://ѧ����
                /*Ŀǰʵ�ַ���δ֪���μ��ĵ�*/
                break;
            case 18://�����ʦ
                screenText.text = GameManager.instance.tempPerson.personName + "�����ڿ���������ʱ�ڣ��������ʱ�������ֵ�������һ���棺�������ʦ����˹���أ���¶�����е��ɻ�ֻҪ99����";
                buttons[0].SetText("Ҳ���������ȥ��ѯһ�£�");
                buttons[1].SetText("˭�����ֶ�����");
                buttons[0].GetComponent<Button>().onClick.AddListener(E18B0);
                buttons[1].GetComponent<Button>().onClick.AddListener(E18B1);
                break;

            case 100://���·���
                {
                    screenText.text = "ʲô�¶�û�з��������������ȶ���";
                    buttons[0].SetText("��Ү��");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E100B0);
                    break;
                }
            case 1000://�:��
                {
                    screenText.text = "����player��finish�Ƿ���true";
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1001://�:���ϻ���
                {
                    screenText.text = "���ϻ����У���һ��ཻ�����Լ��ڿ������������������Ⲣ������Լ��Ŀ�����ȷ���˽������Ŀ��������˼·��Ҳ���Խ������Ŀ����а�����";
                    foreach(var p in GameManager.instance.workPersons)
                    {
                        p.spirit -= 5;
                        GameManager.instance.create += 50;
                    }
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1002://�:����
                {
                    screenText.text = "�ڳ��Ĵ�Ҿ���һ��ȥ���������˶�����ǿ������Ӧ�Խ���������ս��";
                    foreach (var p in GameManager.instance.workPersons)
                    {
                        if(p.Exist==true)
                        {
                            p.health += 25;
                            p.spirit -= 20;
                        }                     
                    }
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1003://�:�󱣽�
                {
                    screenText.text = "��Ҿ���һ��ǮȥSPA���ػݴ󱣽����������ġ�";
                    foreach (var p in GameManager.instance.workPersons)
                    {
                        if (p.Exist == true)
                        {
                            p.health += 10;
                            p.spirit += 20;
                            GameManager.instance.money -= 20;
                        }
                      
                       
                    }
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1004://�:����Ӱ
                {
                    screenText.text = "�к��ֵܴ�����ѵ�ӰƱ����Ҿ���һ��ȥ��ӰԺ�����Ӱ���Ե㶫����";
                    foreach (var p in GameManager.instance.workPersons)
                    {
                        if (p.Exist == true)
                        {
                            p.health += 10;
                            p.spirit += 20;                          
                        }
                    }
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1005://�:�����ְ
                {
                    
                    screenText.text = "�����Ŷ��ʽ��ȱ���������֣��ڳ��Ĵ�Ҿ���ȥ��2���ְ������졣";
                    foreach (var p in GameManager.instance.workPersons)
                    {
                        if (p.Exist == true)
                        {
                            p.spirit -= 30;
                            for(int i= 0;i<4;i++)
                            {
                                p.SetDelay(i,Attribute.Null,0,false);
                            }
                            p.SetDelay(5,Attribute.Money,150,true);

                        }
                    }
                    GameManager.instance.SetDelayedText(5, "�ߺ���Ϊ�ŶӴ�����һ�ʾ޿");
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1006://�:������ǲƸ�
                {
                    screenText.text = "���˿������ǵĴ��⣬�Ƿ�ȡ��Ǯ�ƣ�";
                    buttons[0].SetText("����");
                    buttons[1].SetText("����");
                    buttons[0].GetComponent<Button>().onClick.AddListener(A6B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(A6B1);
                    break;
                }
            default:
                break; 



        }
    }





    //�����������������������������������������������������¼���ť����������������������������������������������������
    void E100B0()
    {
        Finish();
        screenText.text = "�ٽ�������";
    }
    void E1B0()
    {
        GameManager.instance.tempPerson.spirit -= 30;
        GameManager.instance.tempPerson.health += 5;
        Finish();
        screenText.text = "�����һЩ�����أ�Ȼ����΢��Ϣ��һ�¼�����ʼ��������Ȼ��θ����ʱ�����ˣ�Ȼ���㱶��ƣ��...������+5������-30��";
    }
    void E1B1()
    {
        GameManager.instance.tempPerson.Exist = false;//today
        GameManager.instance.tempPerson.spirit += 15;
        GameManager.instance.tempPerson.health += 30;
        Finish();
        screenText.text = "��ȥҽԺ����һ��ҽ����ҽ�����㿪��һЩҩ����������ú���Ϣ���������޷��ٽ��п���,����+30������+15��";
    }
    void E2B0()
    {
        GameManager.instance.tempPerson.spirit -= 10;
        Finish();
        screenText.text = "��ȻЧ���������ͣ��������ⲻ�Ǻܴ󣬻��ǽ�����Ҫ��������-10��";
    }
    void E2B1()
    {
        GameManager.instance.tempPerson.health -= 10;
        GameManager.instance.tempPerson.spirit += 25;
        Finish();
        screenText.text = "û��ʲôƣ���ǲ��ܿ����Ƚ���ģ����ܿ���Ҫ�����帶��һ�����...������-10������+25��";
    }
    void E2B2()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.spirit += 25;
        Finish();
        screenText.text = "����΢����һ����С˯��һ�ᣬ���һ˯���ǰ��죬����һ�������о�������ˬ���ö��ˡ�����ǰ�׶��޷��ٽ��п���������+25��";
    }
    void E3B0()
    {
        GameManager.instance.tempPerson.health -= 25;
        GameManager.instance.tempPerson.spirit += 20;
        Finish();
        screenText.text = "һƿ���Ȳ����ǾͶ�ȼ�ƿ��ֻҪ�ܸɻ����...������-25������+20��";
    }
    void E3B1()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.spirit += 20;
        Finish();
        screenText.text = "��Ȼ�ú���Ϣ��һ�£�Ȼ����˯��ȴ�о�������Щ�ۡ�����ǰ�׶��޷��ٽ��п���������+20��";
    }
    void E4B0()
    {
        GameManager.instance.tempPerson.Exist = false;//nextday
        GameManager.instance.tempPerson.mood += 50;
        Finish();
        screenText.text = "�������⣬�ܺ͸�ĸ��Ƶͨ����ʱ�䶼���٣�����Ҫ˵��������ˣ����Ǻú�����һ�¼������ĸо��ɣ����������Ժ�����Ҳû�¡����ڶ����޷����п���������+50��";
    }
    void E4B1()
    {
        GameManager.instance.tempPerson.mood -= 20;
        Finish();
        screenText.text = "����Ϊ��ȫ��ȫ���ע���������ڿ����϶�����˸�ĸ����������Ѳ���������������ߵĸо���������Щʧ��...������-20��";
    }
    void E5B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        int result = UnityEngine.Random.Range(0, 3);
        switch (result)
        {
            case 0:
                GameManager.instance.tempPerson.spirit -= 10;
                //img
                Finish();
                screenText.text = "�㻨��С����ʱ�侲��ѧϰ��һ���������㲻�����Խ��Ŀǰ���������⣬���һ�������ص�֪ʶ����������ǰ�׶��޷��ٽ��п���������-10���ŶӴ�����+20��";
                break;
            case 1:
                GameManager.instance.tempPerson.spirit -= 5;
                GameManager.instance.tempPerson.mood += 10;
                //img
                Finish();
                screenText.text = "�㻨��һ��ʱ�����˵�ǰ���������⣬����giligili���ƹ������������У������ͽ����˵�㻹��ͦ���ֵġ�����ǰ�׶��޷��ٽ��п���������-5���ŶӴ�����+5������+10��";
                break;
            case 2:
                GameManager.instance.tempPerson.spirit -= 10;
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "�㷢����ѧҲ�Ȳ����㣬��е�һ֪��⣬���û�н������Ҳ�޷�������ڵ�ԭ����е���ʧ�䡣����ǰ�׶��޷��ٽ��п���������-10������-20��";
                break;
        }
    }
    void E5B1()
    {
        //img
        Finish();
        screenText.text = "������̿������Ա��ͬʱ�����ǽ�����һ���Լ����뷨���õ���һЩ��С����ŶӴ�����+10��";
    }
    void E5B2()
    {
        int result = UnityEngine.Random.Range(0, 2);
        switch (result)
        {
            case 0:
                GameManager.instance.tempPerson.mood += 25;
                //img
                Finish();
                screenText.text = "ˮ��ʯ��������ڤ˼������ú����ӿ��������������ɹ�����ˣ���Ϊ����Ľ�����е��ǳ����������ŶӴ�����+10������+25��";
                break;
            case 1:
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "������ͷ��˼��ú�ʲô���벻��������е��ǳ�����...������-20��";
                break;
        }
    }
    void E6B0()
    {
        GameManager.instance.tempPerson.health += 5;
        GameManager.instance.tempPerson.mood -= 35;
        Finish();
        screenText.text = "���֪������Ϣ��ǳ���ʹ�������㻹������Ҫ������Ψһ�����ľ���������������ע���Լ������壬��Ҫ�ص����ޡ�������+5������-35��";
    }
    void E6B1()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.health -= 15;
        Finish();
        screenText.text = "���������ͬ������һ�����һ������Ȼ���Ƕ��ܱ�ʹ��Ȼ�����ｻ���ں����ѵ���ɺ;ƾ������֮�£������ջ������˳���...��Űɡ�����ǰ�׶��޷����п���������-15��";
    }
    void E7B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        int result = UnityEngine.Random.Range(0, 3);
        switch (result)
        {
            case 0:
                GameManager.instance.tempPerson.spirit -= 20;
                GameManager.instance.tempPerson.mood += 30;
                Finish();
                screenText.text = "����ɶԹ�Ȼ��ͬһ�㣬��е��ǳ����ģ����ڿ�����������˵������ǰ�׶��޷��ٽ��п���������-20������+30��";
                break;
            case 1:
                GameManager.instance.tempPerson.spirit -= 20;
                GameManager.instance.tempPerson.mood += 20;
                //img
                Finish();
                screenText.text = "�㲻�����ɶ�����ķǳ����ģ�����Ҫ��������ʶ����һλbsdn��֪���������ɶԺ����������΢�ţ�����������뷨���õ���һЩ���飬��е��Լ���˼άˮƽ�õ�������������ǰ�׶��޷��ٽ��п��������ŶӴ�����+20������-20������+20��";
                break;
            case 2:
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "�ǳ����ɣ������ⳡ�ɶ������������������й��ڵ��ˡ���Ϊ���Ĵ��ڣ��������ǳ����...����ǰ�׶��޷��ٽ��п���������-20��";
                break;
        }
    }
    void E7B1()
    {
        GameManager.instance.tempPerson.mood -= 5;
        Finish();
        screenText.text = "�������룬���ǿ�������Ҫһ�㣬�ɶ�ʲô���´���˵�ɡ������е����ƾ����ˡ�������-5��";
    }
    void E8B0()
    {
        GameManager.instance.tempPerson.Exist = false;//2round
        Finish();
        screenText.text = "�㻺�������۾���һ�����ԣ����־�Ȼ��������һ�죬��о�ͷ��Ŀѣ...����ǰ����һ�׶ζ������ٽ��п���������-20��";
    }
    void E9B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        //money-500
        GameManager.instance.tempPerson.mood -= 10;
        Finish();
        screenText.text = "��ع������ŷ�����ʾ���Ѿ�����һȭ�����ˣ������ڲ���ʲô�������ˣ����һ�Ҫ��Ǯ������ʾ��������������...����ǰ�׶β����ٽ��п������Ŷ��ʽ�-500������-10��";
    }
    void E10B0()
    {
        GameManager.instance.tempPerson.runAway = true;//out
        //othermood-10
       foreach(var p in GameManager.instance.workPersons)
        {
            p.mood -= 10;
        }
        Finish();
        screenText.text = "���濴��ȥ���ͻȻ����ʵ" + GameManager.instance.tempPerson.personName + "������״���������;��ƿ��ˡ���Ȼ������Ա���ܱ�ʹ��Ȼ����������Ҫ���������ע���Լ�������ɡ���" + GameManager.instance.tempPerson.personName + "���������������ٽ��п�����������Ա����-10��";
    }
    void E11B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.mood -= 10;
        Finish();
        screenText.text = "��Ȼ�ܷ��꣬��������˵ȵ������ܸ�ɶ�أ�����ǰ�׶��޷��ٽ��п���������-10��";
    }
    void E11B1()
    {
        GameManager.instance.tempPerson.mood -= 5;
        Finish();
        screenText.text = "�����㻹��һ̨�ʼǱ����ԣ������ȵ�ͬ��һ��Ҳ���ǲ����ã����ǿյ����������е㷳��������-5��";
    }
    void E12B0()
    {
        bool flag = false;//���roll���Ľ�������ǵ�ǰ״̬�ɴ����ģ���roll
        while (!flag)
        {
            int result = UnityEngine.Random.Range(0, 5);
            switch (result)
            {
                case 0:
                    GameManager.instance.tempPerson.Exist = false;
                    GameManager.instance.tempPerson.health -= 20;
                    Finish();
                    screenText.text = "����ȹ����ˣ������Ⲣ��Ӱ����Ĺ�������Űɡ�����ǰ�׶��޷����п���������-20��";
                    flag = true;
                    break;
                case 1:
                    GameManager.instance.tempPerson.Exist = false;//out
                    Finish();
                    screenText.text = "������ֹ����ˣ�������κ�һ������˵���ǻ����Եġ��㲻�ò��˳��������ˡ��������޷����п�����";
                    flag = true;
                    break;
                case 2:
                    if (GameManager.instance.tempPerson.personName == "��yn"|| GameManager.instance.tempPerson.personName == "��")
                    {
                        GameManager.instance.tempPerson.Exist = false;
                        GameManager.instance.tempPerson.health -= 20;
                        Finish();
                        screenText.text = "������ֹ����ˣ��������õ�������Ҳ��ǿ���ܻ���...�ɡ�����ǰ�׶��޷����п���������-20��";
                        flag = true;
                        break;
                    }
                    else break;
                case 3:
                    if (GameManager.instance.tempPerson.personName == "VINK" || GameManager.instance.tempPerson.personName == "����")
                    {
                        GameManager.instance.tempPerson.Exist = false;//out
                        Finish();
                        screenText.text = "������ֹ����ˣ�Ȼ��ֻ��һֻ���ֺ��Ѽ����ô����ˣ��㲻�ò��˳��������ˡ��������޷����п�����";
                        flag = true;
                        break;
                    }
                    else break;
                case 4:
                    GameManager.instance.tempPerson.Exist = false;
                    //img
                    GameManager.instance.tempPerson.health -= 10;
                    Finish();
                    screenText.text = "��Ȼ���źܳ���������ʵ������ˣ��㵽ҽԺ������һЩ���ƺ��ûʲô���ˣ�������һ��ײ��ʹ����бŷ���������е�������ⶼ�õ��˽��������ǰ�׶��޷����п���������-10���ŶӴ�����+15��";
                    break;
            }
        }
    }
    void E13B0()
    {
        if (GameManager.instance.tempPerson.mood > 30)
        {
            GameManager.instance.tempPerson.mood -= 10;
            Finish();
            screenText.text = "������������֮���飬��һ��ͻ���������������-10��";
        }
        else
        {
            GameManager.instance.tempPerson.Exist = false;
            Finish();
            screenText.text = "������������֮���飬�������������ʱ��������ôһ�¾ͺ���˵�ˡ�Ҳ����Ӧ�÷��»��ʺú÷���һ�¡�����ǰ�׶��޷����п�����";
        }
    }
    void E14B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        Finish();
        screenText.text = "���õ��Ա����ڻ�û������ǰ�����Ե������һ��ά��֮���������ˣ���Ȼ�ȽϺ�ʱ������ˡ�����ǰ�׶��޷����п�����";
    }
    void E14B1()
    {
        //money-100
        Finish();
        screenText.text = "������ά��������ѡ����ȻҪ����Ǯ�����ˡ����Ŷ��ʽ�-100��";
    }
    void E14B2()
    {
        GameManager.instance.tempPerson.spirit -= 10;
        Finish();
        screenText.text = "��Ȼ�Լ���ȽϷѾ������ǻ���������������˵�����Ѵ�����ܿ�ͽ���ˡ�������-10��";
    }
    /*E15��ʵ�ִ���*/
    void E16B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.mood += 15;
        Finish();
        screenText.text = "����˰��죬ˬ�����������ȵġ�����dx2088����������о��������һЩ������ǰ�׶��޷����п���������+15��";
    }
    /*E17��ʵ�ִ���*/
    void E18B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        int result = RandomTool.GenerateRandomInt(1, 100);
        if(result >= 70)
        {
            //img+20
            Finish();
            screenText.text = "��ʦ��Ȼ�����鴫��������û��ѯ�ʾͽ�¶������������ڣ����Ҿ���һ��ָ�㣬��������Ȫˮһ��ӿ�֣����ŶӴ�����+20��";
        }
        else if(result >= 40)
        {
            GameManager.instance.tempPerson.mood += 20;
            Finish();
            screenText.text = "���ܴ�ʦ��û����ȫ���������⣬�������Ļ���ȷʵ��һ�֣�Ҳȷʵ��¶�����һЩ����������������˲��١�������+20��";
        }
        else
        {
            GameManager.instance.tempPerson.mood -= 20;
            Finish();
            screenText.text = "�����ν�Ĵ�ʦ���Ǹ���ͷ��β��ƭ�ӣ���ͷ��������ֻ��˵һЩ�շ��Ļ����ˣ�һ��æ���ﲻ�ϡ�������Լ�Ѫ����������ӷ��ꡣ������-20��";
        }
    }
    void E18B1()
    {
        Finish();
        screenText.text = "����һ�۶��ٵĶ���˭��˭��ù������ʱ�䲻��������ô������⡣";
    }

    void A6B0()
    {
        GameManager.instance.player.finish=true;
        Finish();
        screenText.text = "˫�����⣬˫�򱼸�(?)";
        GameManager.instance.create -= 100;
        GameManager.instance.money += 200;
    }
    void A6B1()
    {
        GameManager.instance.player.finish = true;
        Finish();
        screenText.text = "�Ŷ��ǻ۵Ľᾧ��ô����㻻����Ҳ����ܾ���������רע�о����⣡";
        int a = 0;
        foreach(var p in GameManager.instance.workPersons)
        {
            if(p.Exist==true)
            {
                a++;
                p.spirit += 10;
            }
            if(a==4)
            {
                GameManager.instance.create += 50;
            }
        }
    }
}
