using UnityEngine;
using System.Collections;

public class JoueurHealth : MonoBehaviour
{

    public int maxHealth = 0;
    public int currentHealth;

    public float invicibilityTimeAfterHit = 3f;
    public float invicibilityFlashDelay = 0.2f;

    public SpriteRenderer graphics;
    public bool isInvisible = false;

    public HealthBar healthBar;
    
    public AudioClip hitSound;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvisible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvisible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }

        //Vérifier si le joueur a toujours de la vie
        if (currentHealth <= 0)
        {
            isInvisible = false;
            Die();
            return;
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est mort");
        //bloquer les mouvements du joueur
        move_player.instance.enabled = false;
        //joueur l'animation de mort
        move_player.instance.animator.SetTrigger("Mort");
        //Empêcher les animations avec le décort
        move_player.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        move_player.instance.playerCollider.enabled = false;
    }

    public IEnumerator InvicibilityFlash()
    {
        while(isInvisible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvisible = false;
    }
}
