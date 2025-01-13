using UnityEngine;

public class flechee : MonoBehaviour
{

    public float speed = 12f;
    public float lifetime = 5f; 

    /********************************** Si elle ne touche rien *******************************/
    void Start()
    {
        Destroy(gameObject, lifetime); // ça detruit l'objet
    }

    /********************************** Contact avec quelque chose *******************************/
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);// ça detruit l'objet
    }
}
