using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foodbar : MonoBehaviour {

    public Slider foodbar;
    public float MaxHunger;
    public float Progress;
    public float ActiveTime;

    // Use this for initialization
    void Start () {
        MaxHunger = 100;
        foodbar.value = CalculatePercentage();
        
    }
	
	// Update is called once per frame
	void Update () {
        Timer();
        Progress = EatingGameController.currentHunger;
        foodbar.value = CalculatePercentage();
        if(ActiveTime >= 5)
        {
            if (EatingGameController.currentHunger > 0)
            {
                EatingGameController.currentHunger = EatingGameController.currentHunger - 1;
            }
            else if (EatingGameController.currentHunger <= 0)
            {
                EatingGameController.currentHunger = 0;
            }
            ActiveTime = 0;
        }
    }

    float CalculatePercentage()
    {
        return   Progress / MaxHunger;
    }

    void Timer()
    {
        ActiveTime += Time.deltaTime;
 
    }

 



}
