using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public float vacuumStrength = 5f;
    public float distanceStrength = 0f;
    public int vacuumDirection = 1;
    public bool loseVacuumEffect = true;
    public float diffucltyLevel = 10f;

    public GameObject[] soundObject;

    private Transform trans;
    private Transform vacuumTransform;
    private Rigidbody coinRigidbody;
    private bool inRange = false;

    public bool isSelected = false;

    void Awake()
    {
        trans = transform;
        coinRigidbody = trans.GetComponent<Rigidbody>();
        coinRigidbody.AddForce(this.transform.forward * 10, ForceMode.Force);
    }

    void OnEnable()
    {
        EventManager.coinUpdateEvent += PlaySound;
    }

    private void OnDisable()
    {
        EventManager.coinUpdateEvent -= PlaySound;
    }

    void Update()
    {
      // vacuumStrength = Input.GetAxis("Player_SimulateBreathing");// ==> for Xbox controller
       vacuumStrength = (DeviceManager.Instance.CurrentFlowPercentage / diffucltyLevel);
        
        Debug.Log(vacuumStrength);
    }

    void FixedUpdate()
    {
        if (inRange && isSelected)
        {
            Vector2 directionToVacuum = vacuumTransform.position - trans.position;
            float distance = Vector2.Distance(vacuumTransform.position, trans.position);
            float vacuumDistanceStrength = (distanceStrength / distance) * vacuumStrength;

            coinRigidbody.AddForce(vacuumDistanceStrength * (directionToVacuum * vacuumDirection), ForceMode.Force);
        }
    }

    private void OnMouseDown()
    {
        this.gameObject.GetComponent<Image>().color = Color.green;
        this.transform.localScale = new Vector3(1.45f, 1.45f);
        isSelected = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            vacuumTransform = other.transform;
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && loseVacuumEffect)
        {
            inRange = false;
        }
    }

    public void PlaySound()
    {
        GameObject sound = (GameObject)Instantiate(soundObject[Random.Range(0, soundObject.Length)], this.transform.position, this.transform.rotation);
        Destroy(sound, 2f);
    }
}