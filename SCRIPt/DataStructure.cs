using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



//+++++++++++++++++ here is the global script for record all the input data in each round of game.+++++++//
//                                +++++++++++++++++game name《Dimentional Map》.+++++++//

/// <summary>
/// create a class " DataStructure "containing all the data needed to be recorded during the Learningtask Game.
/// </summary>
public class DataStructure //:MonoBehaviour 
{
    public static DataStructure map;

    //Declare and Initialize the string type variables used in global script only once.
    public string nameOfSubject;
    public string ID;
    public string mapName;
    public string dimension;

    /* private void Awake()
     {
         if (map == null)
         {
             DontDestroyOnLoad(gameObject);
             map = this;
         }

         else if (map != null)
         {
             Destroy(gameObject);
         }
     }*/

    /// <summary>
    ///  Declare and initialize the dictionary, <>Tkey,<>T type
    /// </summary>
    public Dictionary<string, Trials> Trials;// dictionary ,link the key to the type of data you defined.

    //function1:instantiate the dictionary "Trials".
    // public DataStructure()
    public DataStructure()
    {
        Trials = new Dictionary<string, Trials>();
    }

    // function2: assignment to the dictionary "Trials".
    //name: the dimensions of map and the route number.
    public void NewTrial(string name)
    {
        Trials.Add(name, new Trials());//add new element to "Trials";
    }

    // function
    public void PrintTrial()
    {
        string s = "";
        foreach (KeyValuePair<string, Trials> entry in Trials)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "/n";
        }
    }

    public void WriteDownTrial(StreamWriter sr)
    {
        string s = "";
        foreach (KeyValuePair<string, Trials> entry in Trials)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "/n";
        }
        sr.WriteLine(s);
    }
}




/// <summary>
/// Define a class "TrialData" involving all the data recorded in each round(start 2 goal || goal 2 start);
/// "TrialData" is also the content of dictionary "DataStructure";
/// </summary>
public class Trials
{
    //Inside of "TrialData", let's create a List<type of data stored in this list> "Data"
    //by the declaration as below;
    public List<RoundData> Data;

    //function1: instantiation of "Data";
    public Trials()
    {
        Data = new List<RoundData>();
    }

    //function2: assignment of "Data".
    public void AddRound(RoundData data)// data in each round
    {
        Data.Add(data);
    }
}



/// <summary>
/// Define the class "RoundData" that is the content of the list "Data".
/// all the input of one subject/player is recoreded in this class.
/// </summary>
public class RoundData
{
    // Initialize the dictionary<key, data type> "Behavior" 
    //to store all the "BehavioralData" from the player in a time serials "TimeSpan"
    // a structure builded by the Namespace "System" for representing the time interval.
    public Dictionary<TimeSpan, BehavioralData> Behavior;

    // Initialize the dictionary<key, data type> "Errors" 
    //to store all the "ErrorData" from the player in a time serials "TimeSpan"
    // a structure builded by the Namespace "System" for representing the time interval.
    public Dictionary<TimeSpan, ErrorData> Errors;

    //Initialize a class "stopwatch", provided by the difined namespace "System.Diagnostics" 
    //with methods and properities measuring the elapsed time accurately.
    private Stopwatch stopwatch;

    public Dictionary<TimeSpan,MarkData> Mark ;

    // function1: instantialize the two dictionary.
    public RoundData()/////////////////////////////////////////
    {
        Behavior = new Dictionary<TimeSpan, BehavioralData>();
        Errors = new Dictionary<TimeSpan, ErrorData>();
        stopwatch = new Stopwatch();
        Mark = new Dictionary<TimeSpan, MarkData>();
    }

    // function2: pack the method  "stopwatch.Start()"
    public void StartOfWatch()
    {
        stopwatch.Start();// start or resume 重置 , and than measure the interval of elapsed time
    }

    //function3: assignment to dictionary "Behavior".
    public void AddBehavior(Vector3 position2, Vector3 direction3, string input3)
    {
        Behavior.Add(stopwatch.Elapsed, new BehavioralData(position2, direction3, input3));

    }

    //function4: assignment to dictionary "Errors".
    public void AddError(string errors)
    {
        Errors.Add(stopwatch.Elapsed, new ErrorData(errors));
    }

    // function5: assignment to Mark of round "fromTo".
    public void AddFromToMark(string fromTo1)
    {
        Mark.Add(stopwatch.Elapsed,new MarkData (fromTo1));
    }

    //function6: print out the indexes and contents of dictionary "Behavior".
    public String PrintBehavior()
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, BehavioralData> entry in Behavior)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
           
        }
        return s;
    }

    //function7: print out the indexes and contents of dictionary "Errors".
    public string PrintError()
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, ErrorData> entry in Errors)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
        }
        return s;
    }
    
    //function8: print out the mark "fromTo".
    public string PrintMark()
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, MarkData> entry in Mark)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
        }
        return s;
    }

    
    

    //function9: print out the indexes and contents of dictionary "Behavior".
    public void WriteDownBehavior(StreamWriter sr)
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, BehavioralData> entry in Behavior)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
           
        }
        sr.WriteLine(s);
    }

    //function10: print out the indexes and contents of dictionary "Errors".
    public void WriteDownError(StreamWriter sr)
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, ErrorData> entry in Errors)
        {
            s += entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
           
        }
         sr.WriteLine(s);
    }

    //function11: print out the mark "fromTo".
    public void WriteDownFromTo(StreamWriter sr)
    {
        string s = "";
        foreach (KeyValuePair<TimeSpan, MarkData> entry in Mark)
        { 
          s+= entry.Key.ToString() + ", " + entry.Value.ToString() + "\n";
        }
         sr.WriteLine(s);
    }
    
}

public class MarkData
{
    public string FromTo;

    public MarkData(string FromTo1)
    {
        FromTo = FromTo1;
    }

    public override string ToString()
    
    {
        return FromTo;
    }
}

/// <summary>
/// Define the class "ErrorData" to store all the name of errors in each round.
/// This class is the content of dictionary "Errors".
/// </summary>
public class ErrorData
{
    public string ID;

    public ErrorData(string ID1)
    {
        ID = ID1;
    }
    public override string ToString()
    {
        return ID;
    }
}


/// <summary>
/// Define the class "BehavioralData" to store all the player related behavioral data.
/// This class is the content of dictionary "Behaviors".
/// </summary>
public class BehavioralData
{

    public Vector3 postion;
    public Vector3 direction;
    public string input;
    
    public BehavioralData(Vector3 position1, Vector3 direction1, string input1)
    {
        postion = position1;
        direction = direction1;
        input = input1;

    }

    override public string ToString()
    {
       
        return postion.x + ", " + postion.z + ", " + direction.y + ", " + input;
    }


}

/*
/// <summary>
/// 已经将该方法组放到classDatastructure中
/// </summary>
public class WriteData
{
    DataStructure map;
    /// <summary>
    /// create the file.txt, write the variable of DataStructure on thee file.查找是否有可以直接把Dictionary整个写出来的方法组
    /// </summary>
    /// <param name="File_Name"></param>
    public void CreateFile()
    {
        string File_Name = string.Format(map.nameOfSubject,map.ID);
        // create the path for the file.
        string pathString = @"E:\unity project\3dimensional_map\Assets\BehavioralData";
        pathString = System.IO.Path.Combine(pathString, File_Name);
        Console.WriteLine("path to my file:{0}", pathString);

        if (File.Exists(pathString))
        {
            Console.WriteLine("The {0} has exsisted.", File_Name);
            return;
        }
        else
        {
            using (FileStream sr = new FileStream(pathString,FileMode.Create))
            {
                string s;
                s = string.Format(" This is the  rawdata file of 2-3DMap navigation.\nSubject: {0} \n ID: {1} \n Map Name: {2} /n Map Dimension: {3} \n",
                                            map.nameOfSubject, map.ID, map.mapName, map.dimension);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(sr, map);
                sr.Close();
            }
        }
    }

 }*/


