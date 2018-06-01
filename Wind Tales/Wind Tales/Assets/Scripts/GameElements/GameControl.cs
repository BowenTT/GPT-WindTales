using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;						//A reference to the UI text component that displays the player's score.

	public int score = 0;						//The player's score.
    private bool gameOver = false;				//Is the game over?
	public float scrollSpeed = -1.5f;

    public bool GameOver { get { return gameOver; } }


	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
    { 
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		    gameOver = false;
		}
	}

	public void BirdScored()
	{
		if (gameOver)	
			return;
		score++;
		scoreText.text = "Score: " + score.ToString();
	}

	public void BirdDied()
	{
		gameOver = true;
	}
}
