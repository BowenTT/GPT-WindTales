using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?
    public List<AudioClip> audioC;
    private AudioSource audio;
    private AudioClip Clip;


    private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
	    audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
	    if (isDead == false)
		{
		    if (Input.GetKey("space"))
		    {
                rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
                int bumpsaudio = Random.Range(0, audioC.Count);
		        Clip = audioC[bumpsaudio];
		        if (!audio.isPlaying)
		        {
		            audio.PlayOneShot(Clip);
                }
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