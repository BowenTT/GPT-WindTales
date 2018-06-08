using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingGameCamera : MonoBehaviour
{
    public GameObject thisCamera;
    public GameObject character;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.y <= -15)
        {
            thisCamera.transform.position = new Vector3(transform.position.x, -15, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
        }
    }
}
