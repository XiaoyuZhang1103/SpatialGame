using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenueFunction : MonoBehaviour
{
    
    public  GameObject InstructionIT;

    public void EnterNextPage()
    {
        Debug.Log("begin of function");
        //SceneManager.LoadScene("map1_zhang");
        //场景名字，索引名字
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Debug.Log("end of function");
    }

    public void EnterInstruction()
    {
    //  GameObject InstructionIT=  GameObject.FindGameObjectWithTag("Instruction");
        InstructionIT.SetActive(true);
    }

    public void CancleInstruction()
    {
        InstructionIT.SetActive(false);
    }
    public void BackToInstruction()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit" );
    }

    public void BackToLastPage()
    {
        Debug.Log("begin of function3");
        //SceneManager.LoadScene("map1_zhang");
        //场景名字，索引名字
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("end of function3");
        
    }
}
