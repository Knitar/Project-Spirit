using UnityEngine;

public class SuivieCamera : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 povOffset;
    private Vector3 velocity;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + povOffset, ref velocity, timeOffset);
    }
}
