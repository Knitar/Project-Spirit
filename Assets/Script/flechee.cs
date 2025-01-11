using UnityEngine;

public class flechee : MonoBehaviour
{

    public float speed = 12f;
    public float lifetime = 5f; 

    /********************************** Si elle ne touche rien *******************************/
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    /********************************** Contact avec quelque chose *******************************/
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
