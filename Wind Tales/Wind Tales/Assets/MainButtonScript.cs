using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainButtonScript : MonoBehaviour
{
	[SerializeField]
	private Boolean available;

	[SerializeField]
	private Boolean notification;

	[SerializeField]
	private GameObject notificationObject;

	[SerializeField]
	private Sprite availableSprite;

	[SerializeField]
	private Sprite unavailableSprite;

	[SerializeField]
	private string scene;

	[SerializeField]
	private GameObject loadingScreen;

	void Start()
	{

	}

	void Update()
	{
		if (available)
		{
			gameObject.GetComponent<Image>().sprite = availableSprite;
			gameObject.GetComponent<Button>().interactable = true;
		}
		else
		{
			gameObject.GetComponent<Image>().sprite = unavailableSprite;
			gameObject.GetComponent<Button>().interactable = false;
		}
		if (notification != notificationObject.activeSelf)
		{
			notificationObject.SetActive(notification);
		}
	}

	public void OnClick()
	{
		Debug.Log("YOYOYO");
		StartCoroutine(SwitchScene());
	}

	private IEnumerator SwitchScene()
	{
		loadingScreen.SetActive(true);
		var image = loadingScreen.GetComponent<Image>();

		while (image.color.a < 1)
		{
			Debug.Log("SHIIIET");
			image.color += new Color(0, 0, 0, 0.02f);
			yield return null;

		}

	}
}
