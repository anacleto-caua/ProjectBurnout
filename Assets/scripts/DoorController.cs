using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField]
    Transform DoorItself;

    [SerializeField]
    bool isToOpen = false;

    bool isOpen = false;

    float doorSpeed = 3.5f;
    float neededDoorDisplacement = 5.1f;

    Vector3 doorOrigin;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorOrigin = DoorItself.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isToOpen && !isOpen) {
            DoorItself.position += DoorItself.up * doorSpeed * Time.deltaTime;
        }

        if(Vector3.Distance(doorOrigin, DoorItself.position) > neededDoorDisplacement)
        {
            isToOpen = false;
            isOpen = true;
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            isToOpen = true;
        }
    }
}
