using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private float horizontalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontalMove = -1;
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, rb.linearVelocityY);
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
}
