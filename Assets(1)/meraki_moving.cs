using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meraki_moving : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 100f;

    float horizontalMove = 0f;

    public bool jump = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(jump);
        if (Input.GetButtonDown("Jump"))
    {
            jump = true;
    }
		
	}

    void FixedUpdate()
        
    {
        Debug.Log(jump);
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
