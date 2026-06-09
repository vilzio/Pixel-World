using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float moveSpeed;
    private bool inAir;
    
    public Transform cameraTransform;
    public Vector3 defaultCameraPosition;
    public float camMaxHeight = 5f;
    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float jumpForce = 100f;
    public GameObject jumpEffect;
    public GroundCheck groundCheck;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultCameraPosition = cameraTransform.localPosition;
        defaultCameraPosition.y += 1;
    }
    
    private void Update()
    {
        moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
                inAir = true;
            }
            else if (inAir)
            {
                rb.AddForce(Vector3.up * jumpForce);
                inAir = false;
                Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        if (rb.position.y < camMaxHeight)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                new Vector3(cameraTransform.position.x, defaultCameraPosition.y, cameraTransform.position.z), 0.1f);
        }
        else
        {
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, defaultCameraPosition, 0.1f);
        }
    }
}
