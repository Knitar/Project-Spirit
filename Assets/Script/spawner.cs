using UnityEngine;

public class spawner : MonoBehaviour
{
     public GameObject arrowPrefab; // prefab du serpent
    public Vector2 arrowDirection = Vector2.right; 
    public float arrowSpeed = 5f; 
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

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = arrowDirection * arrowSpeed;
        }
    }
}
