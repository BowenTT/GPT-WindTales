using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemodes : MonoBehaviour {

    [SerializeField]
    private GameObject PlayerPet;
    [SerializeField]
    private GameObject SoccerBall;
    [SerializeField]
    private Button BallModeButton;
    [SerializeField]
    private Button AcrobatModeButton;
    [SerializeField]
    private Button CouchModeButton;

    [SerializeField]
    private Sprite GreyButton;

    [SerializeField]
    private Sprite GreenButton;

    private int GameMode;
    [SerializeField]
    private NPCMovement NPCMovement;

    private float HeightOfFloor = -2.6f;
    private float[] CouchPositions = { -3.65f, -2.32f, -0.8f };
    Vector3 PetCouchScale = new Vector3(0.8f, 0.8f, 0.8f);
    Vector3 PetNormalScale = new Vector3(1, 1, 1);
    Vector2 PetStartPosition;
    Rigidbody2D PetRigidBody;
    CircleCollider2D Collider;
    Animator animator;


	// Use this for initialization
    void Start () {
        PetRigidBody = PlayerPet.gameObject.GetComponent<Rigidbody2D>();
        Collider = PlayerPet.gameObject.GetComponent<CircleCollider2D>();
        PetStartPosition = new Vector2(0, HeightOfFloor);
        animator = PlayerPet.gameObject.GetComponent<Animator>();
    }
	

    public void SelectGameMode(int GameMode)
    {
        switch (GameMode)
        {
            //Ball
            case 0:
                {
                    BallMode();
                    break;
                }

            case 1:
                {
                    AcrobaticMode();
                    break;
                }
            case 2:
                {
                    CouchMode();
                    break;
                }
            default:
                break;
        }
    }


    void BallMode()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //Disable animations
            animator.enabled = false;

            //Create a new ball and re-engage Rigidbody and re-enable the AcrobatMode button
            if (PetRigidBody == null)
            {
                PetRigidBody = PlayerPet.gameObject.AddComponent<Rigidbody2D>();
            }
            SoccerBall.SetActive(true);
            AcrobatModeButton.interactable = true;
            AcrobatModeButton.image.sprite = GreenButton;

            // Reset PlayerPet's position
            ChangePlayerPetAspects(PetStartPosition, Quaternion.identity, 1, 100, PetNormalScale, true);

            //Disable the button
            BallModeButton.interactable = false;
            BallModeButton.image.sprite = GreyButton;
            CouchModeButton.interactable = true;

            //Enable NPC Movement
            NPCMovement.enabled = true;
        }
    }

    void AcrobaticMode()
    {
        //Disable the ball and re-enable the BallMode button
        SoccerBall.SetActive(false);
        BallModeButton.interactable = true;
        BallModeButton.image.sprite = GreenButton;

        //Reset PlayerPet's position
        ChangePlayerPetAspects(PetStartPosition, Quaternion.identity, 1, 100, PetNormalScale, true);

        //Destroy it's rigidbody, else it will bug with animations
        Destroy(PetRigidBody);

        //Enable animations
        animator.enabled = true;

        //Disable the button
        AcrobatModeButton.interactable = false;
        AcrobatModeButton.image.sprite = GreyButton;
        CouchModeButton.interactable = false;

        //Disable NPC Movement
        NPCMovement.enabled = false;

    }

    void CouchMode()
    {
        int randomCouchValue = Random.Range(0, CouchPositions.Length);
        Vector2 randomCouchPosition = new Vector2(CouchPositions[randomCouchValue], -0.12f);
        ChangePlayerPetAspects(randomCouchPosition, Quaternion.identity, 0f, 0, PetCouchScale, false);
        PetRigidBody.velocity = Vector2.zero;
        PetRigidBody.angularVelocity = 0f;
        PlayerPet.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        NPCMovement.enabled = false;

    }

    void ChangePlayerPetAspects(Vector2 position, Quaternion rotation, float gravity, int mass, Vector3 localscale, bool ColliderOn)
    {
        PlayerPet.transform.position = position;
        PlayerPet.transform.rotation = rotation;
        PetRigidBody.gravityScale = gravity;
        PetRigidBody.mass = mass;
        PlayerPet.transform.localScale = localscale;
        Collider.enabled = ColliderOn;

    }
}