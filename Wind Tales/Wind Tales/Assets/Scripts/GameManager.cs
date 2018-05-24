using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject coin;

    public GameObject parent;

    private Rigidbody coinRigidBody;

	void Start () {
		
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;

            Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(coin, mousePosition, Quaternion.identity).transform.parent = parent.transform;
        }
	}
}