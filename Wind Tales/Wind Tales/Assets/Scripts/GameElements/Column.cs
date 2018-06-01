using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour
{
    public GameObject Blockage;

    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Character>() != null)
		{
			GameControl.instance.BirdScored();
		}
	}
}
