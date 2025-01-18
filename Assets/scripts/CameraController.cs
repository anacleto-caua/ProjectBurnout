using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Video;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    #region movementVars
    private CharacterController characterController;

    private float cameraSpeed = 5f;
    private float cameraAcelleration = 2.5f;

    private float upDownAxisStrengh = 2.0f;
    #endregion movementVars

    #region cmdVars
    //bool showConsole = true;
    #endregion cmdVars

    [SerializeField] public GameObject VertexPrefab;

    //public Graph graph;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        /*
        graph = gameObject.AddComponent<Graph>();
        graph.VertexPrefab = VertexPrefab;

        graph.AddVertice();
        graph.AddVertice();
        graph.AddVertice();
        graph.AddVertice();
        graph.AddVertice();

        graph.AddEdge(0,1);
        graph.AddEdge(0,2);
        graph.AddEdge(0,3);
        graph.AddEdge(1,2);

        graph.RenderButRecursivetly(5);
        */
        //graph.RenderAndRepulse(2);

    }

    void Update()
    {
        //graph.Vertices[0].Render(graph.Vertices[0].position + (Vector3.one * 0.001f));
        #region camera3dMovement
        float upDownAxis = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            upDownAxis -= upDownAxisStrengh;
        }
        if (Input.GetKey(KeyCode.E))
        {
            upDownAxis += upDownAxisStrengh;
        }

        Vector3 forward = (characterController.transform.forward * Input.GetAxis("Vertical")) * cameraSpeed * Time.deltaTime;
        Vector3 sideways = (characterController.transform.right * Input.GetAxis("Horizontal")) * cameraSpeed * Time.deltaTime;
        Vector3 vertical = characterController.transform.up * upDownAxis * cameraSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= cameraAcelleration;
            forward *= cameraAcelleration;
            sideways *= cameraAcelleration;
        }

        characterController.Move(vertical);
        characterController.Move(forward);
        characterController.Move(sideways);
        #endregion camera3dMovement

        #region cameraLooking
        if (Input.GetMouseButton(1))
        {
            Vector3 lookForward = characterController.transform.eulerAngles;
            lookForward.y += Input.GetAxis("Mouse X");
            lookForward.x += -Input.GetAxis("Mouse Y");

            characterController.transform.eulerAngles = lookForward;
        }
        #endregion cameraLooking

        #region dumbDebug
        /*
        if(Input.GetKeyDown(KeyCode.P)) {
            graph.printGraph();
        }
        */
        #endregion dumbDebug
    }
}