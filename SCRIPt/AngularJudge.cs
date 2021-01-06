using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;


public class AngularJudge : MonoBehaviour
{
    public  GameObject Blocker;
    public  GameObject IndicationPanelStart;
    public GameObject IndicationFinish;
   // private Vector3 facingDirection;
    private  string[,]  condition= {
//  Angular    blocker answer! in fact it is not necessary to write the same thing twice.
{	"15"	,	"A3","15"}	,
{	"30"	,	"A2","30"}	,
{	"45"	,	"A1","45"}	,
{	"60"	,	"B4","60"}	,
{	"75"	,	"B3","75"}	,
{	"90"	,	"B2","90"}	,
{	"105"	,	"C4","105"}	,
{	"120"	,	"C2","120"}	,
{	"135"	,	"D4","135"}	,
{	"150"	,	"D2","150"}	,
{	"165"	,	"E3","165"}	,
{	"180"	,	"E1","180"}	,
 };
  
  
    private int[] conditionIndex;
    private int loopNum=0;
    public GameObject AngularInputField;
    public GameObject CheckButton;
    public GameObject BlackScreen;

    private float TimeOnBlack;
    private float basetime;
    private float Time0Begin;
    private float TimeCheck;

    public float DurationOfBlack=2.0f;
    private bool ifCheck=false;
    private bool ifblack=false;
    public AudioSource WrongWarning;
     public Vector3 positionOffset= new Vector3(0,0,0);
    private string answerOFAnugular;
    private int accuracyOfAns;
    List<string> Trials=new List<string>();
    public MoverMotor MM;
    

 
    
     

    void Start()
    {    conditionIndex=RandomizeWithoutRepeate( condition.GetLength(0),0,condition.GetLength(0)-1);
         IndicationPanelStart.SetActive(true);
         this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],1]).position+ positionOffset;
         UnityEngine.Debug.Log(Blocker.transform.Find(condition[conditionIndex[loopNum],1]).position);
         this.transform.rotation=Quaternion.Euler(0,180,0);
         CheckButton.SetActive(false);
         AngularInputField.SetActive(false);
         
    }

    private void Update() 
    {
       // UnityEngine.Debug.Log(loopNum);
     if(loopNum+1<condition.GetLength(0))
     {
         if(ifCheck==true)
       { 
        loopNum++;
        UnityEngine.Debug.Log(loopNum);
        this.transform.position=Blocker.transform.Find(condition[conditionIndex[loopNum],1]).position+ positionOffset;
        this.transform.rotation=Quaternion.Euler(0,180,0);
        ifCheck=false;
        //Trials.Add("Blcoker "+ condition[loopNum,1]+" "+"Condition "+condition[loopNum,0].ToString()+" "
        //          +"UserAns "+ answerOFAnugular+" "+"Difference "+ accuracyOfAns);
       } 
       if(Time.time>=TimeOnBlack+DurationOfBlack && ifblack==true)
        {
          Time0Begin=Time.time;
          ifblack=false;
          ifCheck=true;
          BlackScreen.SetActive(false);
        }     
     }
     
    }

  public void ToTheNextAngularJudge()
  {
      answerOFAnugular= GetFromInputField(AngularInputField);
      if(Int16.Parse(answerOFAnugular)<=180)
     { 
         accuracyOfAns=Int16.Parse(answerOFAnugular)-Int16.Parse(condition[conditionIndex[loopNum],0]);
          BlackScreen.SetActive(true);
          ifblack=true;
         TimeOnBlack=Time.time;
         TimeCheck=TimeOnBlack;
         Trials.Add("TrailBeginTime "+Time0Begin+" "+"Blcoker "+ condition[conditionIndex[loopNum],1].ToString()+" "+"Condition "+condition[conditionIndex[loopNum],0].ToString()+" "
                  +"CheckTime "+TimeCheck+" "+"UserAns "+ answerOFAnugular+" "+"Difference "+ accuracyOfAns);
          UnityEngine.Debug.Log(condition[conditionIndex[loopNum],0]);
          AngularInputField.GetComponent<InputField>().text="";
          ////////////////////////
     }
     else
     {
       WrongWarning.Play(0);
     }
     if(loopNum+1==condition.GetLength(0))
         {
         BlackScreen.SetActive(false);
         CreateFile();
         CheckButton.SetActive(false);
         AngularInputField.SetActive(false);
         IndicationFinish.SetActive(true);
         MM.IfGenerateTrace=true;
         }
  }

  

 private string GetFromInputField(GameObject neededText)
    {
        var inputText = neededText.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        // se.AddListener(SubmitLine);
        inputText.onEndEdit = se;
         return inputText.text;
     
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
       CheckButton.SetActive(true);
       AngularInputField.SetActive(true);
       Time0Begin=basetime=Time.time;
   }
   
    public void END()
    {
      
          SceneManager.LoadScene("4aMainMenu");
        
    }
}

