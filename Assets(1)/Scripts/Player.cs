using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float maxspeed = 3;
    public float speed=1500f;
    public float jumpPower = 1500f;
    
    public bool grounded;

    private Rigidbody2D rd2d;
    private Animator anim;
    void Start ()
    {
        rd2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-116, 103, 9);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(116, 103, 9);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rd2d.AddForce(Vector2.up * jumpPower);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rd2d.AddForce((Vector2.right * speed) * h);
        // Limiting the speed of the player.
        if (rd2d.velocity.x > maxspeed)
        {
            rd2d.velocity = new Vector2(maxspeed, rd2d.velocity.y);
        }
        if (rd2d.velocity.x < -maxspeed)
        {
            rd2d.velocity = new Vector2(-maxspeed, rd2d.velocity.y);
        }
    }
}
