using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody BallObject;
    public int force = 1000;
	// Use this for initialization
	void Start () {
        BallObject = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseDown()
	{
        Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        BallObject.AddForce(direction * force);
	}
}
