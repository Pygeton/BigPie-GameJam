using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScreen : MonoBehaviour
{
    public List<Choise> buttons = new List<Choise>();
    public Text screenText;
    public Button nextBtn;
    public Person currentPerson;
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
        if(currentPerson!=null)
            currentPerson.Event = 0;
        else
            GameManager.instance.player.finish = true;
    }
    public void SetChoiseScreen()
    {
        currentPerson = GameManager.instance.tempPerson;//当前人物
        HideAllBtns();
        bool rollFlag = false;//随机标志符，true为roll到的事件符合条件，否则不符合重roll
        bool eventFlag = false;//事件标志符，true则将有事件发生，false则无事发生
        if (UnityEngine.Random.Range(0, 100) < 50)
        {
            eventFlag = true;
        }
        else
        {
            GameManager.instance.eventCode = 100;
        }
        if (GameManager.instance.eventCode == 99)//提示
        {
            screenText.text = "结算完所有人员的事件后会开启活动按钮，点下一阶段推进日程。";
            rollFlag = true;
        }
        else if(GameManager.instance.eventCode == 100)//无事发生
        {
            screenText.text = "什么事都没有发生，开发进度稳定！";
            buttons[0].SetText("好耶！");
            buttons[0].GetComponent<Button>().onClick.AddListener(E100B0);
            rollFlag = true;
        }
        while (!rollFlag)
        {
            if (eventFlag)
            {
                GameManager.instance.eventCode = UnityEngine.Random.Range(1, 17);
            }
            switch (GameManager.instance.eventCode)
            {
                case 1://翻江倒海
                    if (currentPerson.health <= 50)
                    {
                        screenText.text = currentPerson.personName + "在开发途中突然感到肚子里翻江倒海，强烈的阵痛接连袭来，想必是吃坏肚子得了急性肠胃炎...";
                        buttons[0].SetText("吃点药顶一顶吧（健康+5，精力-30）");
                        buttons[1].SetText("还是去看个医生吧（今天无法再进行开发,健康+30，精力+15）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E1B0);
                        buttons[1].GetComponent<Button>().onClick.AddListener(E1B1);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 2://虚弱
                    if (currentPerson.spirit <= 30)
                    {
                        screenText.text = currentPerson.personName + "感觉有些疲惫，注意力有些不集中...";
                        buttons[0].SetText("问题不大，继续干吧（精力-10）");
                        buttons[1].SetText("喝瓶咖啡顶一顶就完事（健康-10，精力+25）");
                        buttons[2].SetText("还是休息一下好了（当前阶段无法再进行开发，精力+25）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E2B0);
                        buttons[1].GetComponent<Button>().onClick.AddListener(E2B1);
                        buttons[2].GetComponent<Button>().onClick.AddListener(E2B2);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 3://萎靡不振
                    if (currentPerson.spirit <= 10)
                    {
                        screenText.text = currentPerson.personName + "感觉非常疲惫，完全无法集中注意力，可能眼睛一闭就要睡着了...";
                        buttons[0].SetText("喝多几瓶咖啡，能撑就撑（健康-25，精力+20）");
                        buttons[1].SetText("也许该休息了（当前阶段无法再进行开发，精力+20）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E3B0);
                        buttons[1].GetComponent<Button>().onClick.AddListener(E3B1);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 4://不速之客
                    screenText.text = currentPerson.personName + "的手机响起，接通电话，原来是父母想要来自己所在的城市看望自己，但是开发任务很紧...";
                    buttons[0].SetText("抽点时间陪伴一下父母吧（第二天无法进行开发，心情+50）");
                    buttons[1].SetText("时间很紧，还是下次吧（心情-20）");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E4B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E4B1);
                    rollFlag = true;
                    break;
                case 5://紧急进修
                    screenText.text = currentPerson.personName + "认为自己的技术力捉急，陷入了开发的困难，也许他需要先停下来学习一下...";
                    buttons[0].SetText("抽点时间学习一下相关知识");
                    buttons[1].SetText("和开发组成员进行交流");
                    buttons[2].SetText("还是自己再思考一会好了");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E5B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E5B1);
                    buttons[2].GetComponent<Button>().onClick.AddListener(E5B2);
                    rollFlag = true;
                    break;
                case 6://噩耗
                    screenText.text = currentPerson.personName + "在刷朋友圈的时间得知一则消息，他的朋友因身体原因于昨晚去世了...";
                    buttons[0].SetText("引以为戒，永远铭记（健康+5，心情-35）");
                    buttons[1].SetText("约昔日共同的朋友去喝一杯吧（当前阶段无法进行开发，健康-15）");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E6B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E6B1);
                    rollFlag = true;
                    break;
                case 7://We gonna party！
                    screenText.text = currentPerson.personName + "收到了他朋友的一通电话，原来是他被邀请去参加一个派对，听着很有意思！";
                    buttons[0].SetText("蹦起来！");
                    buttons[1].SetText("还是别浪费时间了（心情-5）");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E7B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E7B1);
                    rollFlag = true;
                    break;
                case 8://两眼一黑
                    if (currentPerson.mood <= 0)
                    {
                        screenText.text = currentPerson.personName + "的精神终究还是不堪重负，只见他两眼一黑，向后一倒，晕了过去...";
                        buttons[0].SetText("这下坏了（当前和下一阶段都不能再进行开发，健康-20）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E8B0);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 9://无能狂怒
                    if (currentPerson.personName == "大保" && currentPerson.mood <= 30)
                    {
                        screenText.text = "大保的开发遇到瓶颈，他非常恼火，越想越生气，然后一拳砸向了电脑！";
                        buttons[0].SetText("这一拳可砸错地方了（当前阶段不能再进行开发，团队资金-500，心情-10）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E9B0);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 10://猝死
                    if (currentPerson.health <= 0)
                    {
                        screenText.text = currentPerson.personName + "突然感到自己的胸口非常难受，下一秒，他倒在了地上，再也没有起来...";
                        buttons[0].SetText("太突然了（" + currentPerson.personName + "死亡，后续不能再进行开发，其他成员心情-10）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E10B0);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 11://大停电
                    screenText.text = currentPerson.personName + "工作到一半，突然屏幕一黑，你确认了一下，发现整条街都停电了，这下麻了...";
                    buttons[0].SetText("这下啥都干不了了（当前阶段无法再进行开发，心情-10）");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E11B0);
                    if (currentPerson.personName == "公泥")
                    {
                        buttons[1].SetText("打开笔记本电脑（心情-5）");
                        buttons[1].GetComponent<Button>().onClick.AddListener(E11B1);
                    }
                    rollFlag = true;
                    break;
                case 12://飞来横祸
                    screenText.text = "究竟是司机不长眼睛还是" + currentPerson.personName + "不看车这已经无从追究了，总之结果就是他被车撞了而且伤的还不轻，现在只能去医院了。";
                    buttons[0].SetText("真是倒霉...");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E12B0);
                    rollFlag = true;
                    break;
                case 13://自我怀疑
                    if (currentPerson.personName == "嗣yn" || currentPerson.personName == "大保")
                    {
                        screenText.text = "人在精益求精的道路上是无止境的，所以这也许可以解释明明自己的画被很多人夸，但是却觉得自己很菜的现象。";
                        buttons[0].SetText("？吗的真是");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E13B0);
                        rollFlag = true;
                        break;
                    }
                    else break;
                case 14://故障
                    screenText.text = currentPerson.personName + "的电脑突然蓝屏了，然后无论怎么重启都没有反应，这下如何解决呢...";
                    buttons[0].SetText("送到电脑维修店进行维修（当前阶段无法进行开发）");
                    buttons[1].SetText("花钱请人来维修一下（团队资金-100）");
                    buttons[0].GetComponent<Button>().onClick.AddListener(E14B0);
                    buttons[1].GetComponent<Button>().onClick.AddListener(E14B1);
                    if(currentPerson.name == "VINK")
                    {
                        buttons[2].SetText("自己拆开电脑看看（精力-10）");
                        buttons[2].GetComponent<Button>().onClick.AddListener(E14B2);
                    }
                    rollFlag = true;
                    break;
                case 15://献计
                    /*目前实现方法未知，参见文档*/
                    break;
                case 16://开摆
                    if (currentPerson.mood <= 30)
                    {
                        screenText.text = currentPerson.personName + "的心情非常糟糕，他不想干活了，他现在只想开摆。";
                        buttons[0].SetText("开摆！（当前阶段无法进行开发，心情+15）");
                        buttons[0].GetComponent<Button>().onClick.AddListener(E16B0);
                        rollFlag = true;
                        break;
                    }
                    else break;
                default:break;
            }
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
        currentPerson.spirit -= 30;
        currentPerson.health += 5;
        Finish();
        screenText.text = "你吃了一些黄连素，然后稍微休息了一下继续开始工作，虽然肠胃炎暂时缓解了，然而你倍感疲倦...";
    }
    void E1B1()
    {
        currentPerson.Exist = false;//today
        currentPerson.spirit += 15;
        currentPerson.health += 30;
        Finish();
        screenText.text = "你去医院看了一下医生，医生给你开了一些药，并建议你好好休息。";
    }
    void E2B0()
    {
        currentPerson.spirit -= 10;
        Finish();
        screenText.text = "虽然效率有所降低，但是问题不是很大，还是进度重要。";
    }
    void E2B1()
    {
        currentPerson.health -= 10;
        currentPerson.spirit += 25;
        Finish();
        screenText.text = "没有什么疲劳是不能靠咖啡解决的，尽管可能要让身体付出一点代价...";
    }
    void E2B2()
    {
        currentPerson.Exist = false;
        currentPerson.spirit += 25;
        Finish();
        screenText.text = "你稍微咪了一下眼小睡了一会，结果一睡就是半天，但是一觉醒来感觉神清气爽，好多了。";
    }
    void E3B0()
    {
        currentPerson.health -= 25;
        currentPerson.spirit += 20;
        Finish();
        screenText.text = "一瓶咖啡不够那就多喝几瓶，只要能干活就行...";
    }
    void E3B1()
    {
        currentPerson.Exist = false;
        currentPerson.spirit += 20;
        Finish();
        screenText.text = "虽然好好休息了一下，然而你睡醒却感觉还是有些累。";
    }
    void E4B0()
    {
        currentPerson.Exist = false;//nextday
        currentPerson.mood += 50;
        Finish();
        screenText.text = "长期在外，能和父母的视频通话的时间都很少，更不要说陪在身边了，还是好好享受一下家人陪伴的感觉吧，开发任务稍后再做也没事。";
    }
    void E4B1()
    {
        currentPerson.mood -= 20;
        Finish();
        screenText.text = "你因为想全心全意把注意力集中在开发上而婉拒了父母，但是你很难不想念家人陪伴在身边的感觉，多少有些失落...";
    }
    void E5B0()
    {
        currentPerson.Exist = false;
        int result = UnityEngine.Random.Range(0, 3);
        switch (result)
        {
            case 0:
                currentPerson.spirit -= 10;
                //img
                Finish();
                screenText.text = "你花了小半天时间静心学习了一番，现在你不但可以解决目前遇到的问题，而且还有了相关的知识储备。";
                break;
            case 1:
                currentPerson.spirit -= 5;
                currentPerson.mood += 10;
                //img
                Finish();
                screenText.text = "你花了一点时间解决了当前遇到的问题，但是giligili的推广让你陶醉其中，不过就结果来说你还是挺快乐的。";
                break;
            case 2:
                currentPerson.spirit -= 10;
                currentPerson.mood -= 20;
                Finish();
                screenText.text = "你发现自学也救不了你，你感到一知半解，你既没有解决问题也无法理解内在的原理，你感到很失落。";
                break;
        }
    }
    void E5B1()
    {
        //img
        Finish();
        screenText.text = "你在请教开发组成员的同时与他们交流了一下自己的想法，得到了一些灵感。";
    }
    void E5B2()
    {
        int result = UnityEngine.Random.Range(0, 2);
        switch (result)
        {
            case 0:
                currentPerson.mood += 25;
                //img
                Finish();
                screenText.text = "水滴石穿，你在冥思苦想许久后灵感涌现了上来，问题成功解决了！你为问题的解决而感到非常激动。";
                break;
            case 1:
                currentPerson.mood -= 20;
                Finish();
                screenText.text = "你在埋头苦思许久后什么都想不出来，你感到非常烦躁...";
                break;
        }
    }
    void E6B0()
    {
        currentPerson.health += 5;
        currentPerson.mood -= 35;
        Finish();
        screenText.text = "你得知这则消息后非常悲痛，但是你还有任务要做，你唯一能做的就是铭记他，并且注意自己的身体，不要重蹈覆辙。";
    }
    void E6B1()
    {
        currentPerson.Exist = false;
        currentPerson.health -= 15;
        Finish();
        screenText.text = "你和曾经共同的朋友一起喝了一杯，虽然你们都很悲痛，然而觥筹交错，在和老友的叙旧和酒精的麻痹之下，你最终还是走了出来...大概吧。";
    }
    void E7B0()
    {
        currentPerson.Exist = false;
        int result = UnityEngine.Random.Range(0, 3);
        switch (result)
        {
            case 0:
                currentPerson.spirit -= 20;
                currentPerson.mood += 30;
                Finish();
                screenText.text = "这个派对果然非同一般，你感到非常开心！至于开发，明天再说！";
                break;
            case 1:
                currentPerson.spirit -= 20;
                currentPerson.mood += 20;
                //img
                Finish();
                screenText.text = "你不但在派对上玩的非常开心，更重要的是你认识到了一位bsdn的知名博主！派对后，你加了他的微信，交流了许多想法，得到了一些建议，你感到自己的思维水平得到了提升。";
                break;
            case 2:
                currentPerson.mood -= 20;
                Finish();
                screenText.text = "非常不巧，你在这场派对上遇到了曾经和你有过节的人。因为他的存在，你的心情非常糟糕...";
                break;
        }
    }
    void E7B1()
    {
        currentPerson.mood -= 5;
        Finish();
        screenText.text = "你想了想，还是开发更重要一点，派对什么的下次再说吧。不过有点郁闷就是了。";
    }
    void E8B0()
    {
        currentPerson.Exist = false;//2round
        Finish();
        screenText.text = "你缓缓睁开眼睛，一看电脑，发现竟然过了整整一天，你感觉头晕目眩...";
    }
    void E9B0()
    {
        currentPerson.Exist = false;
        //money-500
        currentPerson.mood -= 10;
        Finish();
        screenText.text = "你回过神来才发现显示器已经被你一拳砸碎了，你现在不但什么都做不了，而且还要花钱买新显示器，心情更糟糕了...";
    }
    void E10B0()
    {
        currentPerson.Exist = false;//out
        //othermood-10
        Finish();
        screenText.text = "表面看上去这很突然，其实" + currentPerson.personName + "的身体状况早已是油尽灯枯了。虽然其他成员都很悲痛，然而开发还是要继续。多多注意自己的身体吧。";
    }
    void E11B0()
    {
        currentPerson.Exist = false;
        currentPerson.mood -= 10;
        Finish();
        screenText.text = "虽然很烦躁，但是你除了等电来还能干啥呢？";
    }
    void E11B1()
    {
        currentPerson.mood -= 5;
        Finish();
        screenText.text = "还好你还有一台笔记本电脑，连个热点同步一下也不是不能用，就是空调不能用了有点烦。";
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
                    currentPerson.Exist = false;
                    currentPerson.health -= 20;
                    Finish();
                    screenText.text = "你的腿骨折了，还好这并不影响你的工作，大概吧。";
                    flag = true;
                    break;
                case 1:
                    currentPerson.Exist = false;//out
                    Finish();
                    screenText.text = "你的右手骨折了，这对于任何一个人来说都是毁灭性的。你不得不退出开发组了。";
                    flag = true;
                    break;
                case 2:
                    if (currentPerson.personName == "嗣yn"||currentPerson.personName == "大保")
                    {
                        currentPerson.Exist = false;
                        currentPerson.health -= 20;
                        Finish();
                        screenText.text = "你的左手骨折了，不过还好单靠右手也勉强还能画画...吧。";
                        flag = true;
                        break;
                    }
                    else break;
                case 3:
                    if (currentPerson.personName == "VINK" || currentPerson.personName == "公泥")
                    {
                        currentPerson.Exist = false;//out
                        Finish();
                        screenText.text = "你的左手骨折了，然而只靠一只右手很难继续敲代码了，你不得不退出开发组了。";
                        flag = true;
                        break;
                    }
                    else break;
                case 4:
                    currentPerson.Exist = false;
                    //img
                    currentPerson.health -= 10;
                    Finish();
                    screenText.text = "虽然听着很扯，但是事实就是如此，你到医院进行了一些治疗后就没什么大碍了，而且这一下撞击使你灵感迸发！现在你感到许多问题都得到了解决！";
                    break;
            }
        }
    }
    void E13B0()
    {
        if (currentPerson.mood > 30)
        {
            currentPerson.mood -= 10;
            Finish();
            screenText.text = "情绪波动乃人之常情，过一会就缓过来啦。";
        }
        else
        {
            currentPerson.Exist = false;
            Finish();
            screenText.text = "情绪波动乃人之常情，但是在心情低落时再来上那么一下就很难说了。也许你应该放下画笔好好放松一下。";
        }
    }
    void E14B0()
    {
        currentPerson.Exist = false;
        Finish();
        screenText.text = "还好电脑保修期还没过，你前往电脑店进行了一番维修之后，问题解决了，虽然比较耗时间就是了。";
    }
    void E14B1()
    {
        //money-100
        Finish();
        screenText.text = "请人来维修是最快的选择，虽然要花点钱就是了。";
    }
    void E14B2()
    {
        currentPerson.spirit -= 10;
        Finish();
        screenText.text = "虽然自己拆比较费劲，但是还好这个情况对你来说并不难处理，你很快就解决了。";
    }
    /*E15的实现待定*/
    void E16B0()
    {
        currentPerson.Exist = false;
        currentPerson.mood += 15;
        Finish();
        screenText.text = "你摆了半天，爽玩了最新最热的《乌蒙dx2088》，现在你感觉心情好了一些。";
    }
}
