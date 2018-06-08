using Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckNeccesity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameModel.GetCleanliness() <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
            this.gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (GameModel.GetCleanliness() <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
            this.gameObject.SetActive(true);
    }
}
