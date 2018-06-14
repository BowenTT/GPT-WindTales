using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingGameController : MonoBehaviour
{

	public static int gameStatus = 0;                       //This will determine in what stage of the exercise we are.
	public static int currentHunger = 10;                         //This will eventually determine wether the gamestatus will be updated to start the food minigame.
	private float breathingTime;
    public float breathingTimeNeeded = 3;
    public float minimumBreathingStrength = 1;
	private FurnaceTrigger furnaceTrigger;
	public GameObject Camera;
	public GameObject Canvas;
    public GameObject Chicken;

	// Use this for initialization
	void Start()
	{
		gameStatus = 0;
		

		Camera.transform.position = Canvas.transform.position;
		Camera.GetComponent<Camera>().orthographicSize = Canvas.transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{
        if (isPetHungry() && gameStatus == 0)
        {
            gameStatus = 1;

        }
        if (gameStatus == 3)
		{

            //float input = Input.GetAxis("Player_SimulateBreathing");
            float input = (float) - DeviceManager.Instance.FlowLMin;
            Debug.Log(input);
			UpdateState(input);
		}
        else if(currentHunger >= 75)
        {
            Chicken.SetActive(false);
        }
	}

	private bool isPetHungry()
	{
		if (currentHunger <= 20)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void UpdateState(float input)
	{
		if (input > 0)
		{
			breathingTime += Time.deltaTime;
			Debug.Log(breathingTime);
			if (breathingTime >= 3 && minimumBreathingStrength >= 1)
			{
				gameStatus = 4;

				Debug.Log("Exercise is done");
			}
		}
		else if (input <= 0)
		{
			breathingTime = 0;
			Debug.Log("Input is <= 0");
		}
	}




}
