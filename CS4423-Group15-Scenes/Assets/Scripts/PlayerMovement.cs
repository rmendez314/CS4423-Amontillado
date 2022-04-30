using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    public float MovementSpeed;

    public float groundDrag;

    //[Header ("")]
    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private PlayerStats stats;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Check if player is jumping
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .3f, whatIsGround);

        PlayerInput();
        SpeedControl();
        //Add in drag
        if (grounded)
		{
            //print("Grounded!");
            rb.drag = groundDrag;
        }
        else
		{
            //print("Not grounded!");
            rb.drag = 0;
        }
            
    }

    private void FixedUpdate()
	{
        if(!stats.IsDead())
            MovePlayer();
	}

    private void PlayerInput()
	{
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jump
        if (Input.GetKey(KeyCode.Space) && canJump && grounded)
		{
            //print("Jumping");
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
		}

	}

    private void MovePlayer()
	{
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * MovementSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
	{
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limit movement speed
        if(flatVel.magnitude > MovementSpeed)
		{
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		}
	}

    private void Jump()
	{
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

    private void ResetJump()
	{
        canJump = true;
	}
}
