using UnityEngine;

public class PatrouilleEnnemie : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;

    public int DamageOnCollision = 20;

    private Transform target;
    private int destPoint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            JoueurHealth joueurHealth = collision.transform.GetComponent<JoueurHealth>();
            joueurHealth.TakeDamage(DamageOnCollision);
        }
    }
}
