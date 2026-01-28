using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public Animator animator;
    public float slimeSpeed = 2f;
    public float slimeUpWardSpeed = 1;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private bool isCrashed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCrashed = Random.value < 0.5f;

    }


    void Update()
    {
        

        if (Physics2D.Raycast(transform.position, Vector2.left, 1f, wallLayer))
        {
            isCrashed = true;

        }
        else if (Physics2D.Raycast(transform.position, Vector2.right, 1f, wallLayer))
        {
            isCrashed = false;
        }
    }

    private void FixedUpdate()
    {
        SlimeMovement();
        AnimatorFunc();

    }

    private void SlimeMovement()
    {
        if (transform.position.y <= -0.5)
        {
            rb.linearVelocity = new Vector2(0, slimeUpWardSpeed);
        }
        else
        {
            if (isCrashed)
            {
                rb.linearVelocity = new Vector2(slimeSpeed, 0);
               
            }
            if (!isCrashed)
            {
                rb.linearVelocity = new Vector2(-slimeSpeed, 0);
               

            }
        }
    }
    private void AnimatorFunc()
    {
        animator.SetFloat("X", rb.linearVelocityX);
        animator.SetFloat("Y", rb.linearVelocityY);
    }
}
