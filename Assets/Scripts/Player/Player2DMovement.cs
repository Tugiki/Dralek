using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem smokeFX;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3.5f;
    private float horizontalMove;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private int extraJumps = 1;
    private int jumpReamining;
    private bool canCrouch = false;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPos;
    private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    [SerializeField] private LayerMask groundLayer;

    
    [Header("Gravity")]
    [SerializeField] private float baseGravity = 4f;
    [SerializeField] private float maxFallSpeed = 9.81f;    
    [SerializeField] private float fallSpeedMultiplier = 1f;
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontalMove = -1;
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, rb.linearVelocityY);
       GroundCheck();
       Gravity();
       AnimatorFunc();
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            horizontalMove += context.ReadValue<Vector2>().x;
            
            return;
        }
            horizontalMove = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context)
    {   
        canCrouch = true;
        if (jumpReamining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);                
                jumpReamining --;
                smokeFX.Play();
                
            }
        }
    } 

    public void Crouch(InputAction.CallbackContext context)
    {
        if (canCrouch)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, -9.81f);
                canCrouch = false;
                animator.SetTrigger("Crouch");
            }
        }
    }
    private void GroundCheck()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpReamining = extraJumps;
            canCrouch = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
    private void Gravity()
    {
        if(rb.linearVelocityY < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Max(rb.linearVelocityY, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    private void AnimatorFunc()
    {
        animator.SetFloat("xVelocity", rb.linearVelocityX);
        animator.SetFloat("yVelocity", rb.linearVelocityY);
    }
}
