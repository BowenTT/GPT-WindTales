using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public Slider slider;
    public static GameControl games;

    // Use this for initialization
    void Start ()
	{
	    games = GetComponent<GameControl>();
	    slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider.value = Input.GetAxis("Player_SimulateBreathing");
	}
}
