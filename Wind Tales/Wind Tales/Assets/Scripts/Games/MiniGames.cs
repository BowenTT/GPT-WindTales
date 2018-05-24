﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;

namespace Games
{
	abstract public class MiniGames : MonoBehaviour
	{
	    private FlabbyBird bird;
		// Use this for initialization
		void Start () {
		    bird =new FlabbyBird();
		    bird.Play();
        }
	
		// Update is called once per frame
		void Update ()
		{
		    
		}

		abstract public StatChange Play();
	}
}


