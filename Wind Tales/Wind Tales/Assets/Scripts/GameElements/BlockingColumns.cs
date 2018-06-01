using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingColumns : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
