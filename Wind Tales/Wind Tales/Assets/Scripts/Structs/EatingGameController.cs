using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingGameController : MonoBehaviour {

    public static int gameStatus = 0;                       //This will determine in what stage of the exercise we are.
    public static int currentHunger = 10;                         //This will eventually determine wether the gamestatus will be updated to start the food minigame.
    private float breathingTime = 0;
    private FurnaceTrigger furnaceTrigger;
    

    // Use this for initialization
    void Start () {
        

        //This method will eventually be placed in the update
        if (isPetHungry())
        {
            gameStatus = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
       if(gameStatus == 3)
        {
            float input = Input.GetAxis("Player_SimulateBreathing");
            UpdateState(input);
        }
	}

    private bool isPetHungry()
    {
        if(currentHunger <= 20)
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
        if(input > 0)
        {
            breathingTime += Time.deltaTime;
            //Debug.Log(breathingTime);
            if (breathingTime >= 5)
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
