using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

    public Vector2 targetPosition;
    public int score;
    public Text scoreText;
    public float speed;
    public LayerMask coinLayer;
    public Canvas Canvas;

    private Transform trans;

    void Awake()
    {
        trans = transform;
    }
   
    void Start()
    {
        Camera.main.transform.position = new Vector3(Canvas.transform.position.x, Canvas.transform.position.y, - 100);
        Camera.main.orthographicSize = Canvas.transform.position.y;
    }

    void Update()
    {
        trans.position = Vector2.Lerp(trans.position, targetPosition, Time.deltaTime * speed);

        if (Mathf.Abs(targetPosition.x - trans.position.x) < 1f)
        {
            trans.position = targetPosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, Mathf.Infinity, coinLayer))
            {
                Debug.Log("HelloWorld");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CoinTrigger")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            if (other.gameObject.GetComponent<Coin>().isSelected)
            {
                score++;
                scoreText.text = score.ToString();
            }
        }
    }
}