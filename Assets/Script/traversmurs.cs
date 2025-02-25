using UnityEngine;

public class traversmurs : MonoBehaviour
{
    public bool canPassWalls = false; // Capacité activée ou non
    private Collider2D playerCollider;

    // Référence à l'Animator
    public Animator animator;

    void Start()
    {
        // Récupère le collider du joueur
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Activer la capacité quand la touche est maintenue (X)
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnablePassThroughWalls();
        }

        // Désactiver la capacité quand la touche est relâchée
        if (Input.GetKeyUp(KeyCode.X))
        {
            DisablePassThroughWalls();
        }
    }

    void EnablePassThroughWalls()
    {
        canPassWalls = true;

        // Met à jour l'Animator
        animator.SetBool("canPassWalls", true);

        // Ignorer les collisions avec les murs traversables
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("travmurs"), true);
    }

    void DisablePassThroughWalls()
    {
        canPassWalls = false;

        // Met à jour l'Animator
        animator.SetBool("canPassWalls", false);

        // Réactiver les collisions
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("travmurs"), false);
    }
}