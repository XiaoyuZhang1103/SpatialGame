using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;

public class DistanceJudge : MonoBehaviour
{
    public  GameObject Blocker;
    public  GameObject IndicationPanelStart;
    public GameObject IndicationFinish;
    public GameObject DistanceCanvas;
    public GameObject BackButton;
   // private Vector3 facingDirection;
    private  string[,]  condition= {
//  left-red   Right-green  blockerstarting  longerAnserw
{	"62.1"	,	"23"	,	"1", "R"}	,
{	"23"	,	"23"	,	"2","E"}	,
{	"38.1"	,	"23"	,	"3","R"}	,
{	"23"	,	"38.1"	,	"4","L"	}	,
{	"23"	,	"23"	,	"5","E"}	,
{	"23"	,	"62.1"	,	"6","L"}	,
 };
  
  
    private int[] conditionIndex;
    private int loopNum=0;
    private string ANS;
    private string checkTF;
    private bool changePosition=true;

    private float basetime;
    private float TrialBeginTime;
    private float RespondTime;


    public  AudioSource SoundCUE;
    List<string> Trials=new List<string>();
    public MoverMotor MM;

    

  public Vector3 positionOffset= new Vector3(0,0,0);
    
     

    void Start()
    {    conditionIndex=RandomizeWithoutRepeate( condition.GetLength(0),0,condition.GetLength(0)-1);
         IndicationPanelStart.SetActive(true);
         BackButton.SetActive(false);
         this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],2]).position+ positionOffset;
         this.transform.rotation=Quaternion.Euler(0,90,0);
         DistanceCanvas.SetActive(false);
    }

    private void Update() 
    {
        UnityEngine.Debug.Log(loopNum);
     if(loopNum<condition.GetLength(0))
     {
         if(changePosition==true)
      { 
        this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],2]).position+ positionOffset;
        this.transform.rotation=Quaternion.Euler(0,90,0);
         changePosition=false;
         TrialBeginTime=Time.time;
         UnityEngine.Debug.Log("1"+TrialBeginTime);
      } 
         if(Input.GetKeyDown(KeyCode.LeftArrow))
         {ANS="R";}
         if(Input.GetKeyDown(KeyCode.RightArrow))
         {ANS="L";}
         if(Input.GetKeyDown(KeyCode.DownArrow))
         {ANS="E";}

        if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
        RespondTime=Time.time;
        CheckAnswer();
         Trials.Add("TrialBeginTime "+TrialBeginTime+" "+"condition "+condition[conditionIndex[loopNum],1].ToString()+"_"+condition[conditionIndex[loopNum],0].ToString()+" "
                   +"Respontime "+RespondTime+" "+"CorrectAnswer "+ condition[conditionIndex[loopNum],3]+" "+"userAnswer "+ ANS+" "+"Wrong "+ checkTF);
          loopNum=loopNum+1;
          changePosition=true;
          SoundCUE.Play(0);
          if(loopNum==condition.GetLength(0))
          {
              CreateFile();
              DistanceCanvas.SetActive(false);
              IndicationFinish.SetActive(true);
              MM.IfGenerateTrace=true;
          }
        }
     }
    }

   void OnTriggerEnter(Collider other) 
   {
         BackButton.SetActive(true);
   }

   public void BackStart()
   {
       this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],2]).position+ positionOffset;
       this.transform.rotation=Quaternion.Euler(0,90,0);
       BackButton.SetActive(false);
   }

    public void CheckAnswer()
    {
        if(String.Equals(ANS,condition[loopNum,3])==true)
        {
           checkTF="0";
        }
        else
        {
            checkTF="1";
        }
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
   
   public void CloseIntroduction()
   {
       IndicationPanelStart.SetActive(false);
       DistanceCanvas.SetActive(true);
       TrialBeginTime=basetime=Time.time;
       UnityEngine.Debug.Log("0"+TrialBeginTime);
   }
   
    public void EnterTheAngularTask()
    {
       if(SceneManager.GetActiveScene().name=="3dDistance")
        {
          SceneManager.LoadScene("3dAngular");
        } 
       else
       {
            SceneManager.LoadScene("2dAngular");
            
       }
    }
}

