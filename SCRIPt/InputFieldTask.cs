using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// attach this script to canvas
/// </summary>
public class InputFieldTask : MonoBehaviour
{
   // public GlobalScript Instance;
    public DataStructure map=new DataStructure();

    public GameObject nameText;
    public GameObject numberText;
    public GameObject groupOfMapDimension;
    private string nameOfP;
    private string numOfP;
    public string groupOfP;
    private string fileName;


    public void IfCheck()
    {
        GetComponent<Text>().text = string.Format(
                "Welcome.");
        nameOfP = GetFromInputField(nameText);
        numOfP = GetFromInputField(numberText);
        groupOfP = GetFromInputField(groupOfMapDimension);
        Debug.Log(numOfP.Length);
        if (numOfP.Length == 2)
        {
           map.nameOfSubject = nameOfP;
             map.ID = numOfP;
             fileName = FileNameBuilder(map.nameOfSubject, map.ID);
            MapStructure();
          CreateFile(fileName);
           Debug.Log("check the file.");
        }
        if (nameOfP.Length==0||groupOfP .Length==0|| numOfP.Length != 2)
        {
            GetComponent<Text>().text = string.Format(
                "Your name or serials number is empty or the number is wrong, ask the producer for help.");

        }
    }


    /// <summary>
    /// Get input of players from Inputfiled
    /// </summary>
    /// <param name="neededText"></param>
    /// <returns></returns>
    private string GetFromInputField(GameObject neededText)
    {
        var inputText = neededText.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        // se.AddListener(SubmitLine);
        inputText.onEndEdit = se;
         return inputText.text;
     
    }
    /// <summary>
    /// debug
    /// </summary>
    /// <param name="arg"></param>
    private void SubmitLine(string arg)
    {
        Debug.Log(arg);
     
    }


    /// <summary>
    /// combine the name for file.txt
    /// </summary>
    private string FileName;
    private string FileNameBuilder(string name, string num )
    {
        return FileName = string.Format("{0}{1}", num, name);
    }

    private void MapStructure()
    {
        string s = groupOfP;
        int length = s.Length;
        switch (length)
        {
            case 1:
                map.mapName = "M1";
                map.dimension = "3D";
                break;
            case 2:
                map.mapName = "M2"; map.dimension = "2D";
                break;
            case 3:
                map.mapName = "M3"; map.dimension = "2B";
                break;
            case 4:
                map.mapName = "Distance"; map.dimension = "2D";
                break;

             case 5:
                map.mapName = "Distance"; map.dimension = "3D";
                break;
        }
      }

        public void DeliverToSpecialMapStructure()
    {
        Debug.Log("has jumped");
        string s = groupOfP;
        int length = s.Length;
        switch (length)
        {
            case 1:
                SceneManager.LoadScene("43dFree");
                break;
            case 2:
                SceneManager.LoadScene("42dFree");
                break;
            case 3:
                SceneManager.LoadScene("42DBFree");
                break;
             case 4:
                SceneManager.LoadScene("2dDistance");
                break;

             case 5:
                SceneManager.LoadScene("3dDistance");
                break;

        }
    }

    ////moving

    /// <summary>
    /// create the file.txt, write the variable of DataStructure on thee file.查找是否有可以直接把Dictionary整个写出来的方法组
    /// </summary>
    /// <param name="File_Name"></param>
    public void CreateFile(string File_Name)
    {
        // create the path for the file.
        string pathString = @"D:\uinity pa\RecTanMinusTime\Assets\BehavioralData";
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
                sr.WriteLine("This is the  rawdata file of 2-3DMap navigation.\n");
                sr.WriteLine("the number and name of the subject are {0} .\n ", File_Name);
                sr.WriteLine("there are 4 type of behavior were recorded as below:\n");
                sr.WriteLine(" Subject: {0} \n ID: {1} \n Map Name: {2} \n Map Dimension: {3} \n",
                                             map.nameOfSubject, map.ID, map.mapName, map.dimension);
                // sr.WriteLine("Map);
                sr.Close();
            }
        }

    }
}
