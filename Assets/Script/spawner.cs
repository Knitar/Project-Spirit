using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab de la flèche
    public Vector2 arrowDirection = Vector2.right; 
    public float arrowSpeed = 25f; 

    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {

        playerSpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            SpawnArrow();
        }
    }

    /********************************** Mise en place de la flèche *******************************/
    void SpawnArrow()
    {
    
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        float direction = playerSpriteRenderer.flipX ? -1f : 1f;


        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(arrowSpeed * direction, 0);

    
        if (direction == -1f)
        {
            arrow.transform.localScale = new Vector3(-2, 1, 1); // Retourner visuellement la flèche
        }


    }
    
}
