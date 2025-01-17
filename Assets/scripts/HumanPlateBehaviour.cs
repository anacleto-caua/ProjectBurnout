using UnityEngine;

public class HumanPlateBehaviour : MonoBehaviour
{
    // Called when this GameObject starts colliding with another
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }

    // For triggers, use this method instead
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
    }
}
