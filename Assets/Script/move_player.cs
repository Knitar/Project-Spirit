using UnityEngine;

public class move_player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
<<<<<<< HEAD
    private Vector3 velocity = Vector3.zero;

    public Animator animator; 
=======
    private Vector3 velocity = Vector3.zero; 
    public Animator animator;

>>>>>>> a935972cacf1dcc8b62410e85150030b1ecaab36
    public SpriteRenderer spriteRenderer;
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.linearVelocity.x);

<<<<<<< HEAD
        float CharacterVelocity = Mathf.Abs(rb.linearVelocity.x);

        animator.SetFloat("Speed", CharacterVelocity);
=======
        float charactervelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("speed",charactervelocity);

>>>>>>> a935972cacf1dcc8b62410e85150030b1ecaab36
    }

    /***************************** methode pour qu'il bouge *****************/
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y); // rb.Velocity.y
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity,targetVelocity, ref velocity, .05f); 
    }

<<<<<<< HEAD
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if(_velocity < -0.1f)
=======
    /********************************** Retourne le personnage *******************************/

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
>>>>>>> a935972cacf1dcc8b62410e85150030b1ecaab36
        {
            spriteRenderer.flipX = true;
        }
    }
}
