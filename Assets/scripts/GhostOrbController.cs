using UnityEngine;
using UnityEngine.UIElements;

public class GhostOrbController : MonoBehaviour
{
    float radius = 2f;

    LayerMask ghostLayerMask;

    [SerializeField]
    DoorController door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostLayerMask = LayerMask.GetMask("GhostPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, ghostLayerMask);

        if (colliders.Length > 0)
        {
            door.OpenDoor();
        }
    }
}
