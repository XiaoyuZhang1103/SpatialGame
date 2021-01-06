using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;


public class RecallTaskData //定义
{
    public string nameOfSubject;
    public string ID;
    public string mapName;

    public Dictionary<int,EachTrial> TrialInRecall;//定义
    
    public RecallTaskData()//实例化instantiate the class
    {
        TrialInRecall = new Dictionary<int,EachTrial>();//实例化instantiate the dictionary
    }

    public void AddTrial(int dataNum)
    {
        TrialInRecall.Add(dataNum,new EachTrial());// instantiate the component of dictionary
    }

    public string PrintTrial()
    {
        string s ="";
        foreach (KeyValuePair<int,EachTrial> entry in TrialInRecall)
        //对于每对关键词-值配对 在 TrialInRecall字典里的
        {
             s+= entry.Key.ToString()+ ""+ entry.Value.ToString()+"\n";
             
        }
              return s;
    }

    public void WriteDownTrial(StreamWriter sr)
    {
        string s="";
        foreach(KeyValuePair<int,EachTrial> entry in TrialInRecall)
        {
            s+= entry.Key.ToString()+""+entry.Value.ToString()+"\n";
           //s+= entry.Key.ToString()+""+EachTrial.TimeToShowFix.ToString();
        }
        sr.WriteLine(s);
    }
}

public class EachTrial
{

    public string iImgOfGoal;
    public string imgOfStart;

    public string conditionOfDirection;
    public float Rest;
    public float TimeToShowFix;
    public float TimeToShowGS;
    public float TimeToShowBlack;
    public float TimeToshowSound;
    public float TimeToShowAnguler;
    public float TimeToRespond;
    public float RestShowTime;
    public Vector3 SubjectRotation;

    public float difference;
    public string correctAnswer;

    //Initialize a class "stopwatch", provided by the difined namespace "System.Diagnostics" 
    //with methods and properities measuring the elapsed time accurately.
   // public Stopwatch stopwatch;
   
    //instantiate the StopWatch;
    // and prepare for the instantiate of eachtrial in dictionary TrialInRecall
    public EachTrial()
    {
       // stopwatch = new Stopwatch();              
    }

    public void AddCondition(string Condition)
    {
      conditionOfDirection= Condition;
        
    }
    
    public void AddREST(float REST1)
    {
       Rest=REST1;  
    }

    public void AddRestShowTime(float Resttime)
    {
        RestShowTime=Resttime;
    }

    public void AddTimeToShowFixation(float TFix)
    {
       TimeToShowFix=TFix;  
    }
    public void AddTimeToShowGS(float TGS)
    {
          TimeToShowGS=TGS;
    }

    public void AddTimeToShowBlack(float TBlack)
    {
      TimeToShowBlack=TBlack;
    }

    public void AddTimeToShowSound(float TSound)
    {
        TimeToshowSound=TSound;
    }
    public void AddTimeToShowAnguler(float TAnguler)
    {
     TimeToShowAnguler=TAnguler;
    }
    public void AddTimeToRespond(float RT)
    {
     TimeToRespond=RT;
    }
    public void AddDirection(Vector3 Rotation)
    {
       SubjectRotation=Rotation;
    }
    public void AddAccuracy(float Dif)
    {
  
        difference=Dif;
    }
    
    public void AddCorrectAnswer(string correct)
    {
       correctAnswer=correct;
    }

    public string PrintOneTrial()
    {
        string s="";
        s+="Rest "+Rest+" "+"RestShowTime "+RestShowTime+" "+"FixationShowTime "+TimeToShowFix.ToString()+" "+"ConditionShowTime "+TimeToShowGS.ToString()+" "
          +"BlackShowTime "+TimeToShowBlack.ToString()+" "+"SoundShowTime "+ TimeToshowSound.ToString()+" "+"ResondTime "+ TimeToRespond.ToString()+" "+"Condition "+conditionOfDirection+" "
          +"SubjectAnswer "+SubjectRotation.ToString()+" "+"Accuracy "+difference.ToString()+" "+"CorrectAns "+correctAnswer;//+"\n";
          return s;
    }
    public void WriteDownOneTrial(StreamWriter sr)
    {
        string s="";
        s+="Rest "+Rest+" "+"RestShowTime "+RestShowTime+" "+"FixationShowTime "+TimeToShowFix.ToString()+" "+"ConditionShowTime "+TimeToShowGS.ToString()+" "+" "
          +"BlackShowTime "+TimeToShowBlack.ToString()+" "+"SoundShowTime "+ TimeToshowSound.ToString()+" "+"ResondTime "+ TimeToRespond.ToString()+" "+"Condition "+conditionOfDirection+" "
          +"SubjectAnswer "+SubjectRotation.ToString()+" "+"Accuracy "+difference.ToString()+" "+"CorrectAns "+correctAnswer;
        
        sr.WriteLine(s);
    }
    public void StartOfWatch()
    {
        // stopwatch.Start();
    }

}
