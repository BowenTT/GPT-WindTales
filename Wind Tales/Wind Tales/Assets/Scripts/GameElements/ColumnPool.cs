using UnityEngine;
using System.Collections;
using Boo.Lang;

public class ColumnPool : MonoBehaviour 
{
	public GameObject columnPrefab;                                 //The column game object.
    public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float spawnRate = 3f;									//How quickly columns spawn.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.
    public float spawnRateBlockage = 8f;                            //How quickly blockage spawn.


    private List<GameObject> columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;
    private float timeSinceLastSpawnedBlockage;


    void Start()
	{
		timeSinceLastSpawned = 0f;
	    timeSinceLastSpawnedBlockage = 0f;
	    columns = new List<GameObject>();
		for(int i = 0; i < columnPoolSize; i++)
		{
			columns.Add((GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
		    columns.Add((GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
        }
	}

    public void Restart()
    {
        columns = new List<GameObject>();
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns.Add((GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
            columns.Add((GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
        }
        currentColumn = 0;
    }


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;
	    if (Input.anyKey.Equals("q"))
	    {
	        var blockage = columns[GameControl.instance.score %columnPoolSize];
	        blockage.SetActive(false);
	    }


		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			float spawnYPosition = Random.Range(columnMin, columnMax);

			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

		    if (timeSinceLastSpawnedBlockage >= spawnRateBlockage)
		    {
		        columns[currentColumn].SetActive(true);
            }

			currentColumn ++;
			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}