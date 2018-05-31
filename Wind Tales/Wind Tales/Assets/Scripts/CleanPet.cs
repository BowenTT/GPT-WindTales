using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPet : MonoBehaviour
{
    public int filthyness;
    private Vector3 oldPosition;

    void OnCollisionStay2D(Collision2D col)
    {
        if (filthyness > 0)
        {
            Debug.Log("collision detected");
            switch (col.gameObject.tag)
            {
                case "Cleaning":
                    Debug.Log("collision on cleaning detected");
                    if (detectMovement(col))
                    {
                        filthyness--;
                        Debug.Log("filthyness is " + filthyness);
                    }
                    break;
            }
        }
    }

    bool detectMovement(Collision2D col)
    {  
        Debug.Log("movement called");
        if (oldPosition != col.transform.position)
        {
            Debug.Log("movement differs");
            oldPosition = col.transform.position;
            return true;
        }
        else
            return false;
    }

}
