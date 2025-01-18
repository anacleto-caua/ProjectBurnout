using UnityEngine;
using UnityEngine.Rendering;

public class HumanPlateBehaviour : MonoBehaviour
{
    Vector3 originalPos;

    [SerializeField]
    DoorController doorToOpen;

    [SerializeField]
    float plateDisplacement = 0.5f;

    [SerializeField]
    float plateSpeed = 2f;

    [SerializeField]
    double timerToForget = .5f;

    bool isPressed = false;
    float pointCorrection = 0.02f;
    double timer = 0;

    private void Start()
    {
        originalPos = transform.position;    
    }

    private void Update()
    {
        float dist = Vector3.Distance(originalPos, transform.position);

        if (isPressed && dist < plateDisplacement)
        {
            transform.position -= transform.up * plateSpeed * Time.deltaTime;
        }

        if(!isPressed && dist > 0 && timer >= timerToForget)
        {
            if (dist <= pointCorrection)
            {
                transform.position = originalPos;
                return;
            }

            transform.position += transform.up * plateSpeed * Time.deltaTime;
        }

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        timer = 0;
        doorToOpen.OpenDoor();
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left trigger");
        isPressed = false;
    }
}
