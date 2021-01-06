using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    //singleton: only initiate once;
    public static GlobalScript Instance;
    public DataStructure map1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);    
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
}

