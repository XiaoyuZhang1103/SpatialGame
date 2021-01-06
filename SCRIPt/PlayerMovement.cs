using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed=1;
    public float moveSpeed=0.01f;

    public void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
        {
            RotationOfViewer(hor, ver);
            this.transform.Translate(0, 0, moveSpeed);
        }
    }

    private void RotationOfViewer(float hor, float ver)
    {
        Quaternion dir = Quaternion.LookRotation(new Vector3(hor, 0, ver));
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, rotateSpeed);

      
    }
}
