using UnityEngine;

public class move_player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero; 
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y); // rb.Velocity.y
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity,targetVelocity, ref velocity, .05f); 
    }
}
