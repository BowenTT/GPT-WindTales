using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

	[SerializeField]
	private GameObject loadingScreen;

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
		Debug.Log("Go play now");
	}

}
