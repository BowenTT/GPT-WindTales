using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public float vacuumStrength = 5f;
    public float distanceStrength = 10f;
    public int vacuumDirection = 1;
    public bool loseVacuumEffect = true;

    private Transform trans;
    private Transform vacuumTransform;
    private Rigidbody coinRigidbody;
    private bool inRange = false;

    private float value;

    public bool isSelected = false;

    void Awake()
    {
        trans = transform;
        coinRigidbody = trans.GetComponent<Rigidbody>();
        coinRigidbody.AddForce(this.transform.forward * 10, ForceMode.Force);
    }

    void Update()
    {
        //vacuumStrength += Input.GetAxis("Player_SimulateBreathing") / 5;

        //value += Input.GetAxis("Player_SimulateBreathing");
        //Debug.Log(value);

        if (isSelected)
        {
            //this.transform.localScale += new Vector3(2f, 2f);
            //this.gameObject.GetComponent<Image>().color = Color.red;

        }
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
}