using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform progress;
    private float currentAmount;
    private float speed;

    private bool holdBreath;
    private bool breathOut;


	void Start ()
    {
        speed = 1;
        holdBreath = false;
        breathOut = false;
	}
	

	void Update ()
    {
        if (holdBreath)
        {
            if (currentAmount < 100)
            {
                currentAmount += speed + Time.deltaTime;
            }

            progress.GetComponent<Image>().fillAmount = currentAmount / 100;

            if (currentAmount == 100)
            {
                
            }
        }
	}

    public void startHoldBreath()
    {
        holdBreath = true;
    }

    public void stopHoldBreath()
    {
        holdBreath = false;
    }
}
