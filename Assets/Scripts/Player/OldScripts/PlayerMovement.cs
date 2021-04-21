using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    public Animator animator;

    private bool isOnGround = true;

    public float speedAmount = 10f;
    private float walkSpeed;

    public int permissionOfJump = 2;
    public float jumpAmount = 120f;
    private float jumpValue;
    private int numberOfJump;


    void Start()
    {
        walkSpeed = speedAmount/2;
        numberOfJump = permissionOfJump;
        //Debug.Log(numberOfJump);
        jumpValue = jumpAmount;
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //Debug.Log(animator.GetBool("Jump"));


        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftControl) && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            //Debug.Log("deneme");
            animator.SetFloat("Speed", walkSpeed);
            //Debug.Log(animator.GetFloat("Speed"));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) * speedAmount);
        }

        if (Input.GetKeyDown(KeyCode.Space) && numberOfJump > 0)
        {
            
            //Debug.Log("girdi............................................ " + numberOfJump + jumpValue);

            numberOfJump -= 1;
            rgb.AddForce(Vector3.up * jumpValue);
            animator.SetBool("Jump", true);
            //Debug.Log("girdi............................................ " + numberOfJump + jumpValue + animator.GetBool("Jump"));
            jumpValue /= 2f;
        }

        

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name == "GroundParkur")
        {
            isOnGround = true;
            animator.SetBool("Jump", false);
            numberOfJump = permissionOfJump;
            jumpValue = jumpAmount;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground" || collision.gameObject.name == "GroundParkur")
        {
            isOnGround = false;
        }
    }

    
}
