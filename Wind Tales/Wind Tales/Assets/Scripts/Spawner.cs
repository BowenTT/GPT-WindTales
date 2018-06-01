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

	void Start ()
    {
        #region Old Code
        //for (int i = 0; i < 10; i++)
        //{
        //    Vector2 mousePosition = Input.mousePosition;

        //    Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //    Instantiate(spawnItem, mousePosition, Quaternion.identity, spawnArea.transform);
        //}
        #endregion
    }

    void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    spawnerON = !spawnerON;
        //}

        if (countDown <= 0f && spawnerON && spawnedItems <= totalItems)
        {
            spawnPosition.x = Random.Range(0, maxX);
            spawnPosition.y = Random.Range(0, maxY);
            int arrayIndex = Random.Range(0, sprites.Length);
            Sprite sprite = sprites[arrayIndex];
            GameObject item = Instantiate(spawnItem, spawnPosition, Quaternion.identity, spawnArea.transform);
            item.GetComponent<Image>().sprite = sprite;
            countDown = spawnRate;
            spawnedItems++;
            return;
        }
        countDown -= Time.deltaTime;
    }
}