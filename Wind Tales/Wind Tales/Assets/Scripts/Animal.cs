using UnityEngine;

public class Animal : MonoBehaviour {

    public Vector2 targetPosition;

    private Transform trans;

    void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        trans.position = Vector2.Lerp(trans.position, targetPosition, Time.deltaTime * 1.5f);

        if (Mathf.Abs(targetPosition.x - trans.position.x) < 1f)
        {
            trans.position = targetPosition;
        }
    }
}