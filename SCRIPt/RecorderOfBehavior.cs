using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


/// <summary>
/// attach this script to Goal
/// </summary>
public class RecorderOfBehavior : MonoBehaviour
{
    public BehavioralData bd;
    public MoverMotor  MM;
    public  List<BehavioralData> recorderRound = new List<BehavioralData>();
    

    public static void WriteDataToFile( string File_Name)
    {
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
            using (StreamWriter sr = File.CreateText(pathString))
            {
                sr.WriteLine("This is the  rawdata file of 2-3DMap navigation."
                    );
                sr.WriteLine("the number and name of the subject are {0} ", File_Name);
                sr.WriteLine("there are 4 types of behavioral data were recorded as below:");
                sr.Close();
            //   foreach(BehavioralData data in MM.round)
                {
                 //  sr.WriteLine(data);
                }

            }
        }
    }

    private void WriteDataToFile(List<BehavioralData> list, string txtFile)
    {

    }
}
