using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

    public Vector2 targetPosition;
    public int score;
    public Text scoreText;
    public float speed;
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

    private void OnEnable()
    {
        EventManager.coinUpdateEvent += EventNotifier;
    }

    private void OnDisable()
    {
        EventManager.coinUpdateEvent -= EventNotifier;
    }

    void Update()
    {
        trans.position = Vector2.Lerp(trans.position, targetPosition, Time.deltaTime * speed);

        if (Mathf.Abs(targetPosition.x - trans.position.x) < 1f)
        {
            trans.position = targetPosition;
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
            if (other.gameObject.GetComponent<Coin>().isSelected)
            {
                score++;
                scoreText.text = score.ToString();
                EventManager.CoinUpdate();
                EventNotifier();
                Destroy(other.gameObject);
            }
        }
    }

    private void EventNotifier() { }
}