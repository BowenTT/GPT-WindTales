using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Application;
using Structs;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         //A reference to our game control script so we can access it statically.
    public Text scoreText;                      //A reference to the UI text component that displays the player's score.

    public int score = 0;						//The player's score.
    private bool gameOver = false;              //Is the game over?
    public float scrollSpeed = -1.5f;
    public List<AudioClip> Bumps;
    private AudioSource audio;
    private AudioClip Clip;
    public float Blowingminimum;

    public bool GameOver { get { return gameOver; } }


    void Awake()
    {
        audio = GetComponent<AudioSource>();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOver = false;
            GameModel.AddHappiness(5f);
            GameModel.AddCleanliness(-5f);
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
        int bumpsaudio = Random.Range(0, Bumps.Count);
        audio.PlayOneShot(Bumps[bumpsaudio]);
    }
}