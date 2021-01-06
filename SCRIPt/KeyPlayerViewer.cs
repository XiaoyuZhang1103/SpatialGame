using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlayerViewer : MonoBehaviour
{
    void FixedUpdate()
    {
       
            Viewer();

    }
   
    /// <summary>
    /// the measurement of player viewer.
    /// </summary>
    /// 
    public float rotateSpeedOfViewer = 1;
    public float turnRightIndex = 1;
    public float turnLeftIndex = 1;
    public float lookUp = 1;
    public float lookDown = 1;

    /// <summary>
    /// provide the method of change of viewer
    /// </summary>
    private void Viewer()
    {
        if (Input.GetKey(KeyCode.J))
        {
           // turnRightIndex *= rotateSpeedOfViewer*Time.deltaTime;
             this.transform.Rotate(0, -turnRightIndex, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.L))
        {
           // turnLeftIndex *= rotateSpeedOfViewer * Time.deltaTime;
            this.transform.Rotate(0,turnLeftIndex, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.I))
        {
           // lookUp *= rotateSpeedOfViewer * Time.deltaTime;
            this.transform.Rotate(-lookUp, 0, 0);
        }

        if (Input.GetKey(KeyCode.K))
        {
           // lookUp *= rotateSpeedOfViewer * Time.deltaTime;
            this.transform.Rotate(lookDown, 0, 0);
        }


    }

}

