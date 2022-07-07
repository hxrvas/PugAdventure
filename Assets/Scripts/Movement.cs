using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;

    
    public float speed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;

    bool grounded = false;

    public bool isHanging = false;

    private float YVelocity;

    public int cookies = 0;

    public Text points;

    PlayerSounds sound;

    // Update is called once per frame
    private void Start()
    {
        sound = GetComponent<PlayerSounds>();
    }

    public void addCookie()
    {
        cookies += 10;
        Debug.Log(cookies);
        sound.playCookie();
    }

    void Update()
    {
        verticalMove = rb.velocity.y;
        grounded = controller.Grounded();
        
        animator.SetFloat("JumpSpeed", verticalMove);
        animator.SetBool("Grounded", grounded);

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (isHanging) horizontalMove *= 2f;

        animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    public void displayPoints()
    {
        int cen, dec, unit;
        cen = cookies/100 % 10;
        dec = cookies/10 % 10;
        unit = cookies % 10;

        points.text = cen.ToString() + dec.ToString() + unit.ToString();
    }

    void FixedUpdate()
    {
        //Move Gandalf
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
