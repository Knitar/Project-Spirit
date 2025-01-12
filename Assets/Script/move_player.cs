using UnityEngine;

public class move_player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero; 
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Transform spawnPoint;
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.linearVelocity.x);

        float CharacterVelocity = Mathf.Abs(rb.linearVelocity.x);

        animator.SetFloat("speed", CharacterVelocity);

    }

    /***************************** methode pour qu'il bouge *****************/
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y); // rb.Velocity.y
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity,targetVelocity, ref velocity, .05f); 
    }
    /********************************** Retourne le personnage *******************************/

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

             if (spawnPoint != null)
            {
                spawnPoint.localPosition = new Vector3(Mathf.Abs(spawnPoint.localPosition.x), spawnPoint.localPosition.y, spawnPoint.localPosition.z);
            }
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;

            if (spawnPoint != null)
            {
                spawnPoint.localPosition = new Vector3(-Mathf.Abs(spawnPoint.localPosition.x), spawnPoint.localPosition.y, spawnPoint.localPosition.z);
            }
        }
    }
}
