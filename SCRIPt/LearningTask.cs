
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningTask : MonoBehaviour
{
//++++++++++++++++++++++++++++++++++  Definition of variable  +++++++++++++++++++++++++++++++++++++++++++++
    public GameObject panelIndication;
    public GameObject panelForGuide;
    public GameObject goalImage;
    public GameObject startImage;
    private RawImage gIMG;
    private RawImage sIMG;
    private int learningTaskNum = 0;

    string[] indicationList = new string[4];
    public bool timerStart = false;
    private Text finalLine;
    private Rigidbody rb;

    public Timer timer;

    public MoverMotor moverMotor;
    public int count = 0;
    private float nextTime;

    private string otherB;
    private string[] blockerSerielsOfTask2 = new string[]
        { "B2","B3","B4","A3",
        "A2","A1","C2","B1","C1",
        "D1","E1","D2","D3","E2",
        "E3","D4","C5","C4","C3"};
    private string[] goalImageSerielsofTask2=new string []
        {   "BB13","BB14","BB19","BB9",
        "BB7","BB2","BB6","BB10","BB15",
        "BB3","BB11","BB5","BB18","BB12",
        "blueStar","BB16","BB4","BB17","BB1","BB1"};//
    
    private string[] signalSerielsOfTask2 = new string[]
        { "1C3","13B2","13B3","14B1","14B2",
          "19B3","19B2","9B2","9B1","7B1",
          "7B2","2B1","2B3","6B3","6B2",
          "10B2","10B1","15B1","15B2","3B2",
          "3B1","11B3","11B2","5B2","5B1",
          "18B1","18B2","12B3","12B1","8B1",
           "8B2","16B2","16B1","4B2","4B1",
           "17B2","17B1","1C1"};

    private  string[] blockerSerielsOfTask3= new string[]
    {
        "C3","A1","D1","C5","D2",
        "C2","A2","E3","C3"
    };

    
    private int blockerIndex = 0;
    private int signalIndex=0;
    private int routeIndex=0;
    private int goalInRoute=1;
    private int startInRoute=0;
    private bool start2Goal=true;

    private  int wrongTimesCount=0;

    private  int bumpGoalTimes=0;

    private List<string> blockerName = new List<string>();
    public GameObject line;

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        indicationList[0] = "WELCOME";
        indicationList[1] = "free navigation";
        indicationList[2] = "navigation with lead";
        indicationList[3] = "direction";

        gIMG = goalImage.GetComponent<RawImage>();
        sIMG=startImage.GetComponent<RawImage>();

        rb = this.gameObject.GetComponent<Rigidbody>();

        IndicationPresentation();//load to TaskNum0

    }

    // Update is called once per frame
    void Update()
    {
        //interface一致，进入指导语
        //指导语内容：“自由探索”——欢迎探索迷宫，迷宫被灌木包围，其中有19个颜色图案不同的标识物
        //你有十分钟的时间自由探索迷宫，试试看自己能找到多少标识物吧。
        //自由探索10min
        

        if (timer.min == 0 && learningTaskNum == 1)
        {
            timerStart = false;
            timer.second = 0;
            IndicationPresentation();//load to TaskNum1
        }

        //learningTaskNum:0
        //指导语内容：“有提示的探索”——自由探索结束了，您回到了初始位置
        //接下来，请沿着给定的路线行动。
        //请看地面上的白色线，你前行方向的白色线会变成红色
        //你将完整而不重复地到达19个标识物。
        //每次到达新的标识物，将有2分钟时间不会出现下一个路线提示，
        //请记住当前标识物所在位置和长相，
        //并回忆上一个标识物的长相，以及当前标识物的相对位置
        //位置回归到Center




        //learningTaskNum:1
        //开始遍历（无重复），遍历一次后
        //指导语内容：恭喜你完成一次遍历，
        //接下来，请沿着给定的路线原路返回，
        //再次遍历19个标识物。
        //每次到达新的标识物，将有2分钟时间不会出现下一个路线提示，
        //请记住当前标识物所在位置和长相，
        //并回忆上一个标识物的长相，以及当前标识物的相对位置
       
        if (learningTaskNum == 2 && timer.second == 0)
        {
           
            panelForGuide.SetActive(true);
            this.transform.position =new Vector3(0, 0, 0);
            this.transform.rotation =Quaternion.Euler(0, -90, 0); 
            gIMG.texture = Resources.Load(goalImageSerielsofTask2[blockerIndex]) as Texture; 
            Debug.Log(blockerIndex);

            Transform signal = line.transform.Find(signalSerielsOfTask2[signalIndex]);
            Renderer signalRenderer = signal.GetComponent<Renderer>();
            signalRenderer.material.color = Color.red;

        }
        
       

        //learningTaskNum:2
        //结束后回到中心，
        //指导语内容：“最短路径探索”——有提示的探索已经结束了。
        //屏幕的左上角会呈现你的下一个目标。
        //接下来请尝试寻找当前所在位置到下一个目标的最短路径。
        //如果你成功找到目标，系统会告诉你是否是最短路径。
        //请记住目标与起点之间的最短途径。
        //系统会根据您的记忆情况，决定下一个目标。
        if(learningTaskNum ==3 && timer.second==0)
        {
            startImage.SetActive(true);
            this.transform.position =new Vector3(0, 0, 0);
            this.transform.rotation =Quaternion.Euler(0, -90, 0); 

            gIMG.texture = Resources.Load(blockerSerielsOfTask3[routeIndex+1]) as Texture;
            sIMG.texture=Resources.Load(blockerSerielsOfTask3[routeIndex]) as Texture;

        }

       
    }

    public void IndicationPresentation()
    {     
        panelIndication.SetActive(true);
        finalLine = panelIndication.GetComponentInChildren<Text>();
        finalLine.text = string.Format("Congratulation!you pass the line by  {0} s !", indicationList[learningTaskNum]);
        
    }


//Here is an event related function.Function of IndicationSetOff:
//(1) close the panel of indication
//(2) change the learningTaskNum. 0:free navigation  1: navigation with guide  2:shortest way navigation 3:relative direction detection
    public void IndicationSetOff()
    {
        panelIndication.SetActive(false);
        timerStart = true;
        if(learningTaskNum==1)
        {
            panelForGuide.SetActive(true);
        }
        if(learningTaskNum==3)
        {
            
            startImage.SetActive(true);
        }
        learningTaskNum++;
        Debug.Log("learningTaskNUM: "+learningTaskNum);
    }

public void ExchangeTheGoalImage2()
{ 
    //To  next goal              
    if (blockerIndex<blockerSerielsOfTask2.Length)  
   {
    gIMG.texture = Resources.Load(goalImageSerielsofTask2[blockerIndex]) as Texture; 
    Debug.Log("Display of g"+Time.time+"of"+gIMG.texture.name);
   } 

   if(blockerIndex==blockerSerielsOfTask2.Length)
    {
      timerStart = false;
        timer.second = 0;
       IndicationPresentation();
    }

 }

 public void ExchangeTheSignalImage2()
 {// 0 1      2
      if(signalIndex<signalSerielsOfTask2.Length)
    {
    Transform signal = line.transform.Find(signalSerielsOfTask2[signalIndex]);
    Renderer signalRenderer = signal.GetComponent<Renderer>();
    signalRenderer.material.color = Color.red;
    }

    if (signalIndex-1 != 0)
    {
    Transform signal2 = line.transform.Find(signalSerielsOfTask2[signalIndex - 2]);
    Renderer signalRenderer2 = signal2.GetComponent<Renderer>();
    signalRenderer2.material.color = Color.white;
    }
                    
   
}

    public void OnTriggerEnter(Collider other)
    { 
       // Debug.Log(other.name + " at " + this.name + " count: " + count);
        moverMotor.roundOfMotor.AddError(other.name);

        blockerName.Add(other.name);
        count++;
        otherB=other .name ;

       //TaskNum1: Navigation with guide.
        // 每次到达新的标识物，将有2分钟时间不会出现下一个路线提示，
        //请记住当前标识物所在位置和长相，
        //并回忆上一个标识物的长相，以及当前标识物的相对位置
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++==

        //In the second task: navigation with guide,if the player did not trriger the same blocker
        // produce the duration that the player should matain the task without next guide.
        // and if the bloker player trrigggering is the goal ,after the duration the goalImage 
        //would be changed into next goalImage. so as the blocker.
        //and if the boclker was the last one, the game would be loaded to the next task.

       
        //if (learningTaskNum == 2 && count != 1 && blockerName[count - 1] != blockerName[count])

      if (learningTaskNum == 2  )
        {
            
         
            if (other.name == blockerSerielsOfTask2[blockerIndex])
            {
                //duatation for 2 min;
                 float nextTime1 =5;
                 Debug.Log("THE NEXT TIME OF g  "+nextTime1);
                 blockerIndex++;
               
                //if (Time.time > nextTime)
               Invoke("ExchangeTheGoalImage2",nextTime1);
                
            }


           
            //if the player trigger the signal, after the duration,the color of next signal would be turned into red.
            //if  the signal was not the first signal, the last signal would back to white.
             if(other.name==signalSerielsOfTask2[signalIndex])
            {
                signalIndex++;
                float nextTime2 = 5;
                Debug.Log("THE NEXT TIME OF s  "+nextTime2);
                if(other.name=="13B2"||other.name=="14B1"
                ||other.name=="19B3"||other.name=="9B2"
                ||other.name=="7B1"||other.name=="2B1"
                ||other.name=="6B3"||other.name=="10B2"
                ||other.name=="15B1"||other.name=="3B2"
                ||other.name=="11B3"||other.name=="5B2"
                ||other.name=="18B1"||other.name=="12B3"
                ||other.name=="8B1"||other.name=="16B2"
                ||other.name=="4B2"||other.name=="17B2"
                ||other.name=="1C1")
                {Invoke("ExchangeTheSignalImage2",nextTime2);}
                else
                {ExchangeTheSignalImage2();}
                   
            }
        }
       


        //taskNum2: shortest route navigation
         //屏幕的左上角会呈现你的下一个目标。
        //接下来请尝试寻找当前所在位置到下一个目标的最短路径。
        //如果你成功找到目标，系统会告诉你是否是最短路径。
        //请记住目标与起点之间的最短途径。
        //系统会根据您的记忆情况，决定下一个目标。
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



        if (learningTaskNum == 3 )   
        {
           
            if(routeIndex==0)
            {
                if(other.name != "C3"&& other.name!="B2" && other.name!="C2"&& other.name!="A1")
                {
                    wrongTimesCount++;
                }
            
            }

            if(routeIndex==1)
            {
                if(other.name != "C1"&& other.name!="N0" && other.name!="A1"&& other.name!="D1")
                {
                    wrongTimesCount++;
                }
            
            }

            if(routeIndex==2)
            {
                if(other.name != "C3"&& other.name!="C5" && other.name!="C4"&& other.name!="D1")
                {
                    wrongTimesCount++;
                }
            
            }

            if(routeIndex==3)
            {
                if(other.name != "C5"&& other.name!="E3" && other.name!="D4"&& other.name!="E2"&& other.name!="D3"&& other.name!="D2")
                {
                    wrongTimesCount++;
                }
            
            }
            
            if(routeIndex==4)
            {
                if(other.name != "C2"&& other.name!="b1" && other.name!="c1"&& other.name!="d1"&& other.name!="C1"&& other.name!="D2")
                {
                    wrongTimesCount++;
                }
            
            }

             if(routeIndex==5)
            {
                if(other.name != "C2"&& other.name!="b1" && other.name!="C1"&& other.name!="D1"&& other.name!="C1"&& other.name!="D2")
                {
                    wrongTimesCount++;
                }
            
            }

             if(routeIndex==6)
            {
                if(other.name != "C2"&& other.name!="B2" && other.name!="B3"&& other.name!="B4"&& other.name!="A3"&& other.name!="A2")
                {
                    wrongTimesCount++;
                }
            
            }
          
           if(routeIndex==7)
            {
                if(other.name != "A2"&& other.name!="A3" && other.name!="B4"&& other.name!="C5"&& other.name!="D4"&& other.name!="E3")
                {
                    wrongTimesCount++;
                }
            
            }

             if(routeIndex==8)
            {
                if(other.name != "E3"&& other.name!="C4" && other.name!="C3")
                {
                    wrongTimesCount++;
                }
            
            }



            
           /* route为6条线路的编号，同时route代表当前线路的起点，route+1代表当前线路的终点
           //如果玩家到达下一个目的地，且是最短路径（即wrongTimesCount为0），
                则记为成功一次，此时bumpGoalTimes加一,提示当前是最短路径。
                交换起点和目的地，wrongTimesCount归零。
                当目的地的bumpGoalTimes为2时成功三次，此时 route++，将目的地更新为下一条路径的目的地。
                                                    
            //如果玩家到达下一个目的地，但不是最短路径(wrongTimesCount!=0)，
                 提示当前并非最短路径。
                 交换起点和目的地，wrongTimesCount归零。
                
             private  string[] blockerSerielsOfTask3= new string[]
                 {
                 "C3","A1","D1","C5","D2",
                 "C2","A2","E3","C3"
                  };
             */
            if (other.name == blockerSerielsOfTask3[goalInRoute]&&wrongTimesCount==0 )
            {
                bumpGoalTimes++;
                 //congratulations， you found the shortest route!
                
                if(bumpGoalTimes>=2)
                {   
                   
                 routeIndex++;
                 goalInRoute=routeIndex+1;
                 startInRoute=routeIndex;
                 sIMG.texture = Resources.Load(blockerSerielsOfTask3[startInRoute]) as Texture;
                 gIMG.texture=Resources.Load(blockerSerielsOfTask3[goalInRoute]) as Texture;
                 
                 if(routeIndex==blockerSerielsOfTask3.Length)
                 {
                    IndicationPresentation();
                 }
                }
                if (bumpGoalTimes<2)
                {
                    //exchange the goal and start
                    if(start2Goal==true)
                  {
                   goalInRoute=routeIndex;
                   startInRoute=routeIndex+1;
                   sIMG.texture = Resources.Load(blockerSerielsOfTask3[startInRoute]) as Texture;
                   gIMG.texture=Resources.Load(blockerSerielsOfTask3[goalInRoute]) as Texture;
                   start2Goal=false;

                  }
                  if(start2Goal==false)
                  {
                   goalInRoute=routeIndex+1;
                   startInRoute=routeIndex;
                   sIMG.texture = Resources.Load(blockerSerielsOfTask3[startInRoute]) as Texture;
                   gIMG.texture=Resources.Load(blockerSerielsOfTask3[goalInRoute]) as Texture;
                   start2Goal=true;
                  }
                 
                 wrongTimesCount=0;
                }

                 
            }
            if (other.name == blockerSerielsOfTask3[goalInRoute]&&wrongTimesCount!=0 )
            {
                //sorry it isn't the shortest road
                 if(start2Goal==true)
                  {
                   goalInRoute=routeIndex;
                   startInRoute=routeIndex+1;
                   sIMG.texture = Resources.Load(blockerSerielsOfTask3[startInRoute]) as Texture;
                   gIMG.texture=Resources.Load(blockerSerielsOfTask3[goalInRoute]) as Texture;
                   start2Goal=false;

                  }
                  if(start2Goal==false)
                  {
                   goalInRoute=routeIndex+1;
                   startInRoute=routeIndex;
                   sIMG.texture = Resources.Load(blockerSerielsOfTask3[startInRoute]) as Texture;
                   gIMG.texture=Resources.Load(blockerSerielsOfTask3[goalInRoute]) as Texture;
                   start2Goal=true;
                  }
                 
                 wrongTimesCount=0;
            }

            //做一个在用户界面呈现语句一定时间的class

        }

        //learningTaskNum:3
        //下述学习是否必要？

        //结束后回到中心，
        //指导语内容：“相对位置回忆”——恭喜你完成最短路径任务。
        //屏幕的左上角会呈现你的当前位置和你的下一个目标的标识物。
        //请找到你的目标标识物，并面对标识物，此时你的面前会出现一个罗盘
        //用左右键操纵罗盘，使指针指向起点方向，确定后按方向键上键。
        //在完成方向指认之前，你不能随意移动，当完成方向指认（上建）后，罗盘消失
        //新的目标将呈现在屏幕左上角，你可以进行下一个探索
    }

    
}
