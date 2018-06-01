using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingGame : MonoBehaviour
{

    //public GameObject character;
    public Rigidbody2D character;
    private bool comingUp;
    private bool goingDown;

    int speed;

    void Start()
    {
        speed = 5;
        comingUp = false;
        goingDown = false;
    }

    void Update()
    {
        if (character.transform.position.y < -15)
        {

        }
        else
        {
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

                //De player word elke keer een stukje naar beneden geduwd waardoor er een schommel drijf effect komt.
                character.AddForce(-transform.up * 20);
            }

            //Zorgt dat de button om te duiken niet meer werkt zodat de player niet verder kan duiken als de player op y-11 zit of lager.
            if (transform.position.y <= -11)
            { }
            else
            {
                //als de player hoger dan y-11 zit kan de player space gebruiken om verder te duiken.
                if (Input.GetKeyDown("space"))
                {
                    character.AddForce(-transform.up * 400);
                    comingUp = true;
                    goingDown = true;
                }
            }

            //Als de player onder y-14 komt. Word de force op zero gezet en word hij terug gespawned naar y-14
            //zodat de player niet uit beeld gaat.
            if (character.transform.position.y <= -14f)
            {

                if (goingDown)
                {
                    character.velocity = Vector2.zero;
                    character.transform.position = new Vector2(0, -14f);
                    goingDown = false;
                }
            }
        }
    }
}
