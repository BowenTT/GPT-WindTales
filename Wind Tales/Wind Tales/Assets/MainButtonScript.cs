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

	private void Start()
	{
		if (notification)
		{
			StartCoroutine(AnimateExclamation());

		}
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
			if (notification)
			{
				StartCoroutine(AnimateExclamation());

			}
		}
	}

	public void OnClick()
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

	private IEnumerator AnimateExclamation()
	{
		//This will make the animation play for 1 second
		while (notification)
		{
			for (int i = 0; i < 15; i++)
			{
				notificationObject.transform.localScale += new Vector3(0.03f, 0.03f, 0);
				yield return ExecuteAfterTime(0.05f);

			}

			for (int i = 0; i < 15; i++)
			{
				notificationObject.transform.localScale -= new Vector3(0.03f, 0.03f, 0);
				yield return ExecuteAfterTime(0.05f);

			}
		}
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay
	}
}
