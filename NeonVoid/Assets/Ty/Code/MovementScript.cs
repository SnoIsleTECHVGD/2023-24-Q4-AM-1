using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript: MonoBehaviour
{
    public float moveSpeed;

    public Collider Collider;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public float jumpForce;
    public float jumpCooldown;
    public float airMulitipler;
    public bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space;

    RaycastHit Hit;

    public float groundDrag;

    public float playerHeight;
    public LayerMask Water;
    public bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        grounded = Physics.BoxCast(Collider.bounds.center, transform.localScale * 0.5f, 
            transform.forward, out Hit, transform.rotation, jumpForce);

        MyInput();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;


        Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
    }

    private void MyInput()
    {
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * airMulitipler, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVec = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVec.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVec.normalized * moveSpeed;
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
       readyToJump = true;
    }
}
