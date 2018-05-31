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

    private int MaxFilth;
    private GameObject currentPet;
    private Vector3 oldPosition;

    void Start()
    {
        Debug.Log("set maxFilth");
        MaxFilth = filthyness;
        Debug.Log(MaxFilth);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("set current gameobject");
        currentPet = col.otherCollider.gameObject;
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

}
