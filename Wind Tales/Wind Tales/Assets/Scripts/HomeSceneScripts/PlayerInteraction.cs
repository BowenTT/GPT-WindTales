using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {


    private int maxJumpAnimations = 4;
    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {}


    private void OnMouseDown()
    {
        //Debug.Log("PRESS");
        //anim.enabled = true;
        //rb2d.isKinematic = true;
        int randomJumpAnimation = Random.Range(0, maxJumpAnimations);
        anim.SetTrigger("Jump");
        anim.SetInteger("JumpAnimation", randomJumpAnimation);
    }


}
