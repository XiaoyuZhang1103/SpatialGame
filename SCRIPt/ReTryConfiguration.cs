using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;


public class ReTryConfiguration : MonoBehaviour
{

    public GameObject goalImage;
    public GameObject startImage;
    public  GameObject Blocker;
    private RawImage gIMG;
    private RawImage sIMG;
    public  GameObject IndicationPanel;
   // private Vector3 facingDirection;
    private  string[,]  condition= {
  {	"D2"	,	"9"	,	"7"	,	"30"	,	"A3"	}	,
{	"D2"	,	"9"	,	"16"	,"330"	,	"B1"	}	,
{	"D2"	,	"9"	,	"11"	,"360"	,	"B2"	}	,
{	"D2"	,	"9"	,	"8"	,	"30"	,	"B3"	}	,
{	"D2"	,	"9"	,	"13"	,"330"	,	"C2"	}	,
{	"D2"	,	"9"	,	"14"	,"30"	,	"C3"	}	,
{	"D2"	,	"9"	,	"4"	,	"60"	,	"C4"	}	,
{	"D2"	,	"9"	,	"17"	,"270"	,	"D1"	}	,
{	"D2"	,	"9"	,	"3"	,	"90"	,	"D3"	}	,
{	"D2"	,	"9"	,	"5"	,	"90"	,	"D4"	}	,
{	"D2"	,	"9"	,	"15"	,"210"	,	"E1"	}	,
{	"D2"	,	"9"	,	"2"	,	"150"	,	"E2"	}	,
{	"D2"	,	"9"	,	"1"	,	"120"	,	"E3"	}	,
{	"D3"	,	"3"	,	"12"	,"330"	,	"A1"	}	,
{	"D3"	,	"3"	,	"11"	,"330"	,	"B2"	}	,
{	"D3"	,	"3"	,	"8"	,	"360"	   ,	"B3"	}	,
{	"D3"	,	"3"	,	"6"	,	"30"	,	"B4"	}	,
{	"D3"	,	"3"	,	"13"	,"300"	,	"C2"	}	,
{	"D3"	,	"3"	,	"14"	,"330"	,	"C3"	}	,
{	"D3"	,	"3"	,	"4"	,	"30"	,	"C4"	}	,
{	"D3"	,	"3"	,	"17"	,"270"	,	"D1"	}	,
{	"D3"	,	"3"	,	"9"	,	"270"	,	"D2"	}	,
{	"D3"	,	"3"	,	"5"	,	"90"	,	"D4"	}	,
{	"D3"	,	"3"	,	"15"	,"240"	,	"E1"	}	,
{	"D3"	,	"3"	,	"2"	,	"210"	,	"E2"	}	,
{	"D3"	,	"3"	,	"1"	,	"150"	,	"E3"	}	,
{	"C2"	,	"13"	,"12"  , "360"	,	"A1"	}	,
{	"C2"	,	"13"	,"10"  , "30"	,	"A2"	}	,
{	"C2"	,	"13"	,"16"  , "330"	,	"B1"	}	,
{	"C2"	,	"13"	,"11"  , "30"	,	"B2"	}	,
{	"C2"	,	"13"	,"8"  ,  "60"	,	"B3"	}	,
{	"C2"	,	"13"	,"14"  ,  "90"	,	"C3"	}	,
{	"C2"	,	"13"	,"4"   ,  "90"	,	"C4"	}	,
{	"C2"	,	"13"	,"17"   , "210"	,	"D1"	}	,
{	"C2"	,	"13"	,"9"	,"150"	,	"D2"	}	,
{	"C2"	,	"13"	,"3"	,"120"	,	"D3"	}	,
{	"C2"	,	"13"	,"15"   , "180"	,	"E1"	}	,
{	"C2"	,	"13"	,"2"	,"150"	,	"E2"	}	,
{	"C4"	,	"4"	,	"10"	,"330"	,	"A2"	}	,
{	"C4"	,	"4"	,	"7"	,	"360"   ,	"A3"	}	,
{	"C4"	,	"4"	,	"11"	,"300"	,	"B2"	}	,
{	"C4"	,	"4"	,	"8"	,	"330"	,	"B3"	}	,
{	"C4"	,	"4"	,	"6"	,	"30"	,	"B4"	}	,
{	"C4"	,	"4"	,	"13"	,"270"	,	"C2"	}	,
{	"C4"	,	"4"	,	"14"	,"270"	,	"C3"	}	,
{	"C4"	,	"4"	,	"9"	,	"240"	,	"D2"	}	,
{	"C4"	,	"4"	,	"3"	,	"210"	,	"D3"	}	,
{	"C4"	,	"4"	,	"5"	,	"150"	,	"D4"	}	,
{	"C4"	,	"4"	,	"2"	,	"210"	,	"E2"	}	,
{	"C4"	,	"4"	,	"1"	,	"180"	,	"E3"	}	,
{	"B2"	,	"11",	"12",   "330"	,	"A1"	}	,
{	"B2"	,	"11",	"10",   "30"	,	"A2"	}	,
{	"B2"	,	"11",	"7"	,   "60"	,	"A3"	}	,
{	"B2"	,	"11",	"16",   "270"	,	"B1"	}	,
{	"B2"	,	"11",	"8"	,   "90"	,	"B3"	}	,
{	"B2"	,	"11",	"6"	,   "90"	,	"B4"	}	,
{	"B2"	,	"11",	"13",   "210"	,	"C2"	}	,
{	"B2"	,	"11",	"14",   "150"	,	"C3"	}	,
{	"B2"	,	"11",	"4"	,   "120"	,	"C4"	}	,
{	"B2"	,	"11",	"17",  "210"	,	"D1"	}	,
{	"B2"	,	"11",	"9"	,   "180"	,	"D2"	}	,
{	"B2"	,	"11",	"3"	,   "150"	,	"D3"	}	,
{	"B2"	,	"11",	"1"	,   "150"	,	"E3"	}	,
{	"B3"	,	"8"	,	"12"	,"300"	,	"A1"	}	,
{	"B3"	,	"8"	,	"10"	,"330"	,	"A2"	}	,
{	"B3"	,	"8"	,	"7"	,	"30"	,	"A3"	}	,
{	"B3"	,	"8"	,	"16"	,"270"	,	"B1"	}	,
{	"B3"	,	"8"	,	"11"	,"270"	,	"B2"	}	,
{	"B3"	,	"8"	,	"6"	,	"90"	,	"B4"	}	,
{	"B3"	,	"8"	,	"13"	,"240"	,	"C2"	}	,
{	"B3"	,	"8"	,	"14"	,"210"	,	"C3"	}	,
{	"B3"	,	"8"	,	"4"	,	"150"	,	"C4"	}	,
{	"B3"	,	"8"	,	"9"	,	"210"	,	"D2"	}	,
{	"B3"	,	"8"	,	"3"	,	"180"	,	"D3"	}	,
{	"B3"	,	"8"	,	"5"	,	"150"	,	"D4"	}	,
{	"B3"	,	"8"	,	"15",   "210"    ,	"E1"	}	,

////////////////////////////////////////////////////////
    };
  
   /*6map {
    //0 blokernameOfStart   1 startIMG     2 goalIMG     3condition  4blockernameOfGoal
       {"C4","BB17","BB14","120","B3"},
       {"D3","BB18","BB5","90","D2"},
        {"D3","BB18","BB5","90","D2"},
       {"C2","BB6","BB1","-90","C3"}
    };*/
    private int[] conditionIndex;
    private int loopNum=0;
   private int bumpGoalTimes=0;
   private int begin=0;
   public GameObject FindGoalIndication;
   public GameObject BackStartIndication;
   public GameObject faceGoalIndication;
   public GameObject CheckButton;
   private  string tmp;

    public  RecallTaskData BehavioralData= new RecallTaskData();
    public  EachTrial OneTrial= new EachTrial();
    List<string> Trials=new List<string>();
    float timeToGoal;
    float timeToStart;
    float timeToCheck;
    int  restCount=0;
    public int restTimes=25;
    public GameObject PanelAfterRound;
    public GameObject PanelForGuide;
    public AudioSource SoundOFGoal;
    public AudioSource SoundOFStart;
    public AudioSource SoundOFCheck;

    public MoverMotor MM;

  public  Rigidbody ri ;

  public Vector3 positionOffset= new Vector3(0,0,0);

  public GameObject  B2dCamera;
    
     

    void Start()
    {   
      GetComponent<MoverMotor>().enabled=true;
        if (SceneManager.GetActiveScene().name=="43dConfi"||SceneManager.GetActiveScene().name=="42dConfi")
        {
        PanelAfterRound.SetActive(false);
        conditionIndex=RandomizeWithoutRepeate( condition.GetLength(0),0,condition.GetLength(0)-1);
        gIMG = goalImage.GetComponent<RawImage>();
        sIMG=startImage.GetComponent<RawImage>();
        FindGoalIndication.SetActive(false);
        BackStartIndication.SetActive(false);
        faceGoalIndication.SetActive(false);
        CheckButton.SetActive(false);
        OneTrial.StartOfWatch();
        }
        else
        {
        PanelAfterRound.SetActive(false);
        conditionIndex=RandomizeWithoutRepeate( condition.GetLength(0),0,condition.GetLength(0)-1);
        gIMG = goalImage.GetComponent<RawImage>();
        sIMG=startImage.GetComponent<RawImage>();
        FindGoalIndication.SetActive(false);
        BackStartIndication.SetActive(false);
        faceGoalIndication.SetActive(true);
        CheckButton.SetActive(true);
        OneTrial.StartOfWatch();
        SoundOFCheck.Play(0);
        }
    }

    private void Update() 
    {
      if(SceneManager.GetActiveScene().name=="43dConfi"||SceneManager.GetActiveScene().name=="42dConfi")
      {
        if(bumpGoalTimes==0&&begin==0)
        {
         gIMG.texture=Resources.Load(condition[conditionIndex[loopNum],2]) as Texture;
         sIMG.texture=Resources.Load(condition[conditionIndex[loopNum],1]) as Texture;
         if(tmp!=condition[conditionIndex[loopNum],1])
         {
         this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).position+ positionOffset;
         this.transform.rotation=Quaternion.Euler(0,180,0);
         ///////////////////////////////////////////////////////////////////////////////////////////
          if(SceneManager.GetActiveScene().name=="42DBConfi")
        {
             B2dCamera.transform.rotation=Quaternion.Euler(90,180,0);
        }
         //this.transform.rotation=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).rotation;
         }
         //显示“请找到终点”
        
         faceGoalIndication.SetActive(false);
         FindGoalIndication.SetActive(true);
         SoundOFGoal.Play(0);
         begin++;
        } 
      }
      else
      {
       if(bumpGoalTimes==0&&begin==0)
        {
         gIMG.texture=Resources.Load(condition[conditionIndex[loopNum],2]) as Texture;
         sIMG.texture=Resources.Load(condition[conditionIndex[loopNum],1]) as Texture;
         if(tmp!=condition[conditionIndex[loopNum],1])
         {
         this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).position+positionOffset;
         this.transform.rotation=Quaternion.Euler(0,180,0);
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
           if(SceneManager.GetActiveScene().name=="42DBConfi")
        {
             B2dCamera.transform.rotation=Quaternion.Euler(90,180,0);
        }
         //this.transform.rotation=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).rotation;
         }
         if(tmp==condition[conditionIndex[loopNum],1])
         {
           this.transform.rotation=Quaternion.Euler(0,180,0);
            if(SceneManager.GetActiveScene().name=="42DBConfi")
           {
             B2dCamera.transform.rotation=Quaternion.Euler(90,180,0);
           }
         }
         begin++;
        }    
      }
    }
    private void OnTriggerEnter(Collider other)
     {
       if(SceneManager.GetActiveScene().name=="43dConfi"||SceneManager.GetActiveScene().name=="42dConfi")
       { 
         if(other.name==condition[conditionIndex[loopNum],4])
         {

             bumpGoalTimes++;
             //显示“请回到起点”
             
             timeToGoal=Time.time;
             FindGoalIndication.SetActive(false);
             faceGoalIndication.SetActive(false);
             BackStartIndication.SetActive(true);
             SoundOFStart.Play(0);
         }
          if(other.name==condition[conditionIndex[loopNum],0]&&bumpGoalTimes!=0)
         {
             //显示“请在起点中心站定，面向终点，确定差不多后，按确定键”
             //显示按钮
              OneTrial.AddCondition(condition[conditionIndex[loopNum],0]+"_"+condition[conditionIndex[loopNum],4]) ;  
             timeToStart=Time.time;
             BackStartIndication.SetActive(false);
             faceGoalIndication.SetActive(true);
              SoundOFCheck.Play(0);
             CheckButton.SetActive(true);
         }
       }
       else
       {
           if(other.name==condition[conditionIndex[loopNum],0])
         {
             //显示“请在起点中心站定，面向终点，确定差不多后，按确定键”
             //显示按钮
              OneTrial.AddCondition(condition[conditionIndex[loopNum],0]+"_"+condition[conditionIndex[loopNum],4]) ;  
             timeToStart=Time.time;
             BackStartIndication.SetActive(false);
             faceGoalIndication.SetActive(true);
              //SoundOFCheck.Play(0);
             
         }
       }
        
    }

    public void CheckTheDirection()
    {
        
         //记录数据√   
          SoundOFCheck.Play(0);
         timeToCheck=Time.time;
         OneTrial.SubjectRotation= transform.eulerAngles;
      // UnityEngine.Debug.Log("Condition "+condition[conditionIndex[loopNum],3]);
         string str=condition[conditionIndex[loopNum],3];
          // OneTrial.difference=System.Math.Abs(OneTrial.SubjectRotation.y-int.Parse(str));
          OneTrial.difference=CheckTheAccuracyOf(OneTrial.SubjectRotation.y,int.Parse(str));
            
          // UnityEngine.Debug.Log("Facing direction of sb  "+OneTrial.SubjectRotation);
          //  UnityEngine.Debug.Log("Answer  "+str);
            // UnityEngine.Debug.Log("Response  "+OneTrial.SubjectRotation.y);
            // UnityEngine.Debug.Log("Response  "+str);
          // UnityEngine.Debug.Log("differences "+OneTrial.difference);
          //BehavioralData.AddTrial(loopNum);

          Trials.Add("Condition "+OneTrial.conditionOfDirection+" "+"BumpGoal "+timeToGoal.ToString()+" "+"BumpStart "+timeToStart.ToString()
                     +" "+"FinishedTrial "+timeToCheck.ToString()+" "+"SubjecRotation "+OneTrial.SubjectRotation.ToString()
                     +" "+"Anwser "+str+" "+"Accuracy "+OneTrial.difference.ToString());
        
         //rest time
         if(restCount==restTimes)
         {
             Rest();
         }

         //To the next trial
         tmp=condition[conditionIndex[loopNum],1];
         loopNum++;
         restCount++;
         bumpGoalTimes=begin=0;

        //end of game
        if(loopNum==condition.GetLength(0))
        { 
           
           begin=3;
           UnityEngine.Debug.Log("create the file already");
           MM.IfGenerateTrace=true;
           CreateFile();
          // GetComponent<MoverMotor>().enabled=false;
           IndicationPanel.SetActive(true);
          
        }
       
        //按键消失
        if(SceneManager.GetActiveScene().name=="43dConfi"||SceneManager.GetActiveScene().name=="42dConfi")
        {CheckButton.SetActive(false);}

       

    }

    public float CheckTheAccuracyOf(float answer1,float correct1)
     {
         float accu=0;
         float df= System.Math.Abs(correct1-answer1);
         if(df<=180)
         {
            accu=df;
         }
         else
         {
           accu=360-df;
         }
          return accu;       
     }
     public int[] RandomizeWithoutRepeate(int num,int minValue, int maxValue)
    {
        if (maxValue+1-minValue-num<0)
          maxValue+=num-(maxValue+1-minValue);

        System.Random ra =new System.Random(unchecked((int)DateTime.Now.Ticks));
        int[] arrrNum=new int[num];
        int tmp1=0;
        StringBuilder sb  = new StringBuilder(num*maxValue.ToString().Trim().Length);

        for(int i=0;i<=num-1;i++)
        {
          tmp1=ra.Next(minValue,maxValue);
          while(sb.ToString().Contains("#"+ tmp1.ToString().Trim()+"#"))
          {
              tmp1=ra.Next(minValue,maxValue+1);
          }
          arrrNum[i]=tmp1;
          sb.Append("#"+tmp1.ToString().Trim()+"#");
        }
        return arrrNum;
        
    }

     public void CreateFile()
    {
        string File_Name = SceneManager.GetActiveScene().name;//string.Format(map.nameOfSubject, map.ID);
        // create the path for the file.
        string pathString = @"D:\uinity pa\RecTanMinusTime\Assets\BehavioralData";
        pathString = System.IO.Path.Combine(pathString, File_Name);

        if (File.Exists(pathString))
        {
          UnityEngine.Debug.Log(File_Name);
            return;
        }
        else
        {
            using (StreamWriter sr = new StreamWriter(pathString))
            {
                
                foreach(string a in Trials)
                {
                    sr.WriteLine(a);

                }
                //BehavioralData.WriteDownTrial(sr);
                   
            }
        }
    }

    public void Rest()
    {
        PanelAfterRound.SetActive(true);
        PanelForGuide.SetActive(false);
    }

    public void BackToGame()
    {
        PanelAfterRound.SetActive(false);
        PanelForGuide.SetActive(true);
        restCount=0;
    }

    public void EnterTheRecallTask()
    {
       
          SceneManager.LoadScene("RecallTaskTry");
        
         
    }
}
