using System;
using UnityEngine;
using System.Collections;
using Boo.Lang;
using Random = UnityEngine.Random;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab; //The column game object.
    public float columnPoolSize = 2; //How many columns to keep on standby.
    public float spawnRate = 3f; //How quickly columns spawn.
    public float columnMin = -1f; //Minimum y value of the column position.
    public float columnMax = 3.5f; //Maximum y value of the column position.
    public float BlockingColumnSpawn = 3f; //How quickly Blocking columns spawn.
    public float BlowingMinimum = 0; //You set the minimum blowing requiremnets for this game. 
    private GameControl games;
   

    private List<GameObject> columns = new List<GameObject>(); //Collection of pooled columns.
    private int currentColumn; //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25); //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;
    private float timeSinceLastSpawnedBlockage;

    void Start()
    {

        for (var i = 0; i < columnPoolSize; i++)
        {
            columns.Add((GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
        }
        games = GetComponent<GameControl>();
        games.Blowingminimum = BlowingMinimum;
        timeSinceLastSpawned = 0f;
        BlockingColumnSpawn = 0f;
    }


    private void ColumnsFix()
    {
        columns = new List<GameObject>();
        for (var i = 0; i <= columnPoolSize; i++)
        {
            columns.Add(Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
        }
        currentColumn = 0;
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        timeSinceLastSpawnedBlockage += Time.deltaTime;
        if (Input.GetAxis("Player_SimulateBreathing") >= BlowingMinimum || Input.GetKey("q"))
        {
            columns[games.score % Convert.ToInt32(columnPoolSize)].GetComponent<Column>().ExhaleBreath.SetActive(false);
            var blockage = columns[games.score %Convert.ToInt32(columnPoolSize)].GetComponent<Column>().Blockage;
            blockage.SetActive(false);
        }

        if (GameControl.instance.GameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            Debug.Log(currentColumn);
            timeSinceLastSpawned = 0f;
            var spawnYPosition = Random.Range(columnMin, columnMax);
            if (columns[currentColumn] == null)
            {
                ColumnsFix();
            }
            else
            {
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                if (timeSinceLastSpawnedBlockage >= BlockingColumnSpawn)
                {
                    timeSinceLastSpawnedBlockage = 0f;
                    columns[currentColumn].GetComponent<Column>().Blockage.SetActive(true);
                    columns[currentColumn].GetComponent<Column>().ExhaleBreath.SetActive(true);
                }
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
    }
}