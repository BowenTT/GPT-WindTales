using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;

namespace Games
{
	abstract public class MiniGames : MonoBehaviour
	{

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		abstract public StatChange Play();
	}
}


