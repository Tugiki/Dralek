using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   
}
