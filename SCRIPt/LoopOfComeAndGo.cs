using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


// the script is added to the panels showing after bumping the Goal
// it is an Event related to the button on the Screen "Continue".
public class LoopOfComeAndGo : MonoBehaviour
{
    // The functions of this class are
    //controlling the loop (the sequence of S2G,G2S) of round and route(the sequence of scences in same map)
    //write down all the data during the navigation in the same map to a file.

    public MoverMotor roundOfRoute;
    public DataStructure map=new DataStructure();

    public GameObject Goal;
    public GameObject Player;

    public IfBumpGoal gateUse;// to activate the panel showed after half of the round complied.
   public IfMakeWrongChoice wrongTimes;// to count the mistakes in each round.
    public Timer clock;// to reset the Timer after half of the round complied.

    private Vector3 PlayerdefaultPosition=new Vector3 (10,0.11f,1.5f);
    private Quaternion GoalDefaultRotation = Quaternion.Euler(0, 0, 0);

    //private  int countIndexOfScene=1 ;

    // exchange the position of player and Goal to control the round.
 
    
    // An Event related to the Button"Continue"
    public void CanGoToNextRoute()
    {
        string s = roundOfRoute.TemporalMark;
        Debug.Log(s);
      // string s2=roundOfRoute.roundOfMotor.PrintError();
        gateUse.gate = false;
        clock.second = 0;

        if (wrongTimes.count == 0 && s== "Goal2Start")
         //如果该地图的这条路径已经来回无错通关一次
        {  // if (countIndexOfScene < 2)//3
            if (SceneManager.GetActiveScene().name!="Map1_3DR3"&&
                SceneManager.GetActiveScene().name != "Map1_2DR3"&&
                SceneManager.GetActiveScene().name != "Map2_3DR3"&&
                SceneManager.GetActiveScene().name != "Map2_2DR3")
         //如果该地图的这条路径已经来回无错通关一次，且通关的场景并不是该地图的第三条路径
        //则将该条路径收集到的 list“Data”全部保存到dictionary"Trials"中，该字典的索引是场景名
        //同时进入下一条路径.
            {
                map.NewTrial(SceneManager.GetActiveScene().name);
                //countIndexOfScene++;
                  Debug.Log(SceneManager.GetActiveScene().name);
                CreateFile();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
               
            }
            else
            { //若该场景为路径三的最后一次通关
                //则将该条路径收集到的 list“Data”全部保存到dictionary"Trials"中，该字典的索引是场景名
                //使continue键无效，通过摧毁其上的Button脚本
                //执行congratulation,写下并保存数据到file中，游戏退出，
                map.NewTrial(SceneManager.GetActiveScene().name);
                this.GetComponentInChildren<Text>().text = string.Format("YOU PASS ALL THE ROUTES IN THIS MAP!");
                CreateFile();
                Destroy(GetComponentInChildren<Button>());
            }
        }
        else
            EchangeStartAndGoal(s);
    }

    private void EchangeStartAndGoal(string s)
    {

        if (s == "Start2Goal")
        {
            roundOfRoute.roundOfMotor.AddFromToMark("Goal2Start");
            roundOfRoute.TemporalMark = "Goal2Start";

            if (SceneManager.GetActiveScene().name == "Map1_3DR1"|| SceneManager.GetActiveScene().name == "Map1_2DR1" )
            {

                PlayerdefaultPosition =  new Vector3(10.5f, 0.11f, 1.5f);
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
            if (SceneManager.GetActiveScene().name == "Map1_3DR2" ||SceneManager.GetActiveScene().name == "Map1_2DR2")
            {
                PlayerdefaultPosition = new Vector3(10.5f, 0.11f, 10.5f);
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
            if (SceneManager.GetActiveScene().name == "Map1_3DR3" || SceneManager.GetActiveScene().name == "Map1_2DR3")
            {
                PlayerdefaultPosition = new Vector3(10.5f, 0.11f, 5.5f);
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
            if (SceneManager.GetActiveScene().name == "Map2_3DR3" || SceneManager.GetActiveScene().name == "Map2_2DR3")
            {
                PlayerdefaultPosition = new Vector3(1.5f, 0.11f, 1.5f);
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
            if (SceneManager.GetActiveScene().name == "Map2_3DR2" || SceneManager.GetActiveScene().name == "Map2_2DR2")
            {
                PlayerdefaultPosition = new Vector3(1.5f, 0.11f, 10.5f);
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
            if (SceneManager.GetActiveScene().name == "Map2_3DR1" || SceneManager.GetActiveScene().name == "Map2_2DR1")
            {
                PlayerdefaultPosition = new Vector3(10.5f, 0.11f, 1.5f);//0.3
                GoalDefaultRotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if (s == "Goal2Start")
        {
            roundOfRoute.roundOfMotor.AddFromToMark("Start2Goal");
            roundOfRoute.TemporalMark = "Start2Goal";
            if (SceneManager.GetActiveScene().name == "Map1_3DR1" ||
                SceneManager.GetActiveScene().name == "Map1_3DR2" ||
                SceneManager.GetActiveScene().name == "Map1_3DR3" ||
                SceneManager.GetActiveScene().name == "Map1_2DR1" ||
                SceneManager.GetActiveScene().name == "Map1_2DR2" ||
                SceneManager.GetActiveScene().name == "Map1_2DR3")
            {
                PlayerdefaultPosition = new Vector3(1.5f, 0.11f, 10.5f);
                GoalDefaultRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                PlayerdefaultPosition = new Vector3(5.5f, 0.11f, 8.5f);
                GoalDefaultRotation = Quaternion.Euler(0, 0, 0);
            }
          
            wrongTimes.count = 0;//once the player finished a round (S2G,G2S), wrong time count return to 0.

        }
        Exchange(s);
        this.gameObject.SetActive(false);
    }

 

    private void Exchange(string s)
    {
        
        Player.transform.position = Goal.transform.position;
        Player.transform.rotation = GoalDefaultRotation;
        Goal.transform.position = PlayerdefaultPosition;
        
    }


    /// <summary>
    /// create the file.txt, write the variable of DataStructure on thee file.把class整个写出来的方法组
    /// </summary>
    /// <param name="File_Name"></param>
    public void CreateFile()
    {
        string File_Name = SceneManager.GetActiveScene().name;//string.Format(map.nameOfSubject, map.ID);
        // create the path for the file.
        string pathString = @"D:\uinity pa\3dimensional_mapmoldel\Assets\BehavioralData";
        pathString = System.IO.Path.Combine(pathString, File_Name);

        if (File.Exists(pathString))
        {
          Debug.Log(File_Name);
            return;
        }
        else
        {
            using (StreamWriter sr = new StreamWriter(pathString))
            {
                map.WriteDownTrial(sr);
                roundOfRoute.roundOfMotor.WriteDownFromTo(sr);
                roundOfRoute.roundOfMotor.WriteDownBehavior(sr);
                wrongTimes.Object1.roundOfMotor.WriteDownError(sr);
                   
            }
        }
    }
    }
