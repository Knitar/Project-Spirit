using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    /********************************** Suis le personnage(avec leger décalage) *******************************/

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity ,timeOffset);
        // Avec la modification de transform.position la caméra suit la position du joueur (player.transform.position) avec un petit decalage de temps ou d'espace 
    }
}
