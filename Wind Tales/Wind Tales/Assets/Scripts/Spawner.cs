using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public Canvas spawnArea;
    public GameObject spawnItem;

    public Sprite[] sprites;

    public int maxX = 700;
    public int maxY = 400;
    public int totalItems;
    public float spawnRate = 1.0f;

    private float countDown = 1.0f;
    private Vector2 spawnPosition;

    private bool spawnerON = true;
    private int spawnedItems;

    void Update ()
    {
        if (countDown <= 0f && spawnerON && spawnedItems <= totalItems)
        {
            spawnPosition.x = Random.Range(0, maxX);
            spawnPosition.y = Random.Range(0, maxY);
            int arrayIndex = Random.Range(0, sprites.Length);
            Sprite sprite = sprites[arrayIndex];
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 100));
            GameObject item = Instantiate(spawnItem, screenPosition, Quaternion.identity, spawnArea.transform);
            item.GetComponent<Image>().sprite = sprite;
            countDown = spawnRate;
            spawnedItems++;
            return;
        }
        countDown -= Time.deltaTime;





    }
}