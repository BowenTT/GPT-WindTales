using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Been here");
        if (collision.tag == "Player")
        {
            collision.GetComponent<Animal>().targetPosition = direction;
            Debug.Log("Been here");
        }
    }
}
