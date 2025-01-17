using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;

    public AudioClip Hitsound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(Hitsound,transform.position);
            Destroy(objectToDestroy);
        }
    }
}
