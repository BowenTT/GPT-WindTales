using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	public void OnClick(string scene)
	{
		Debug.Log("Lets switch");
		StartCoroutine(SwitchScene(scene));
	}

	private IEnumerator SwitchScene(string name)
	{
		loadingScreen.SetActive(true);
		var image = loadingScreen.GetComponent<Image>();
		var scene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
		scene.allowSceneActivation = false;

		image.color = new Color(0, 0, 0, 0);
		while (image.color.a < 1)
		{
			image.color += new Color(0, 0, 0, 0.04f);
			yield return null;
		}
		while (scene.progress < 0.9f)
		{
			yield return null;
		}
		scene.allowSceneActivation = true;

	}
}
