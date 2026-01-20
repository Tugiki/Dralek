using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("References")]
    private CharacterController controller;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float gravity = 9.81f;

    private float verticalVelocity;
    private Animator animator;


    [Header("Input")]
    private float verticalInput;
    private float horizontalInput;

    private void InputManagement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void GroundMovement()
    {
        Vector2 move = new Vector2(horizontalInput, verticalInput);

        move.y = VerticalForceCalculation();

        move *= walkSpeed;
        
        controller.Move(move * Time.deltaTime);
    }

    private void Movement()
    {
        GroundMovement();
        Player2DAnimation();
    }

    private float VerticalForceCalculation()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Small negative value to keep the player grounded
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2 * gravity);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void Player2DAnimation()
    {
        animator.SetFloat("InputX", horizontalInput);
        animator.SetFloat("InputY", verticalInput);
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }
}
