using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfBumpGoal : MonoBehaviour
{
    public GameObject panelFinish;
    public Timer clock;
    private Text finalLine;
    private string Timer1;
    public bool gate;

    private void Start()
    {
        gate = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter--" + collision.collider.name);
       
        FinishedGUI();
       

    }


    //the function would run after the goal in this round was achieve.
    private void FinishedGUI()
    {
        gate = true;
        panelFinish.SetActive(true);
        finalLine = panelFinish.GetComponentInChildren<Text>();
       

      Timer1 =clock.txtTimer.text;
         finalLine.text = string.Format("Congratulation!you pass the line by  {0} s !",Timer1);
       
        Debug.Log("timer has presented");

       
       
    }
}
