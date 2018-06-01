using UnityEngine;

public class Spawner : MonoBehaviour {

    public Canvas spawnArea;
    public GameObject spawnItem;

    public int maxX = 700;
    public int maxY = 400;
    public float spawnRate = 1.0f;

    private float countDown = 1.0f;
    private Vector2 spawnPosition;

    private bool spawnerON = true;

	void Start ()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    Vector2 mousePosition = Input.mousePosition;

        //    Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //    Instantiate(spawnItem, mousePosition, Quaternion.identity, spawnArea.transform);
        //}
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnerON = !spawnerON;
        }

        if (countDown <= 0f && spawnerON)
        {
            spawnPosition.x = Random.Range(0, maxX);
            spawnPosition.y = Random.Range(0, maxY);
            Instantiate(spawnItem, spawnPosition, Quaternion.identity, spawnArea.transform);
            countDown = spawnRate;
            return;
        }
        countDown -= Time.deltaTime;
    }
}