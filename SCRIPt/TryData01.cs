using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryData01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataStructure myData = new DataStructure();
        Debug.Log(myData.Trials);

        myData.NewTrial("TES");
        Debug.Log(myData.Trials["TES"]);

        myData.NewTrial("TES1");
        myData.NewTrial("TES2");
        foreach (string key in myData.Trials.Keys)
        { Debug.Log(key);
            Debug.Log(myData.Trials[key]);
        }

        RoundData round1 = new RoundData();//you need to create a new round(round1) for each round.
        round1.StartOfWatch();

        round1.AddBehavior(Vector3.zero, Vector3.up, "tryadddB");
        round1.AddBehavior(Vector3.zero, Vector3.down, "tryadddB");
        round1.AddBehavior(Vector3.zero, Vector3.right, "tryadddB");
        round1.AddBehavior(Vector3.zero, Vector3.left, "tryadddB");

       // Debug.Log(round1.PrintBehavior());

      round1.AddError("apple");
        //Debug.Log(round1.PrintError());

        myData.Trials["TES1"].AddRound(round1);
        Debug.Log(myData.Trials["TES1"].Data);

      

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
