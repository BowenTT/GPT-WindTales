using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour
{
    public GameObject Blockage;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Character>() != null)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.instance.BirdScored();
		}
	}
}
