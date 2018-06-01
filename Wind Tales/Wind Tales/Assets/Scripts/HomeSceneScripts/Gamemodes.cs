using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemodes : MonoBehaviour {

    [SerializeField]
    private GameObject PlayerPet;
    [SerializeField]
    private GameObject SoccerBall;
    [SerializeField]
    private Button BallModeButton;
    [SerializeField]
    private Button AcrobatModeButton;

    private int GameMode;
	// Use this for initialization
    void Start () {
        
    }
	

    public void SelectGameMode(int GameMode)
    {
        switch (GameMode)
        {
            //Ball
            case 0:
                {
                    BallMode();
                    break;
                }

            case 1:
                {
                    AcrobaticMode();
                    break;
                }
            default:
                break;
        }
    }


    void BallMode()
    {
        //Disable animations
        PlayerPet.gameObject.GetComponent<Animator>().enabled = false;

        //Create a new ball and re-engage Rigidbody and re-enable the AcrobatMode button
        SoccerBall.SetActive(true);
        PlayerPet.gameObject.AddComponent<Rigidbody2D>();
        AcrobatModeButton.interactable = true;

        // Reset PlayerPet's position
        PlayerPet.transform.position = new Vector3(0, -2.6f, 0);
        PlayerPet.transform.rotation = Quaternion.identity;

        //Disable the button
        BallModeButton.interactable = false;
    }

    void AcrobaticMode()
    {
        //Disable the ball and re-enable the BallMode button
        SoccerBall.SetActive(false);
        BallModeButton.interactable = true;

        //Reset PlayerPet's position
        PlayerPet.transform.position = new Vector3(0, -2.6f, 0);
        PlayerPet.transform.rotation = Quaternion.identity;

        //Destroy it's rigidbody, else it will bug with animations
        Destroy(PlayerPet.gameObject.GetComponent<Rigidbody2D>());

        //Enable animations
        PlayerPet.gameObject.GetComponent<Animator>().enabled = true;

        //Disable the button
        AcrobatModeButton.interactable = false;

    }
}
