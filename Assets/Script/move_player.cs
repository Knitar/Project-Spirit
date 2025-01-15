using UnityEngine;

public class move_player : MonoBehaviour
{
    public float moveSpeed; // vitesse du perso 

    public float jumpForce;
    public Rigidbody2D rb; // réference à rigibody 2D (unity)
    private Vector3 velocity = Vector3.zero; // pour "lisser" le mouv du perso 
    public Animator animator; // animations
    public SpriteRenderer spriteRenderer; // unity 

    public bool saut; 

    public bool sol;

    public Transform spawnPoint; // le point de spawn de la fleche 
    public Transform checksolgauche;
    public Transform checksoldroite;
    void FixedUpdate()
    {
        sol = Physics2D.OverlapArea(checksolgauche.position,checksoldroite.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Cette ligne fait bouger le perso 
        // par contre pour les touches : edit/project-settings/Input-mangager/horizontal

        if(Input.GetButtonDown("Jump") && sol)
        {
            saut = true;
        }
        MovePlayer(horizontalMovement); //appele à la méthode qui calcule le déplacement 

        Flip(rb.linearVelocity.x); //appelle de la fonction qui retourne 

        float CharacterVelocity = Mathf.Abs(rb.linearVelocity.x);

        animator.SetFloat("speed", CharacterVelocity); // met à jour l'animation

    }

    /***************************** methode pour qu'il bouge *****************/
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y); // vitesse cible du personnage
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity,targetVelocity, ref velocity, .05f); // Le SMoothdamp lisse la transition entre la vitesse actuelle et celle ciblée  
        
        if(saut)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            saut = false;
        }
   
    }
    /********************************** Retourne le personnage(litteralement) *******************************/

    void Flip(float _velocity) // retourne le personnage si il se déplace dans le sens inverse
    //De plus ça flip aussi les spawm point des flèches pour que les flèches soient dans le sens du personnage
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
