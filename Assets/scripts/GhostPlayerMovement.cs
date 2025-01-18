using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.Rendering;
using UnityEngineInternal;

public class GhostPlayerMovement : MonoBehaviour
{
    [SerializeField]
    public Transform HumanTransform;

    float chainLimit = 25f;

    public PlayerInput playerInput;
    Animator animator;
    CharacterController characterController;
    public Camera playerCamera;

    // Variables to store optimized getter/setter parameter IDs
    int isWalkingHash;
    int isRunningHash;
    int isFallingHash;
    int isJumpingHash;

    Vector3 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    Vector3 lastFrameMovement;

    float currentForwardMovement;
    float currentDirectionMovement;

    bool isDirectionPressed;
    bool isMovementPressed;
    bool isRunPressed;
    bool isJumpPressed;

    float speed = 13.0f;
    float runMultiplier = 1.3f;

    bool isJumping = false;

    float mouseRotation = 0f;
    float mouseSensibility = 100f;

    float airResistance = .7f;

    [SerializeField]
    Transform playerRef;
    float cameraSpeed = 7f; 
    float maxCameraZoom = 5f;
    float minCameraZoom = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        #region AnimatorHashs
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        isFallingHash = Animator.StringToHash("IsFalling");
        isJumpingHash = Animator.StringToHash("IsJumping");
        #endregion AnimatorHashs

        #region InputSetup
        // Movement direction from WASD
        playerInput.GhostControls.Movement.started += OnMovementInput;
        playerInput.GhostControls.Movement.performed += OnMovementInput;
        playerInput.GhostControls.Movement.canceled += OnMovementInput;

        playerInput.GhostControls.Run.started += OnRun;
        playerInput.GhostControls.Run.canceled += OnRun;

        playerInput.GhostControls.MouseRotation.started += OnMouseRotation;
        playerInput.GhostControls.MouseRotation.performed += OnMouseRotation;
        playerInput.GhostControls.MouseRotation.canceled += OnMouseRotation;

        #endregion InputSetup

    }

    #region InputCallbacks
    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector3>();
        currentMovement = currentMovementInput;

        currentRunMovement = currentMovement * runMultiplier;

        isMovementPressed = currentMovementInput != Vector3.zero;
    }

    void OnMouseRotation(InputAction.CallbackContext context)
    {
        mouseRotation = context.ReadValue<float>();
    }

    void OnRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }
    #endregion InputCallbacks

    // Update is called once per frame
    void Update()
    {
        float yRotation = mouseRotation * mouseSensibility * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0f, yRotation, 0f);

        HandleMovement();

        if (isMovementPressed)
        {
            // Optionally rotate or handle animations
        }

        //HandleAnimation();
        
        HandleChain();
        HandleCameraDistace();
    }

    void HandleMovement()
    {
        // Handle horizontal movement
        Vector3 movement = Vector3.zero;

        if (isMovementPressed)
        {
            movement = (isRunPressed ? currentRunMovement : currentMovement);
            movement = movement.normalized * speed;
            movement = transform.rotation * movement;
        }


        // Apply final movement
        characterController.Move(movement * Time.deltaTime);
        
        lastFrameMovement = movement;
    }

    void HandleChain()
    {
        if (Vector3.Distance(transform.position, HumanTransform.position) < chainLimit) return;


        Vector3 dir = HumanTransform.position - transform.position;
        characterController.Move(dir * Time.deltaTime * speed);
    }

    void HandleAnimation()
    {
        bool IsWalking = animator.GetBool(isWalkingHash);
        bool IsRunning = animator.GetBool(isRunningHash);
        bool IsFalling = animator.GetBool(isFallingHash);
        bool IsJumping = animator.GetBool(isJumpingHash);

        if (characterController.isGrounded)
        {
            if (IsJumping && !isJumping)
            {
                animator.SetBool("IsJumping", false);
            }

            if (IsFalling)
            {
                animator.SetBool("IsFalling", false);
            }

            if (isMovementPressed && !IsWalking)
            {
                animator.SetBool("IsWalking", true);
            }

            if (!isMovementPressed && IsWalking)
            {
                animator.SetBool("IsWalking", false);
            }

            if (IsWalking && !IsRunning && isRunPressed)
            {
                animator.SetBool("IsRunning", true);
            }

            if ((!IsWalking && IsRunning) || IsRunning && !isRunPressed)
            {
                animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            if (isJumpPressed && !IsJumping)
            {
                animator.SetBool("IsJumping", true);
            }
            if (!IsFalling && !isJumpPressed)
            {
                animator.SetBool("IsFalling", true);
            }
        }

    }

    void HandleCameraDistace()
    {
        // Layer Mask to ignore only the "Ghost Layer"
        int layerToIgnore = 1 << 7;
        int layerMask = ~layerToIgnore;

        Vector3 direction = (playerRef.position - playerCamera.transform.position).normalized;
        float distance = Vector3.Distance(playerRef.position, playerCamera.transform.position);

        RaycastHit[] hits = Physics.RaycastAll(playerCamera.transform.position, direction, distance, layerMask);

        if (hits.Length <= 0 && distance < maxCameraZoom) {
            playerCamera.transform.position += -playerCamera.transform.forward * cameraSpeed * Time.deltaTime;
        }else if(hits.Length > 0 && distance > minCameraZoom){
            playerCamera.transform.position += playerCamera.transform.forward * cameraSpeed * Time.deltaTime;
        }
    }
}
