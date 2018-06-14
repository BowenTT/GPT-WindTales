using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Column : MonoBehaviour 
{
    public GameObject Blockage;
    public GameObject ExhaleBreath;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
