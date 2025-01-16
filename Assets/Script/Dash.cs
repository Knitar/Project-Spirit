using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool dash = false;
    public float invincibiliteD = 0.3f;

     public float dashSp = 45f;
    public Animator animator;
    private Collider2D playerCollider;
    public float dashD = 0.5f;
    private float DTime;
    public Rigidbody2D rb;
    private Vector2 dashDir;

    private bool invincible = false;

    void Start()
    {

        playerCollider = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && !dash )
        {
            EnableDash();
          
        }
        if(dash)
        {
            DTime -= Time.deltaTime;

            if (DTime <= 0)
            {
                DisableDash();
            }
        }
        if (invincible)
        {
            invincibiliteD -= Time.deltaTime;
            if (invincibiliteD <= 0)
            {
                DisableInvin();
            }
        }

    }

    void EnableDash()
    {
        dash = true;
        DTime = dashD;

        animator.SetBool("dashh", true);

        float horizontal = Input.GetAxisRaw("Horizontal"); // Gauche ou Droite
        float vertical = Input.GetAxisRaw("Vertical"); // Haut ou Bas
        dashDir = new Vector2(horizontal, vertical).normalized;

        // Appliquer une vitesse au Rigidbody dans la direction du dash
        rb.linearVelocity = dashDir * dashSp;

        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemies"), true);
        
    }

    void DisableDash()
    {   
        dash = false;

        animator.SetBool("dashh", false);

        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemies"), false);

    }

    void DisableInvin()
    {
        invincible = false;
        
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemies"), false);
    }

}
