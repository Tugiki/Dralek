using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public Transform groundLoc;
    public float slimeSpeed = 2f;
    public float slimeUpWardSpeed = 1;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private bool isCrashed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCrashed = true; ;

    }


    void Update()
    {
       

        if (Physics2D.Raycast(transform.position, Vector2.left, 1f, wallLayer))
         {
             isCrashed = true;

        }
         else if (isCrashed = Physics2D.Raycast(transform.position, Vector2.right, 1f, wallLayer))
         {
             isCrashed = false;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
