using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanPet : MonoBehaviour
{
    public int filthyness;

    public Sprite filth3;
    public Sprite filth2;
    public Sprite filth1;
    public Sprite clean;
    public Sprite wetOverlay1;
    public Sprite wetOverlay2;
    public Sprite wetOverlay3;
    public Image wetOverlay;
    public float maxFlow;

    private int MaxFilth;
    private int loop = 0;
    private GameObject currentPet;
    private Vector3 oldPosition;
    private bool isDry = true;
    private float cumalativeFlow;

    void Start()
    {
        MaxFilth = filthyness;
        Debug.Log(MaxFilth);
    }

    void Update()
    {
        float input = Input.GetAxis("Player_SimulateBreathing");
        DryPet(input);
        Debug.Log(input);
        if (isDry == false)
        {
            Debug.Log("start animation");
            WetAnimation();
        }
        else
        {
            turnOffWetAnimation();
        }

    }

        void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("set current gameobject");
        currentPet = col.otherCollider.gameObject;
        isDry = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (filthyness > 0)
        {
            Debug.Log("collision detected");
            switch (col.gameObject.tag)
            {
                case "Cleaning":
                    Debug.Log("collision on cleaning detected");
                    if (detectMovement(col))
                    {
                        filthyness--;
                        Debug.Log("filthyness is " + filthyness);
                        UpdateSprite();
                    }
                    break;
            }
        }
    }

    bool detectMovement(Collision2D col)
    {  
        Debug.Log("movement called");
        if (oldPosition != col.transform.position)
        {
            Debug.Log("movement differs");
            oldPosition = col.transform.position;
            return true;
        }
        else
            return false;
    }

    void UpdateSprite()
    {
        Image filthupdate = currentPet.GetComponent<Image>();
        if (filthyness == 0)
            filthupdate.sprite = clean;
        if (filthyness == MaxFilth / 4)
            filthupdate.sprite = filth1;
        if (filthyness == MaxFilth / 3)
            filthupdate.sprite = filth2;
        if (filthyness == MaxFilth / 2)
            filthupdate.sprite = filth3;
    }

    void DryPet(float input)
    {
        if (input >= maxFlow || cumalativeFlow >= maxFlow)
        {
            isDry = true;
        }
        cumalativeFlow += input;
    }

    void turnOffWetAnimation()
    {
        wetOverlay.enabled = false;
        cumalativeFlow = 0;
    }

    void WetAnimation()
    {
        wetOverlay.enabled = true;
        if (loop == 0)
        {
            wetOverlay.sprite = wetOverlay1;
        }
        if (loop == 50)
        {
            wetOverlay.sprite = wetOverlay2;
        }
        if (loop == 100)
        {
            wetOverlay.sprite = wetOverlay3;
        }
        loop++;
        
        if (loop > 150)
        {
            loop = 0;
        }
    }
}
