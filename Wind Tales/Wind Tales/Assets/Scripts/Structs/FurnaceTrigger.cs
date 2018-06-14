using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceTrigger : MonoBehaviour
{


	private GameObject Chicken;
	public Sprite CookedChicken;
	public Sprite UncookedChicken;
	public Vector3 TablePosition;      //Make a new vector at the position of the table in the scene.
	public GameObject Table;
    

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay
	}

	// Use this for initialization
	void Start()
	{
		TablePosition = Table.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (EatingGameController.gameStatus == 4)
		{
			//Get current chicken image
			Image ImageUncookedChicken = Chicken.GetComponent<Image>();
			//Change chicken sprite for a sprite that is not "hot" after the exercise
			ImageUncookedChicken.sprite = UncookedChicken;

            //enable drag and drop script
            Chicken.GetComponent<DragAndDrop>().enabled = true; //remove drag and drop script from chicken

            EatingGameController.gameStatus = 5;
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		//Check if the tag of the trigger collided with is Food
		if (other.tag == "Food" && EatingGameController.gameStatus == 1)
		{
			//OnTrigger this will change the gameStatus to 2
			EatingGameController.gameStatus = 2;

			//Disable the collider
			//other.enabled = false;

			//Save the current object in an object named chicken
			Chicken = other.gameObject;

            Chicken.GetComponent<DragAndDrop>().enabled = false; //disable drag and drop script

            //Disable the current chicken object
            other.gameObject.SetActive(false);

			//Start the oven animation
			StartCoroutine(animateOven());

			Debug.Log("Food Has Entered");
		}

	}

	IEnumerator animateOven()
	{
		//Check if gamestatus is 2
		if (EatingGameController.gameStatus == 2)
		{
			//This will make the animation play for 1 second
			for (int i = 0; i < 5; i++)
			{
				this.gameObject.gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 0);
				yield return ExecuteAfterTime(0.1f);


				this.gameObject.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 0);
				yield return ExecuteAfterTime(0.1f);

			}
			//Once the animation is finished move the chicken to the table.
			MoveChicken();


        }
	}


	private void MoveChicken()
	{
		if (EatingGameController.gameStatus == 2)
		{

			//Set the position of the chicken to the table position
			Chicken.transform.position = TablePosition;

			//Get current chicken image
			Image ImageCookedChicken = Chicken.GetComponent<Image>();
			//Change the chicken sprite to the Cooked chicken sprite.
			ImageCookedChicken.sprite = CookedChicken;


		

			//Make the chicken visible
			Chicken.SetActive(true);
			Debug.Log("Chicken has been cooked");



            //Set gamestatus to 3 to continue to the exercise.
            //Also due to changing the gamestatus the chicken is no longer moveable.
            EatingGameController.gameStatus = 3;



		}

	}



}
