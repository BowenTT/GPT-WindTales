using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    [SerializeField]
    private float directionChangeTime = 20f;
    [SerializeField]
     private float minTimeToChangeDirection = 10f;
    [SerializeField]
    private float maxTimeToChangeDirection = 20f;

    [SerializeField]
    private float movementTime = 3f;
    [SerializeField]
    private float MoveLeftSpeed = -0.02f;
    [SerializeField]
    private float MoveRightSpeed = 0.02f;
    [SerializeField]
    private float HopHeight = 0.01f;


    [SerializeField]
    private bool CollidingWithWall = false;
    [SerializeField]
    private bool LeftWall = false;
    [SerializeField]
    private bool RightWall = false;

    public int MinForce = 100;
    public int MaxForce = 150;


    private int directionToMove = 0;
    private int maxDirections = 3;
    private float Direction;
    private float HeightOfFloor = -2.5f;
    private Rigidbody2D PetRigidBody;

    void Start()
    {
        ChangeDirection(Random.Range(0,2));
        PetRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    float ChangeDirection(int movement)
    {
        
        switch(movement)
        {
            //Left
            case 0:
                return MoveLeftSpeed;
            case 1:
                return MoveRightSpeed;
            default:
                return 0f;
        }
    }

    void Update()
    {
        directionChangeTime -= Time.deltaTime;
        movementTime -= Time.deltaTime;
      

        if (directionChangeTime <= 0)
        {
            if (!isFlying())
            {
                if (RolledOver())
                {
                    Debug.Log("Rolled over");
                    StartCoroutine(ResetPetPosition());
                    movementTime = -1;
                }
                else
                {
                    if (CollidingWithWall)
                    {
                        if (LeftWall)
                        {
                            directionToMove = 1;
                        }
                        else if (RightWall)
                        {
                            directionToMove = 0;
                        }
                    }
                    else
                    {
                        directionToMove = Random.Range(0, maxDirections);
                    }
                    Direction = ChangeDirection(directionToMove);
                    Debug.Log("Direction = " + Direction);
                    movementTime = Random.Range(2f, 5f);
                }
            }
            CollidingWithWall = false;
            LeftWall = false;
            RightWall = false;
            directionChangeTime = Random.Range(minTimeToChangeDirection, maxTimeToChangeDirection);
        }
    Vector3 oPos = transform.position;
    if (movementTime >= 0)
    {
        transform.position = new Vector3(oPos.x + Direction, oPos.y + HopHeight, oPos.z);
    }



        if (Input.GetKey("z"))
        {
            transform.position -= new Vector3(1,-0.4f,0f) * 2 * 2 * Time.deltaTime;
        }
        //Moves left when v is pressed
        if (Input.GetKey("v"))
        {
            transform.position += new Vector3(1, 0.4f, 0f) * 2 * 2 * Time.deltaTime;
        }


    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall")
        {
            CollidingWithWall = true;
            if(collision.gameObject.tag == "LeftWall")
            {
                LeftWall = true;
            }
            else
            {
                RightWall = true;
            }
        }
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody2D BallObject = collision.gameObject.GetComponent<Rigidbody2D>();
            int randomForce = Random.Range(MinForce, MaxForce);
            Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            BallObject.AddForce( direction * randomForce);
        }


	}

private bool RolledOver()
    {
        return (transform.eulerAngles.z > 10 || transform.eulerAngles.z < -10);
    }

    //private void ResetPetRotation()
    //{
    //    float axisHorizontal = Input.GetAxisRaw("Horizontal");
    //    float axisVertical = Input.GetAxisRaw("Vertical");
    //    transform.position = new Vector3(transform.position.x, HeightOfFloor, transform.position.z);
    //    transform.rotation = Quaternion.identity;
    //    axisHorizontal = 0;
    //    axisVertical = 0;

    //}

    IEnumerator ResetPetPosition()
    {
        yield return new WaitForSeconds(5f);
        if (PetRigidBody == null)
        {
            PetRigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
        PetRigidBody.velocity = Vector3.zero;
        PetRigidBody.angularVelocity = 0f;
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        float axisVertical = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(transform.position.x, HeightOfFloor, transform.position.z);
        transform.rotation = Quaternion.identity;
        axisHorizontal = 0;
        axisVertical = 0;
    }

    private bool isFlying()
    {
        return (transform.position.y > HeightOfFloor);
    }
}

