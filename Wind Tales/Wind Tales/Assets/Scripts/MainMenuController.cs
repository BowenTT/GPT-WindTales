using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application;
using System;

public class MainMenuController : MonoBehaviour
{

	[SerializeField]
	private GameObject loadingScreen;
	[SerializeField]
	private float maxValue;
	[SerializeField]
	private float defaultValue;
	[SerializeField]
	private int minutesPerValue;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(LoadScene());
	}

	private IEnumerator LoadScene()
	{
		loadingScreen.SetActive(true);
		var image = loadingScreen.GetComponent<Image>();
		image.color = new Color(0, 0, 0, 1);
		while (image.color.a > 0)
		{
			image.color -= new Color(0, 0, 0, 0.04f);
			yield return null;
		}
		loadingScreen.SetActive(false);
		SetupStats();
		InvokeRepeating("SetupStats", 300, 300);
	}

	private void SetupStats()
	{
		try
		{
			var login = GameModel.GetLastLogin();
			var current = DateTime.Now;
			var diff = current - login;
			Debug.Log("Diff is " + diff.TotalMinutes);
			var addvalue = (float)diff.TotalMinutes / minutesPerValue;
			Debug.Log("Add is " + addvalue);
			GameModel.AddHunger(addvalue);
			GameModel.AddHappiness(-addvalue);
			GameModel.AddCleanliness(-addvalue);
			GameModel.AddCleanlinessRoom(-addvalue);
			GameModel.SetLastLogin(current);
		}
		catch (FormatException)
		{
			//no date saved set default values
			Debug.Log("It's my first time!");
			GameModel.SetLastLogin(DateTime.Now);
			GameModel.SetHunger(defaultValue);
			GameModel.SetCleanliness(defaultValue);
			GameModel.SetHappiness(defaultValue);
			GameModel.SetCleanlinessRoom(defaultValue);
		}
	}


}
