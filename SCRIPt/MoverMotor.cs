using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class MoverMotor : MonoBehaviour
{
    public float rotateSpeed = 0.85f;
    public float moveSpeed = 0.01f;
    public Rigidbody rb;
    public string TemporalMark;

    public DataStructure map;
    public RoundData roundOfMotor;
    public IfBumpGoal startToWrite;
    
    public GameObject StartBlocker;

    public Quaternion BackTOPosition;

    List<string> Trace=new List<string>();

    public bool IfGenerateTrace=false;

    public  Vector3 offset=new Vector3(0,0,0);

    public Timer Clock;
    float  ClockTime;

    string colliderName;

    /////////////////////////////////////////////
    public GameObject B2dCamera;

    public void Start()
    {
        if(SceneManager.GetActiveScene().name!="3dDistance"&&SceneManager.GetActiveScene().name!="2dDistance"
        &&SceneManager.GetActiveScene().name!="3dAngular"&&SceneManager.GetActiveScene().name!="2dAngular")
     {
         this.transform.position=StartBlocker.transform.position + offset;}
         Debug.Log(this.transform.position);
         roundOfMotor= new RoundData();
         roundOfMotor.StartOfWatch();
         roundOfMotor.AddBehavior(Vector3.zero, Vector3.up, "Start");
         roundOfMotor.AddFromToMark("Start2Goal");
         TemporalMark = "Start2Goal";
    }

       

    public void FixedUpdate()

    {
       

          string key = "";

        //InPut Of PlayerUpArrow
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.R)||Input.GetKey(KeyCode.UpArrow)&&SceneManager.GetActiveScene().name!="RecallTask"&&SceneManager.GetActiveScene().name!="RecallTaskTry")
        {
            rb.MovePosition(transform.forward * moveSpeed + rb.position);
            key += "U";
            //Debug.Log("U");
            //Debug.Log(map.nameOfSubject);
        }
        
     

        if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.E)||Input.GetKey(KeyCode.DownArrow)&&SceneManager.GetActiveScene().name!="RecallTask"&&SceneManager.GetActiveScene().name!="RecallTaskTry")
        {
            rb.MovePosition(-transform.forward * moveSpeed + rb.position);
            key += "D";
            // Debug.Log("D");
        }
        if (Input.GetKey(KeyCode.D)&&SceneManager.GetActiveScene().name!="RecallTask"&&SceneManager.GetActiveScene().name!="RecallTaskTry")
        {
           rb.MovePosition(transform.right * moveSpeed + rb.position);
            key += "R";
            // Debug.Log("R");
        }
        if (Input.GetKey(KeyCode.A)&&SceneManager.GetActiveScene().name!="43DRecallTask"&&SceneManager.GetActiveScene().name!="43DRecallTaskTry")
        {
            rb.MovePosition(-transform.right * moveSpeed + rb.position);
            key += "L";
            //Debug.Log("L");
        }
         if (Input.GetKey(KeyCode.B)||Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed, Space.World);
            key += "Tr";
            // Debug.Log("R");
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if(SceneManager.GetActiveScene().name=="42DBFree"||SceneManager.GetActiveScene().name=="42DBConfi")
        {
             B2dCamera.transform.Rotate(new Vector3(0,1,0)*rotateSpeed, Space.World);
        }
           
        }
        if (Input.GetKey(KeyCode.G)||Input.GetKey(KeyCode.Q)||Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotateSpeed, Space.World);
            key += "Tl";
            //Debug.Log("L");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if(SceneManager.GetActiveScene().name=="42DBFree"||SceneManager.GetActiveScene().name=="42DBConfi")
        {
             B2dCamera.transform.Rotate(new Vector3(0,-1,0)*rotateSpeed, Space.World);
        }
        }

        if (key != "")
        {
        roundOfMotor.AddBehavior(rb.position, transform.forward, key );
       // Debug.Log("direction: " + transform.forward);
       // Debug.Log("position: " + rb.position);
        BackTOPosition=rb.rotation;
         if(SceneManager.GetActiveScene().name=="42dFree"||SceneManager.GetActiveScene().name=="43dFree" )
     {
        ClockTime=Time.time-Clock.baseTime;
     }
        else
        {ClockTime=Time.time;}
      //  Debug.Log("Time "+Time.time);
       // Debug.Log("Base "+ClockTime);
      //  Debug.Log("STOP "+Clock.baseTime);
       Trace.Add("Time "+ClockTime.ToString()+" Position "+rb.position.ToString()+" Facing "+transform.forward.ToString()+" key "+key+" signal "+colliderName);
       colliderName="";
        }

        if (key=="")
        {
           rb.angularVelocity=new Vector3(0,0,0);
           rb.velocity=new Vector3(0,0,0);
        }

        if(IfGenerateTrace==true)
        {
            TraceOfUser();
            IfGenerateTrace=false;
        }
     
    }

    public void TraceOfUser()
    {
       string File_Name = "TraceOf"+SceneManager.GetActiveScene().name;//string.Format(map.nameOfSubject, map.ID);
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
                
                foreach(string a in Trace)
                {
                    sr.WriteLine(a);

                }
                
                   
            }
        }
    }
 


private void OnTriggerEnter(Collider other) 
{
Debug.Log("collider"+ other.name);
colliderName=other.name;
}

}
