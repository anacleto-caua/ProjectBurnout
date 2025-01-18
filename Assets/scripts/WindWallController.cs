using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class WindWallController : DoorController
{

    public GameObject boxC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OpenDoor()
    {
        boxC.GetComponent<ParticleSystem>().Stop();
        boxC.GetComponent<BoxCollider>().enabled = false;
    }
}
