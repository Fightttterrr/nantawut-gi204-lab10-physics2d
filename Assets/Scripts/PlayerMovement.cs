using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    Vector2 moveInput; //for walk with addforce
    
    //Walk
    float move;
    [SerializeField] float speed;
    
    //Jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Wall with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        
        /*
        //Walk
        move = Input.GetAxis("Horizontal"); //x - axis
        
        //use rigidbody2d to move left and right (x-axis)
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
        */
        
        //Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2 (rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!!"); // for debugging
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
