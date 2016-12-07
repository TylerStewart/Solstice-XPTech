using UnityEngine;
using System.Collections;

//
// UNITY testing only... this script is boken.
//


public class MouseControl : MonoBehaviour
{
    Vector3 mousePosition;
    bool wasUp;

    void Awake()
    {
        wasUp = true;
    }

    void Update()
    {
       // if (Input.mousePresent)
     //   {
            Vector3 rotation = new Vector3( Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") );
            transform.position = transform.position + rotation;

        //  }

        if (Input.GetMouseButton(0))
        {
            if ( wasUp)
            {
                wasUp = false;
                mousePosition = Input.mousePosition;
                return;
            }

            Vector3 delta = Input.mousePosition - mousePosition;
            delta = delta * 0.1f;
            transform.Rotate(delta.x,delta.y,0);

        } else
        {
            wasUp = true;
        }
    }
}

