using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D BallObject;
    public int MinForce = 100;
    public int MaxForce = 150;
	// Use this for initialization
	void Start () {
        BallObject = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseDown()
	{
        Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        int randomForce = Random.Range(MinForce, MaxForce);
        BallObject.AddForce(direction * randomForce);
	}
}
