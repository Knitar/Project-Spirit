using UnityEngine;

public class Jump_Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpPower;

    public float fallPower;

    private Vector2 vecGravity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;
    bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vecGravity = new Vector2(0, Physics2D.gravity.y);
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += vecGravity * fallPower * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
