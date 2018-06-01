using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

    public Vector2 targetPosition;
    public int score;
    public Text scoreText;
    public float speed;

    private Transform trans;

    void Awake()
    {
        trans = transform;
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
            Destroy(other.gameObject);
            if (other.gameObject.GetComponent<Coin>().isSelected)
            {
                score++;
                scoreText.text = score.ToString();
            }
        }
    }
}