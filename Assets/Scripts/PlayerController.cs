using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController2D controller;

    public float speed = 900f;
    float horizontal = 0f;
    private bool jump = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("PlayerX", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //Horizontal movement
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
