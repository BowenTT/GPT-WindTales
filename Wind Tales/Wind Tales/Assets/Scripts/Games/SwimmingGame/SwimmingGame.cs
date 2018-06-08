using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingGame : MonoBehaviour
{

    //public GameObject character;
    public Rigidbody2D character;
    private bool comingUp;
    private bool goingDown;
    private bool swimDisabled;

    int speed;

    void Start()
    {
        speed = 5;
        comingUp = false;
        goingDown = false;
        swimDisabled = false;
    }

    void Update()
    {
        if (character.transform.position.y < -15)
        {

        }
        else
        {
            //          [[ DRIJF EFFECT ]]

            // Check of de player te ver naar boven drijft
            if (character.transform.position.y >= 1)
            {
                //Als true, dan word de force op zero gezet zodat de player niet uit het water schiet.
                //Vervolgens word de comingup op false gezet totdat de player weer gaat duiken.
                if (comingUp)
                {
                    character.velocity = Vector2.zero;
                    character.AddForce(-transform.up * 20);
                    comingUp = false;
                }

                //De player word elke keer een stukje naar beneden 
                //geduwd waardoor er een schommel drijf effect komt.
                character.AddForce(-transform.up * 20);
            }

            //          [[ UITBLAZEN ]]

            //Als de player uitblaast dan komt de character weer omhoog
            if (Input.GetButton("Breath out"))
            {
                comingUp = true;
                goingDown = false;
            }

            //          [[ INADEMEN ]]
            //als de player hoger dan y-11 zit kan de player 
            //space gebruiken om verder te duiken. (dadelijk inademen)
            if (!swimDisabled)
            {
                if (Input.GetButton("Breath in"))
                {
                    character.AddForce(-transform.up * 10);
                    comingUp = true;
                    goingDown = true;
                }
            }

            if (character.transform.position.y >= -13f)
            {
                swimDisabled = false;
            }
            //Als de player onder y-14 komt. Word de force op zero gezet
            //zodat de player niet uit beeld gaat.
            if (character.transform.position.y <= -14f)
            {

                if (goingDown)
                {
                    character.velocity = Vector2.zero;
                    swimDisabled = true;
                    goingDown = false;
                }
            }
        }
    }
}
