using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{

	public float speed = 1.5f;
	private Vector3 target;
	private bool pressed;

	// Use this for initialization
	void Start()
	{
		pressed = false;
		target = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//Check if gamestatus is 1 to make the chicken movable.
		if (EatingGameController.gameStatus == 1 && Input.GetMouseButton(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			transform.position = Vector3.MoveTowards(transform.position, target, speed);
		}

	}



}
