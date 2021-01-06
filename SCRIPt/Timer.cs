using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   public Text txtTimer;
    private float nextTime=1;
   public float  second=0;
    public  int min;
  //  public IfBumpGoal timerFinish;
    public LearningTask learningTask;
    public int minuteLimit=20;
    public GameObject Indication;
    public MoverMotor MM;
    private bool ifStart=false;
    public GameObject StartButtoon;
    public float baseTime;

    // Start is called before the first frame update
    void Start()
    {
        txtTimer = this.GetComponentInChildren<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        CountTimeInEachRound();
         if (min==minuteLimit && ifStart==true)
         {  
            MM.IfGenerateTrace=true;
            Indication.SetActive(true);
         }
        //if bump the goal, the timer return 00:00;
    }

    private void CountTimeInEachRound()
    {
       // if (Time.time > nextTime && timerFinish.gate == false&& learningTask.timerStart==true)
       //  if (Time.time > nextTime && learningTask.timerStart==true)
           if (Time.time > nextTime && ifStart==true)
        {
            second++;
            min = (int)(second / 60);
            txtTimer.text = string.Format("{0}:{1}", min, second % 60);
            nextTime = Time.time + 1;
        }    
        
    }

    public void StartGame()
    {
        ifStart=true;
        StartButtoon.SetActive(false);
        baseTime=Time.time;

    }

    public void EnterTheNextGame()
    {
        if(SceneManager.GetActiveScene().name=="43dFree")
        {
              SceneManager.LoadScene("43dConfi2");
        }
        if(SceneManager.GetActiveScene().name=="42DBFree")
        {
              SceneManager.LoadScene("42DBConfi");
        }
        if(SceneManager.GetActiveScene().name=="42dFree")
        {
            SceneManager.LoadScene("42dConfi2");
            UnityEngine.Debug.Log("To the next");
        }
    }
}
