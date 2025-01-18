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

public class HumanPlayerMovement : MonoBehaviour
{

    public PlayerInput playerInput;

    [SerializeField]
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

    float speed = 5.0f;
    float runMultiplier = 2.0f;
    float gravity = -9.81f;
    float groundedGravity = -0.05f;

    float maxJumpTime = 1f;
    float initialJumpVelocity;
    float maxJumpHeight = 3f;
    bool isJumping = false;

    float mouseRotation = 0f;
    float mouseSensibility = 100f;

    [SerializeField]
    Transform playerRef;
    float cameraSpeed = 7f; 
    float maxCameraZoom = 5f;
    float minCameraZoom = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        #region AnimatorHashs
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        isFallingHash = Animator.StringToHash("IsFalling");
        isJumpingHash = Animator.StringToHash("IsJumping");
        #endregion AnimatorHashs

        #region InputSetup
        // Movement direction from WASD
        playerInput.HumanControls.Movement.started += OnMovementDirInput;
        playerInput.HumanControls.Movement.performed += OnMovementDirInput;
        playerInput.HumanControls.Movement.canceled += OnMovementDirInput;

        playerInput.HumanControls.Run.started += OnRun;
        playerInput.HumanControls.Run.canceled += OnRun;

        playerInput.HumanControls.Jump.started += OnJump;
        playerInput.HumanControls.Jump.canceled += OnJump;

        playerInput.HumanControls.MouseRotation.started += OnMouseRotation;
        playerInput.HumanControls.MouseRotation.performed += OnMouseRotation;
        playerInput.HumanControls.MouseRotation.canceled += OnMouseRotation;

        #endregion InputSetup

        SetupJumpVariables();
    }
    void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    #region InputCallbacks
    void OnMovementDirInput(InputAction.CallbackContext context)
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

    void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
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

        HandleAnimation();

        HandleCameraDistace();
    }

    void HandleMovement()
    {
        // Handle horizontal movement
        Vector3 movement = Vector3.zero;

        if (characterController.isGrounded)
        {
            movement = (isRunPressed ? currentRunMovement : currentMovement);
            movement = movement.normalized * speed;
            movement = transform.rotation * movement;

        }
        else
        {
            movement = lastFrameMovement;
            movement.y = 0;
        }


        // Handle gravity and jump
        if (characterController.isGrounded)
        {
            if (isJumpPressed)
            {
                isJumping = true;
                currentMovement.y = initialJumpVelocity;
            }
            else
            {
                isJumping = false;
                currentMovement.y = groundedGravity; // Minimal downward force to keep grounded
            }
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
        }

        lastFrameMovement = (movement + new Vector3(0, currentMovement.y, 0));

        // Apply final movement
        characterController.Move(lastFrameMovement * Time.deltaTime);

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
        // Layer Mask to ignore only the "Human Layer"
        int layerToIgnore = 1 << 6;
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
