﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{

	public GameObject HungryImage;

	private Vector3 spriteLocation;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (EatingGameController.currentHunger < 20)
		{
			HungryImage.SetActive(true);
		}
		else if (EatingGameController.currentHunger >= 20)
		{
			HungryImage.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		//Check if the tag of the trigger collided with is Food
		if (other.tag == "Food" && EatingGameController.gameStatus == 1)
		{
			EatingGameController.gameStatus = 5;

			other.gameObject.SetActive(false);



			EatingGameController.currentHunger += 25;
		}

	}
}
