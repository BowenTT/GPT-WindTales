using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{

	public GameObject HungryImage;
    public Vector3 TablePosition;      //Make a new vector at the position of the table in the scene.
    public GameObject Table;
    private Vector3 spriteLocation;

	// Use this for initialization
	void Start()
	{
        TablePosition = Table.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (EatingGameController.currentHunger < 20)
		{
			HungryImage.SetActive(true);
		}
		else if (EatingGameController.currentHunger >= 20)
		{
			HungryImage.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		//Check if the tag of the trigger collided with is Food
		if (other.tag == "Food" && EatingGameController.gameStatus == 5)
		{
			EatingGameController.gameStatus = 0;

			other.gameObject.SetActive(false);



			EatingGameController.currentHunger += 25;

            if(EatingGameController.currentHunger <= 99)
            {
                EatingGameController.gameStatus = 1;
                other.gameObject.transform.position = TablePosition;
                other.gameObject.SetActive(true);
            }
		}

	}
}
