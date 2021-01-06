using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;


public class SystemKnowledgeRecallTask : MonoBehaviour
{
    public GameObject panelIndication;
    public GameObject panelForGuide;
    public GameObject goalImage;
    public GameObject startImage;
    public GameObject Blocker;
    private RawImage gIMG;
    private RawImage sIMG;
    public GameObject Fixation;
    public GameObject SectionFinishedButton;
    public GameObject STARTButton;
    public AudioSource sound;
    public float rotateSpeed = 0.7f;
    // private Vector3 facingDirection;
    private string[,] condition =
{
{   "D2"    ,   "9" ,   "7" ,   "30"    ,   "A3"    }   ,
{   "D2"    ,   "9" ,   "16"    ,"330"  ,   "B1"    }   ,
{   "D2"    ,   "9" ,   "11"    ,"360"  ,   "B2"    }   ,
{   "D2"    ,   "9" ,   "8" ,   "30"    ,   "B3"    }   ,
{   "D2"    ,   "9" ,   "13"    ,"330"  ,   "C2"    }   ,
{   "D2"    ,   "9" ,   "14"    ,"30"   ,   "C3"    }   ,
{   "D2"    ,   "9" ,   "4" ,   "60"    ,   "C4"    }   ,
{   "D2"    ,   "9" ,   "17"    ,"270"  ,   "D1"    }   ,
{   "D2"    ,   "9" ,   "3" ,   "90"    ,   "D3"    }   ,
{   "D2"    ,   "9" ,   "5" ,   "90"    ,   "D4"    }   ,
{   "D2"    ,   "9" ,   "15"    ,"210"  ,   "E1"    }   ,
{   "D2"    ,   "9" ,   "2" ,   "150"   ,   "E2"    }   ,
{   "D2"    ,   "9" ,   "1" ,   "120"   ,   "E3"    }   ,
{   "D3"    ,   "3" ,   "12"    ,"330"  ,   "A1"    }   ,
{   "D3"    ,   "3" ,   "11"    ,"330"  ,   "B2"    }   ,
{   "D3"    ,   "3" ,   "8" ,   "360"      ,    "B3"    }   ,
{   "D3"    ,   "3" ,   "6" ,   "30"    ,   "B4"    }   ,
{   "D3"    ,   "3" ,   "13"    ,"300"  ,   "C2"    }   ,
{   "D3"    ,   "3" ,   "14"    ,"330"  ,   "C3"    }   ,
{   "D3"    ,   "3" ,   "4" ,   "30"    ,   "C4"    }   ,
{   "D3"    ,   "3" ,   "17"    ,"270"  ,   "D1"    }   ,
{   "D3"    ,   "3" ,   "9" ,   "270"   ,   "D2"    }   ,
{   "D3"    ,   "3" ,   "5" ,   "90"    ,   "D4"    }   ,
{   "D3"    ,   "3" ,   "15"    ,"240"  ,   "E1"    }   ,
{   "D3"    ,   "3" ,   "2" ,   "210"   ,   "E2"    }   ,
{   "D3"    ,   "3" ,   "1" ,   "150"   ,   "E3"    }   ,
{   "C2"    ,   "13"    ,"12"  , "360"  ,   "A1"    }   ,
{   "C2"    ,   "13"    ,"10"  , "30"   ,   "A2"    }   ,
{   "C2"    ,   "13"    ,"16"  , "330"  ,   "B1"    }   ,
{   "C2"    ,   "13"    ,"11"  , "30"   ,   "B2"    }   ,
{   "C2"    ,   "13"    ,"8"  ,  "60"   ,   "B3"    }   ,
{   "C2"    ,   "13"    ,"14"  ,  "90"  ,   "C3"    }   ,
{   "C2"    ,   "13"    ,"4"   ,  "90"  ,   "C4"    }   ,
{   "C2"    ,   "13"    ,"17"   , "210" ,   "D1"    }   ,
{   "C2"    ,   "13"    ,"9"    ,"150"  ,   "D2"    }   ,
{   "C2"    ,   "13"    ,"3"    ,"120"  ,   "D3"    }   ,
{   "C2"    ,   "13"    ,"15"   , "180" ,   "E1"    }   ,
{   "C2"    ,   "13"    ,"2"    ,"150"  ,   "E2"    }   ,
{   "C4"    ,   "4" ,   "10"    ,"330"  ,   "A2"    }   ,
{   "C4"    ,   "4" ,   "7" ,   "360"   ,   "A3"    }   ,
{   "C4"    ,   "4" ,   "11"    ,"300"  ,   "B2"    }   ,
{   "C4"    ,   "4" ,   "8" ,   "330"   ,   "B3"    }   ,
{   "C4"    ,   "4" ,   "6" ,   "30"    ,   "B4"    }   ,
{   "C4"    ,   "4" ,   "13"    ,"270"  ,   "C2"    }   ,
{   "C4"    ,   "4" ,   "14"    ,"270"  ,   "C3"    }   ,
{   "C4"    ,   "4" ,   "9" ,   "240"   ,   "D2"    }   ,
{   "C4"    ,   "4" ,   "3" ,   "210"   ,   "D3"    }   ,
{   "C4"    ,   "4" ,   "5" ,   "150"   ,   "D4"    }   ,
{   "C4"    ,   "4" ,   "2" ,   "210"   ,   "E2"    }   ,
{   "C4"    ,   "4" ,   "1" ,   "180"   ,   "E3"    }   ,
{   "B2"    ,   "11",   "12",   "330"   ,   "A1"    }   ,
{   "B2"    ,   "11",   "10",   "30"    ,   "A2"    }   ,
{   "B2"    ,   "11",   "7" ,   "60"    ,   "A3"    }   ,
{   "B2"    ,   "11",   "16",   "270"   ,   "B1"    }   ,
{   "B2"    ,   "11",   "8" ,   "90"    ,   "B3"    }   ,
{   "B2"    ,   "11",   "6" ,   "90"    ,   "B4"    }   ,
{   "B2"    ,   "11",   "13",   "210"   ,   "C2"    }   ,
{   "B2"    ,   "11",   "14",   "150"   ,   "C3"    }   ,
{   "B2"    ,   "11",   "4" ,   "120"   ,   "C4"    }   ,
{   "B2"    ,   "11",   "17",  "210"    ,   "D1"    }   ,
{   "B2"    ,   "11",   "9" ,   "180"   ,   "D2"    }   ,
{   "B2"    ,   "11",   "3" ,   "150"   ,   "D3"    }   ,
{   "B2"    ,   "11",   "1" ,   "150"   ,   "E3"    }   ,
{   "B3"    ,   "8" ,   "12"    ,"300"  ,   "A1"    }   ,
{   "B3"    ,   "8" ,   "10"    ,"330"  ,   "A2"    }   ,
{   "B3"    ,   "8" ,   "7" ,   "30"    ,   "A3"    }   ,
{   "B3"    ,   "8" ,   "16"    ,"270"  ,   "B1"    }   ,
{   "B3"    ,   "8" ,   "11"    ,"270"  ,   "B2"    }   ,
{   "B3"    ,   "8" ,   "6" ,   "90"    ,   "B4"    }   ,
{   "B3"    ,   "8" ,   "13"    ,"240"  ,   "C2"    }   ,
{   "B3"    ,   "8" ,   "14"    ,"210"  ,   "C3"    }   ,
{   "B3"    ,   "8" ,   "4" ,   "150"   ,   "C4"    }   ,
{   "B3"    ,   "8" ,   "9" ,   "210"   ,   "D2"    }   ,
{   "B3"    ,   "8" ,   "3" ,   "180"   ,   "D3"    }   ,
{   "B3"    ,   "8" ,   "5" ,   "150"   ,   "D4"    }   ,
{   "B3"    ,   "8" ,   "15",   "210"    ,  "E1"    }
};
    /*
    {
         //0 blokernameOfStart   1 startIMG     2 goalIMG     3condition  4blockernameOfGoal
           {"C4","BB17","BB14","120"},
           {"D3","BB18","BB5","90"},
           {"C2","BB6","BB1","-90"}
        };*/
    private int[] conditionIndex;
    private int loopNum = 0;


    public RecallTaskData BehavioralData = new RecallTaskData();
    public EachTrial OneTrial = new EachTrial();

    public float startOfTo;
    public float durationFix = 2;
    public float durationGS = 4;
    public float durationIMG = 6;
    public float durationCheck = 7;
    public int durationRest = 5;
    public int trialCount = 0;
    List<string> Trials = new List<string>();
    private bool hasResponded = false;
    int beginofT = 10;
    float nextTime;
    float onset;
    int countingBlock=0;

    void Start()
    {
        //this.transform.position=new Vector3(0,0,0);
        GetComponent<MoverMotor>().enabled = true;
        if (SceneManager.GetActiveScene().name == "RecallTaskTry")
        {
            condition =  new string[,]   {
          {   "A2"    ,   "10"    ,   "7"     ,   "90"    ,   "A3"    }   ,
          {	"A2"	,	"10"	,	"16"	,	"240"	,	"B1"	}	,
          {	"D4"	,	"5"	    ,	"17"	,	"270"	,	"D1"	}	,
          {	"D4"	,	"5"     ,	"13"	,	"285"	,	"C2"	}	,
          {	"A3"	,	"7"	    ,	"6"	    ,	"60"	,	"B4"	}	,
          {	"A1"	,	"12"	,	"16"	,	"300"	,	"B1"	}	,
          {	"E1"	,	"15"	,	"1"  	,	"90"	,	"E3"	}	,
          {	"E1"	,	"15"	,	"17"	,	"330"	,	"D1"	}	
            };
        }
        conditionIndex = RandomizeWithoutRepeate(condition.GetLength(0), 0, condition.GetLength(0) - 1);
        CreateSeFile();
        gIMG = goalImage.GetComponent<RawImage>();
        sIMG = startImage.GetComponent<RawImage>();
        sound = GetComponent<AudioSource>();
        STARTButton.SetActive(true);
    }

    void Update()
    {
        //REST
        if (beginofT == 6 )
        {
            countingBlock++;
            durationRest=RandomizeWithoutRepeate(1,10,15)[0];

            UnityEngine.Debug.Log("REST " + durationRest);

            OneTrial.AddREST(durationRest);

            nextTime = Time.time + durationRest;
            Rest();
            OneTrial.AddRestShowTime(Time.time-onset);
            beginofT = 0;

        }
      //FIXATION
        if (beginofT == 0 && loopNum <= condition.GetLength(0) && Time.time >= nextTime)
        {
            nextTime = Time.time + durationFix;
            OneTrial.AddTimeToShowFixation(Time.time-onset);
            TO();
            beginofT = 1;
        }
        //GS
        if (beginofT == 1 && Time.time >= nextTime)
        {
            beginofT = 2;
            nextTime = Time.time + durationGS;
            OneTrial.AddTimeToShowGS(Time.time-onset);
            T1();
        }
        //IMG
        if (beginofT == 2 && Time.time >= nextTime)
        {
            nextTime = Time.time + durationIMG;
            OneTrial.AddTimeToShowBlack(Time.time-onset);
            T2();
            beginofT = 3;
        }
        //DIRECTION
        if (beginofT == 3 && Time.time >= nextTime)
        {
            nextTime = Time.time + durationCheck;
            OneTrial.AddTimeToShowSound(Time.time-onset);
            T3();
            beginofT = 4;
        }
        if (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.G))
        {
            if (hasResponded != true)
            {
                OneTrial.AddTimeToRespond(Time.time-onset);
                hasResponded = true;
            }
        }
 
        if (beginofT == 4 && Time.time > nextTime)
        {
            beginofT = 6;
            // OneTrial.SubjectRotation= transform.eulerAngles;
            OneTrial.AddDirection(transform.eulerAngles);
            string str = condition[conditionIndex[loopNum], 3]; ;
            OneTrial.AddAccuracy(CheckTheAccuracyOf(OneTrial.SubjectRotation.y, int.Parse(str)));

            //  UnityEngine.Debug.Log("differences "+OneTrial.conditionOfDirection);
            // UnityEngine.Debug.Log("Facing direction of sb  "+OneTrial.SubjectRotation);
            // UnityEngine.Debug.Log("Answer  "+str);
            //UnityEngine.Debug.Log("differences " + OneTrial.difference);


            Trials.Add(OneTrial.PrintOneTrial());
            BehavioralData.AddTrial(loopNum);
            // the turning of trials
            if (loopNum + 1 <= condition.GetLength(0))
            {
                loopNum++;
                trialCount++;
                UnityEngine.Debug.Log("Block" + trialCount);
             // the section finished button
                if (trialCount == 19)
                {
                    beginofT = 9;
                    panelForGuide.SetActive(true);
                    SectionFinishedButton.SetActive(true);
                    CreateFile();
                }
            }
            if (loopNum + 1 > condition.GetLength(0))
            {
                GetComponent<MoverMotor>().enabled = false;
                //the end of the script.
                panelIndication.SetActive(true);
                beginofT = 9;
                CreateFile();

            }
        }

    }
    public float CheckTheAccuracyOf(float answer1, float correct1)
    {
        float accu = 0;
        float df = System.Math.Abs(correct1 - answer1);
        if (df <= 180)
        {
            accu = df;
        }
        else
        {
            accu = 360 - df;
        }
        return accu;
    }

    public void Rest()
    {
        panelForGuide.SetActive(true);
        goalImage.SetActive(false);
        startImage.SetActive(false);
        Fixation.SetActive(false);
    }
    public void TO()
    {
        //panelForGuide.SetActive(true);
        //goalImage.SetActive(false);
        //startImage.SetActive(false);
        Fixation.SetActive(true);

    }

    public void T1()
    {
        Fixation.SetActive(false);
        //if(conditionIndex[loopNum]<condition.GetLength(0))
        if (loopNum < condition.GetLength(0))
        {
            goalImage.SetActive(true);
            startImage.SetActive(true);
            // UnityEngine.Debug.Log(condition[conditionIndex[loopNum],2]);
            gIMG.texture = Resources.Load(condition[conditionIndex[loopNum], 2]) as Texture;
            sIMG.texture = Resources.Load(condition[conditionIndex[loopNum], 1]) as Texture;
            //OneTrial.AddCondition(condition[conditionIndex[loopNum],2]+"_"+condition[conditionIndex[loopNum],1]) ; 
            OneTrial.AddCondition(condition[conditionIndex[loopNum], 0] + "_" + condition[conditionIndex[loopNum], 4]);
            OneTrial.AddCorrectAnswer(condition[conditionIndex[loopNum], 3]);
        }
    }

    public void T2()
    {
        goalImage.SetActive(false);
        startImage.SetActive(false);
        hasResponded = false;
        // sound.Play(0);
    }

    public void T3()
    {
        //sound.play
        //sound.Play(0);
        //  this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).position;

        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        // this.transform.rotation=Blocker.transform.Find(condition[conditionIndex[loopNum],0]).rotation;

        panelForGuide.SetActive(false);

    }

    // EVENT of section

    public void START()
    {
        beginofT = 6;
        //OneTrial.StartOfWatch();
        onset=Time.time;
        nextTime = Time.time;
        STARTButton.SetActive(false);
    }

    public void ToNextSection()
    {
        beginofT=6;
        SectionFinishedButton.SetActive(false);
        trialCount=0;
        onset=Time.time;
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

    public void EnterTheOfficial()
    {
        if(SceneManager.GetActiveScene().name=="RecallTaskTry")
        {
             SceneManager.LoadScene("RecallTaskTry");
        }
        if(SceneManager.GetActiveScene().name=="RecallTask")
        {
             SceneManager.LoadScene("4aMainMenu");
        }
    }
    public void CreateFile()
    {
        string File_Name = SceneManager.GetActiveScene().name+countingBlock.ToString();//string.Format(map.nameOfSubject, map.ID);
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

    public void CreateSeFile()
    {
        string File_Name = "serialsNumber";//string.Format(map.nameOfSubject, map.ID);
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
                
                foreach(int a in conditionIndex)
                {
                    sr.WriteLine(a);

                }
                //BehavioralData.WriteDownTrial(sr);
                   
            }
        }
    }
}
