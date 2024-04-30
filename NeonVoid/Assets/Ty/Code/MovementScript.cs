using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementScript: MonoBehaviour
{
    public float moveSpeed;

    public Collider Collider;
    public Transform orientation;
    public Transform PlayerForward;
    public Animator animator;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    public Vector3 Offset;

    Rigidbody rb;

    public float jumpForce;
    public float jumpCooldown;
    public float airMulitipler;
    public bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space;

    RaycastHit Hit;

    public float groundDrag;

    public float playerHeight;
    public float MaxDistance;
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
        PlayerForward.forward = orientation.forward;
    }
    private void Update()
    {
        grounded = Physics.BoxCast(Collider.bounds.center - Offset, transform.localScale * 0.5f, -transform.up, out Hit, transform.rotation, MaxDistance);

        MyInput();
        
        if(horizontalInput < 1f && verticalInput < 1f || horizontalInput < -1f && verticalInput < -1f)
        {
            animator.SetBool("IsMoving", false);
            Debug.Log("IDLE");
        }


        if (grounded)
        {
            animator.SetBool("IsGrounded", true);
            rb.drag = groundDrag;
            Debug.Log("Hit : " + Hit.collider.name);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            rb.drag = 0.5f;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(Collider.bounds.center - Offset, transform.localScale * 0.5f);

    }

    private void MyInput()
    {
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            readyToJump = false;

            Jump();
            animator.SetTrigger("Jump");
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        animator.SetBool("IsMoving", true);

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
            
        }


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
        animator.ResetTrigger("Jump");
    }
}
