using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject coin;

    public GameObject parent;

    public Vector3 center;
    public Vector3 size;

    private Rigidbody coinRigidBody;

	void Start () {
		
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            SpawnCoin();   
        }
	}

    void SpawnCoin()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Instantiate(coin, mousePosition, Quaternion.identity, parent.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(center, size);
    }
}