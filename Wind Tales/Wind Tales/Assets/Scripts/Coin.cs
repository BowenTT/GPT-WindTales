using UnityEngine;

public class Coin : MonoBehaviour {

    public float vacuumStrength = 5f;
    public float distanceStrength = 10f;
    public int vacuumDirection = 1;
    public bool loseVacuumEffect = true;

    private Transform trans;
    private Transform vacuumTransform;
    private Rigidbody coinRigidbody;
    private bool inRange;

    void Awake()
    {
        trans = transform;
        coinRigidbody = trans.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            Vector2 directionToVacuum = vacuumTransform.position - trans.position;
            float distance = Vector2.Distance(vacuumTransform.position, trans.position);
            float vacuumDistanceStrength = (distanceStrength / distance) * vacuumStrength;

            coinRigidbody.AddForce(vacuumDistanceStrength * (directionToVacuum * vacuumDirection), ForceMode.Force);
        }
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