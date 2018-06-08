using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?


	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (isDead == false) 
		{
			if (Input.GetKey("w")) 
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		GameControl.instance.BirdDied ();
	}
}
