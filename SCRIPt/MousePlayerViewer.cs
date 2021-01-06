using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerViewer : MonoBehaviour
{
    void FixedUpdate()
    {

     var hor = Input.GetAxis("Horizontal");
      var ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
           Movement(hor, ver);

     //   float x = Input.GetAxis("Mouse X");
       // float y = Input.GetAxis("Mouse Y");

        //if (x != 0 || y != 0)
          //  Viewer(x, y);

    }
    /// <summary>
    /// the measurement of player movement.
    /// </summary>

    public float moveSpeed = 0.1f;
    private void Movement(float ho1, float ve1)
    {
        ho1 *= moveSpeed ;
        ve1 *= moveSpeed ;
        this.transform.Translate(ho1, 0, ve1);
    }


    /// <summary>
    /// the measurement of player viewer.
    /// </summary>
    public float rotateSpeed = 1;
    private void Viewer(float x1, float y1)
    {
        x1 *= rotateSpeed;
        y1 *= rotateSpeed;

        this.transform.Rotate(-y1, 0, 0);
        this.transform.Rotate(0, x1, 0, Space.World);
    }

}
