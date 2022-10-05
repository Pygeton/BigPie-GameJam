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
    private void Finish()//当前人物完成事件处理
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
                        screenText.text = "结算完所有人员的事件后会开启活动按钮，点下一阶段推进日程。";
                    else
                        screenText.text = GameManager.instance.delayedShow[GameManager.instance.turn-1];
                    break;
                }
            case 1:
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "在开发途中突然感到肚子里翻江倒海，强烈的阵痛接连袭来，想必是吃坏肚子得了急性肠胃炎...";
                    buttons[0].SetText("吃点药顶一顶吧");
                    buttons[1].SetText("还是去看个医生吧");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E1B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E1B1);
                    break;
                }
            case 2:
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "感觉有些疲惫，注意力有些不集中...";
                    buttons[0].SetText("问题不大，继续干吧");
                    buttons[1].SetText("喝瓶咖啡顶一顶就完事");
                    buttons[2].SetText("还是休息一下好了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E2B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E2B1);
                    buttons[2].GetComponent<Button>().onClick.AddListener(E2B2);
                    break;
                }
            case 3://萎靡不振
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "感觉非常疲惫，完全无法集中注意力，可能眼睛一闭就要睡着了...";
                    buttons[0].SetText("喝多几瓶咖啡，能撑就撑");
                    buttons[1].SetText("也许该休息了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E3B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E3B1);
                    break;
                }
            case 4://不速之客
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "的手机响起，接通电话，原来是父母想要来自己所在的城市看望自己，但是开发任务很紧...";
                    buttons[0].SetText("抽点时间陪伴一下父母吧");
                    buttons[1].SetText("时间很紧，还是下次吧");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E4B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E4B1);
                    break;
                }
            case 5://紧急进修
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "认为自己的技术力捉急，陷入了开发的困难，也许他需要先停下来学习一下...";
                    buttons[0].SetText("抽点时间学习一下相关知识");
                    buttons[1].SetText("和开发组成员进行交流");
                    buttons[2].SetText("还是自己再思考一会好了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E5B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E5B1);
                    buttons[2].GetComponent<Button>().onClick.AddListener(E5B2);
                    break;
                }
                
            case 6://噩耗
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "在刷朋友圈的时间得知一则消息，他的朋友因身体原因于昨晚去世了...";
                    buttons[0].SetText("引以为戒，永远铭记");
                    buttons[1].SetText("约昔日共同的朋友去喝一杯吧");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E6B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E6B1);
                    break;
                }
                
            case 7://We gonna party！
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "收到了他朋友的一通电话，原来是他被邀请去参加一个派对，听着很有意思！";
                    buttons[0].SetText("蹦起来！");
                    buttons[1].SetText("还是别浪费时间了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E7B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E7B1);
                    break;
                }
                
            case 8://两眼一黑
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "的精神终究还是不堪重负，只见他两眼一黑，向后一倒，晕了过去...";
                    buttons[0].SetText("这下坏了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E8B0);
                    break;
                }
            case 9://无能狂怒
                {
                    screenText.text = "大保的开发遇到瓶颈，他非常恼火，越想越生气，然后一拳砸向了电脑！";
                    buttons[0].SetText("这一拳可砸错地方了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E9B0);
                    break;
                }
            case 10://猝死
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "突然感到自己的胸口非常难受，下一秒，他倒在了地上，再也没有起来...";
                    buttons[0].SetText("太突然了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E10B0);
                    break;
                }
            case 11://大停电
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "工作到一半，突然屏幕一黑，你确认了一下，发现整条街都停电了，这下麻了...";
                    buttons[0].SetText("这下啥都干不了了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E11B0);
                    if (GameManager.instance.tempPerson.personName == "公泥")
                    {
                        buttons[1].SetText("打开笔记本电脑");
                        buttons[1].GetComponent<Button>().onClick.AddListener(E11B1);
                    }
                    break;
                }
            case 12://飞来横祸
                screenText.text = "究竟是司机不长眼睛还是" + GameManager.instance.tempPerson.personName + "不看车这已经无从追究了，总之结果就是他被车撞了而且伤的还不轻，现在只能去医院了。";
                buttons[0].SetText("真是倒霉...");
                buttons[0].GetComponent<Button>().onClick.AddListener(E12B0);
                break;
            case 13://自我怀疑
                {
                    screenText.text = "人在精益求精的道路上是无止境的，所以这也许可以解释明明自己的画被很多人夸，但是却觉得自己很菜的现象。";
                    buttons[0].SetText("？吗的真是");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E13B0);
                    break;
                }
            case 14://故障
                screenText.text = GameManager.instance.tempPerson.personName + "的电脑突然蓝屏了，然后无论怎么重启都没有反应，这下如何解决呢...";
                buttons[0].SetText("送到电脑维修店进行维修（当前阶段无法进行开发）");
                buttons[1].SetText("花钱请人来维修一下");
                buttons[0].GetComponent<Button>().onClick.AddListener(E14B0);
                buttons[1].GetComponent<Button>().onClick.AddListener(E14B1);
                if (GameManager.instance.tempPerson.name == "VINK")
                {
                    buttons[2].SetText("自己拆开电脑看看");
                    buttons[2].GetComponent<Button>().onClick.AddListener(E14B2);
                }
                break;
            case 15://献计
                /*目前实现方法未知，参见文档*/
                break;
            case 16://开摆
                {
                    screenText.text = GameManager.instance.tempPerson.personName + "的心情非常糟糕，他不想干活了，他现在只想开摆。";
                    buttons[0].SetText("开摆！");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E16B0);
                    break;
                }
            case 17://学美术
                /*目前实现方法未知，参见文档*/
                break;
            case 18://心灵大师
                screenText.text = GameManager.instance.tempPerson.personName + "正处于开发的困难时期，正在这个时候，他发现电脑上有一则广告：”心灵大师特里斯科特，揭露你心中的疑惑，只要99！”";
                buttons[0].SetText("也许可以试着去咨询一下？");
                buttons[1].SetText("谁信这种东西啊");
                buttons[0].GetComponent<Button>().onClick.AddListener(E18B0);
                buttons[1].GetComponent<Button>().onClick.AddListener(E18B1);
                break;

            case 100://无事发生
                {
                    screenText.text = "什么事都没有发生，开发进度稳定！";
                    buttons[0].SetText("好耶！");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E100B0);
                    break;
                }
            case 1000://活动:无
                {
                    screenText.text = "测试player的finish是否变成true";
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1001://活动:线上会议
                {
                    screenText.text = "线上会议中，大家互相交流了自己在开发过程中遇到的问题并提出了自己的看法，确定了接下来的开发方向和思路，也许会对接下来的开发有帮助。";
                    foreach(var p in GameManager.instance.workPersons)
                    {
                        p.spirit -= 5;
                        GameManager.instance.create += 50;
                    }
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1002://活动:健身活动
                {
                    screenText.text = "在场的大家决定一起去户外做会运动，增强体质以应对接下来的挑战。";
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
            case 1003://活动:大保健
                {
                    screenText.text = "大家决定一起花钱去SPA做特惠大保健，放松身心。";
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
            case 1004://活动:看电影
                {
                    screenText.text = "有好兄弟带了免费电影票！大家决定一起去电影院看会电影，吃点东西。";
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
            case 1005://活动:集体兼职
                {
                    
                    screenText.text = "由于团队资金短缺，经过商讨，在场的大家决定去做2天兼职挣点外快。";
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
                    GameManager.instance.SetDelayedText(5, "芜湖！为团队带来了一笔巨款！");
                    GameManager.instance.player.finish = true;
                    break;
                }
            case 1006://活动:创意就是财富
                {
                    screenText.text = "有人看好我们的创意，是否换取点钱财？";
                    buttons[0].SetText("换！");
                    buttons[1].SetText("不换");
                    buttons[0].GetComponent<Button>().onClick.AddListener(A6B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(A6B1);
                    break;
                }
            default:
                break; 



        }
    }





    //——————————————————————————事件按钮——————————————————————————
    void E100B0()
    {
        Finish();
        screenText.text = "再接再厉！";
    }
    void E1B0()
    {
        GameManager.instance.tempPerson.spirit -= 30;
        GameManager.instance.tempPerson.health += 5;
        Finish();
        screenText.text = "你吃了一些黄连素，然后稍微休息了一下继续开始工作，虽然肠胃炎暂时缓解了，然而你倍感疲倦...（健康+5，精力-30）";
    }
    void E1B1()
    {
        GameManager.instance.tempPerson.Exist = false;//today
        GameManager.instance.tempPerson.spirit += 15;
        GameManager.instance.tempPerson.health += 30;
        Finish();
        screenText.text = "你去医院看了一下医生，医生给你开了一些药，并建议你好好休息。（今天无法再进行开发,健康+30，精力+15）";
    }
    void E2B0()
    {
        GameManager.instance.tempPerson.spirit -= 10;
        Finish();
        screenText.text = "虽然效率有所降低，但是问题不是很大，还是进度重要。（精力-10）";
    }
    void E2B1()
    {
        GameManager.instance.tempPerson.health -= 10;
        GameManager.instance.tempPerson.spirit += 25;
        Finish();
        screenText.text = "没有什么疲劳是不能靠咖啡解决的，尽管可能要让身体付出一点代价...（健康-10，精力+25）";
    }
    void E2B2()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.spirit += 25;
        Finish();
        screenText.text = "你稍微咪了一下眼小睡了一会，结果一睡就是半天，但是一觉醒来感觉神清气爽，好多了。（当前阶段无法再进行开发，精力+25）";
    }
    void E3B0()
    {
        GameManager.instance.tempPerson.health -= 25;
        GameManager.instance.tempPerson.spirit += 20;
        Finish();
        screenText.text = "一瓶咖啡不够那就多喝几瓶，只要能干活就行...（健康-25，精力+20）";
    }
    void E3B1()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.spirit += 20;
        Finish();
        screenText.text = "虽然好好休息了一下，然而你睡醒却感觉还是有些累。（当前阶段无法再进行开发，精力+20）";
    }
    void E4B0()
    {
        GameManager.instance.tempPerson.Exist = false;//nextday
        GameManager.instance.tempPerson.mood += 50;
        Finish();
        screenText.text = "长期在外，能和父母视频通话的时间都很少，更不要说陪在身边了，还是好好享受一下家人陪伴的感觉吧，开发任务稍后再做也没事。（第二天无法进行开发，心情+50）";
    }
    void E4B1()
    {
        GameManager.instance.tempPerson.mood -= 20;
        Finish();
        screenText.text = "你因为想全心全意把注意力集中在开发上而婉拒了父母，但是你很难不想念家人陪伴在身边的感觉，多少有些失落...（心情-20）";
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
                screenText.text = "你花了小半天时间静心学习了一番，现在你不但可以解决目前遇到的问题，而且还有了相关的知识储备。（当前阶段无法再进行开发，精力-10，团队创想力+20）";
                break;
            case 1:
                GameManager.instance.tempPerson.spirit -= 5;
                GameManager.instance.tempPerson.mood += 10;
                //img
                Finish();
                screenText.text = "你花了一点时间解决了当前遇到的问题，但是giligili的推广让你陶醉其中，不过就结果来说你还是挺快乐的。（当前阶段无法再进行开发，精力-5，团队创想力+5，心情+10）";
                break;
            case 2:
                GameManager.instance.tempPerson.spirit -= 10;
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "你发现自学也救不了你，你感到一知半解，你既没有解决问题也无法理解内在的原理，你感到很失落。（当前阶段无法再进行开发，精力-10，心情-20）";
                break;
        }
    }
    void E5B1()
    {
        //img
        Finish();
        screenText.text = "你在请教开发组成员的同时与他们交流了一下自己的想法，得到了一些灵感。（团队创想力+10）";
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
                screenText.text = "水滴石穿，你在冥思苦想许久后灵感涌现了上来，问题成功解决了！你为问题的解决而感到非常激动。（团队创想力+10，心情+25）";
                break;
            case 1:
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "你在埋头苦思许久后什么都想不出来，你感到非常烦躁...（心情-20）";
                break;
        }
    }
    void E6B0()
    {
        GameManager.instance.tempPerson.health += 5;
        GameManager.instance.tempPerson.mood -= 35;
        Finish();
        screenText.text = "你得知这则消息后非常悲痛，但是你还有任务要做，你唯一能做的就是铭记他，并且注意自己的身体，不要重蹈覆辙。（健康+5，心情-35）";
    }
    void E6B1()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.health -= 15;
        Finish();
        screenText.text = "你和曾经共同的朋友一起喝了一杯，虽然你们都很悲痛，然而觥筹交错，在和老友的叙旧和酒精的麻痹之下，你最终还是走了出来...大概吧。（当前阶段无法进行开发，健康-15）";
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
                screenText.text = "这个派对果然非同一般，你感到非常开心！至于开发，明天再说！（当前阶段无法再进行开发，精力-20，心情+30）";
                break;
            case 1:
                GameManager.instance.tempPerson.spirit -= 20;
                GameManager.instance.tempPerson.mood += 20;
                //img
                Finish();
                screenText.text = "你不但在派对上玩的非常开心，更重要的是你认识到了一位bsdn的知名博主！派对后，你加了他的微信，交流了许多想法，得到了一些建议，你感到自己的思维水平得到了提升。（当前阶段无法再进行开发，，团队创想力+20，精力-20，心情+20）";
                break;
            case 2:
                GameManager.instance.tempPerson.mood -= 20;
                Finish();
                screenText.text = "非常不巧，你在这场派对上遇到了曾经和你有过节的人。因为他的存在，你的心情非常糟糕...（当前阶段无法再进行开发，心情-20）";
                break;
        }
    }
    void E7B1()
    {
        GameManager.instance.tempPerson.mood -= 5;
        Finish();
        screenText.text = "你想了想，还是开发更重要一点，派对什么的下次再说吧。不过有点郁闷就是了。（心情-5）";
    }
    void E8B0()
    {
        GameManager.instance.tempPerson.Exist = false;//2round
        Finish();
        screenText.text = "你缓缓睁开眼睛，一看电脑，发现竟然过了整整一天，你感觉头晕目眩...（当前和下一阶段都不能再进行开发，健康-20）";
    }
    void E9B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        //money-500
        GameManager.instance.tempPerson.mood -= 10;
        Finish();
        screenText.text = "你回过神来才发现显示器已经被你一拳砸碎了，你现在不但什么都做不了，而且还要花钱买新显示器，心情更糟糕了...（当前阶段不能再进行开发，团队资金-500，心情-10）";
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
        screenText.text = "表面看上去这很突然，其实" + GameManager.instance.tempPerson.personName + "的身体状况早已是油尽灯枯了。虽然其他成员都很悲痛，然而开发还是要继续。多多注意自己的身体吧。（" + GameManager.instance.tempPerson.personName + "死亡，后续不能再进行开发，其他成员心情-10）";
    }
    void E11B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.mood -= 10;
        Finish();
        screenText.text = "虽然很烦躁，但是你除了等电来还能干啥呢？（当前阶段无法再进行开发，心情-10）";
    }
    void E11B1()
    {
        GameManager.instance.tempPerson.mood -= 5;
        Finish();
        screenText.text = "还好你还有一台笔记本电脑，连个热点同步一下也不是不能用，就是空调不能用了有点烦。（心情-5）";
    }
    void E12B0()
    {
        bool flag = false;//如果roll到的结果并非是当前状态可触发的，重roll
        while (!flag)
        {
            int result = UnityEngine.Random.Range(0, 5);
            switch (result)
            {
                case 0:
                    GameManager.instance.tempPerson.Exist = false;
                    GameManager.instance.tempPerson.health -= 20;
                    Finish();
                    screenText.text = "你的腿骨折了，还好这并不影响你的工作，大概吧。（当前阶段无法进行开发，健康-20）";
                    flag = true;
                    break;
                case 1:
                    GameManager.instance.tempPerson.Exist = false;//out
                    Finish();
                    screenText.text = "你的右手骨折了，这对于任何一个人来说都是毁灭性的。你不得不退出开发组了。（后续无法进行开发）";
                    flag = true;
                    break;
                case 2:
                    if (GameManager.instance.tempPerson.personName == "嗣yn"|| GameManager.instance.tempPerson.personName == "大保")
                    {
                        GameManager.instance.tempPerson.Exist = false;
                        GameManager.instance.tempPerson.health -= 20;
                        Finish();
                        screenText.text = "你的左手骨折了，不过还好单靠右手也勉强还能画画...吧。（当前阶段无法进行开发，健康-20）";
                        flag = true;
                        break;
                    }
                    else break;
                case 3:
                    if (GameManager.instance.tempPerson.personName == "VINK" || GameManager.instance.tempPerson.personName == "公泥")
                    {
                        GameManager.instance.tempPerson.Exist = false;//out
                        Finish();
                        screenText.text = "你的左手骨折了，然而只靠一只右手很难继续敲代码了，你不得不退出开发组了。（后续无法进行开发）";
                        flag = true;
                        break;
                    }
                    else break;
                case 4:
                    GameManager.instance.tempPerson.Exist = false;
                    //img
                    GameManager.instance.tempPerson.health -= 10;
                    Finish();
                    screenText.text = "虽然听着很扯，但是事实就是如此，你到医院进行了一些治疗后就没什么大碍了，而且这一下撞击使你灵感迸发！现在你感到许多问题都得到了解决！（当前阶段无法进行开发，健康-10，团队创造力+15）";
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
            screenText.text = "情绪波动乃人之常情，过一会就缓过来啦。（心情-10）";
        }
        else
        {
            GameManager.instance.tempPerson.Exist = false;
            Finish();
            screenText.text = "情绪波动乃人之常情，但是在心情低落时再来上那么一下就很难说了。也许你应该放下画笔好好放松一下。（当前阶段无法进行开发）";
        }
    }
    void E14B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        Finish();
        screenText.text = "还好电脑保修期还没过，你前往电脑店进行了一番维修之后，问题解决了，虽然比较耗时间就是了。（当前阶段无法进行开发）";
    }
    void E14B1()
    {
        //money-100
        Finish();
        screenText.text = "请人来维修是最快的选择，虽然要花点钱就是了。（团队资金-100）";
    }
    void E14B2()
    {
        GameManager.instance.tempPerson.spirit -= 10;
        Finish();
        screenText.text = "虽然自己拆比较费劲，但是还好这个情况对你来说并不难处理，你很快就解决了。（精力-10）";
    }
    /*E15的实现待定*/
    void E16B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        GameManager.instance.tempPerson.mood += 15;
        Finish();
        screenText.text = "你摆了半天，爽玩了最新最热的《乌蒙dx2088》，现在你感觉心情好了一些。（当前阶段无法进行开发，心情+15）";
    }
    /*E17的实现待定*/
    void E18B0()
    {
        GameManager.instance.tempPerson.Exist = false;
        int result = RandomTool.GenerateRandomInt(1, 100);
        if(result >= 70)
        {
            //img+20
            Finish();
            screenText.text = "大师果然名不虚传，他甚至没有询问就揭露了你的问题所在，而且经过一番指点，你的灵感如泉水一般涌现！（团队创造力+20）";
        }
        else if(result >= 40)
        {
            GameManager.instance.tempPerson.mood += 20;
            Finish();
            screenText.text = "尽管大师并没有完全解决你的问题，但是他的话术确实有一手，也确实揭露了你的一些困惑，你至少心情好了不少。（心情+20）";
        }
        else
        {
            GameManager.instance.tempPerson.mood -= 20;
            Finish();
            screenText.text = "这个所谓的大师就是个彻头彻尾的骗子，到头来他就是只会说一些空泛的话罢了，一点忙都帮不上。你觉得自己血亏，心情更加烦躁。（心情-20）";
        }
    }
    void E18B1()
    {
        Finish();
        screenText.text = "这种一眼丁假的东西谁信谁倒霉，有那时间不如想想怎么解决问题。";
    }

    void A6B0()
    {
        GameManager.instance.player.finish=true;
        Finish();
        screenText.text = "双方满意，双向奔赴(?)";
        GameManager.instance.create -= 100;
        GameManager.instance.money += 200;
    }
    void A6B1()
    {
        GameManager.instance.player.finish = true;
        Finish();
        screenText.text = "团队智慧的结晶怎么能随便换！大家不仅拒绝，还更加专注研究创意！";
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
