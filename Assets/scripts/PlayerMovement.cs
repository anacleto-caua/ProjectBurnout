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

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
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
    public float rotationDegrees = 180;
    float runMultiplier = 2.0f;
    float gravity = -9.81f;
    float groundedGravity = -0.05f;

    float airResistance = -0.5f;
    float aproximationCorrection = 0.01f;

    float maxJumpTime = 1f;
    float initialJumpVelocity;
    float maxJumpHeight = 3f;
    bool isJumping = false;

    float mouseRotation = 0f;
    float mouseSensibility = 100f;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();

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

        LockCursor();
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

        //HandleRotation();
        //HandleAnimation();

        HandleCursorLocking();
    }

    void HandleMovement()
    {
        // Handle horizontal movement
        Vector3 movement = Vector3.zero;

        if (characterController.isGrounded)
        {
            movement = (isRunPressed ? currentRunMovement : currentMovement) * speed;
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

        //if (lastFrameMovement.x > 0)
        //{
        //    lastFrameMovement.x += airResistance;
        //}
        //else if (lastFrameMovement.x < 0)
        //{
        //    lastFrameMovement.x -= airResistance;
        //}

        //if (lastFrameMovement.x < aproximationCorrection && lastFrameMovement.x)
        //{
        //    lastFrameMovement.x = 0;
        //}

        lastFrameMovement = (movement + new Vector3(0, currentMovement.y, 0));

        // Apply final movement
        characterController.Move(lastFrameMovement * Time.deltaTime);

    }

    void HandleCursorLocking()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
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

    void HandleRotation()
    {
        if (isDirectionPressed)
        {
            Vector3 currentRot = characterController.transform.eulerAngles;
            Vector3 targetRot = new Vector3(currentRot.x, currentRot.y + (currentDirectionMovement * 45), currentRot.z);

            float step = rotationDegrees * Time.deltaTime * (isRunPressed ? 1.5f : 1f);
            float yRot = Mathf.MoveTowardsAngle(currentRot.y, targetRot.y, step);

            characterController.transform.eulerAngles = new Vector3(currentRot.x, yRot, currentRot.z);
        }

    }

    void HandleJump()
    {
        if (isJumpPressed && characterController.isGrounded && !isJumping)
        {
            Debug.Log("pulo2");

            isJumping = true;
            currentMovement.y = initialJumpVelocity * .5f;
            currentRunMovement.y = initialJumpVelocity * .5f;

            characterController.Move(transform.up * 5f);
        }
        else if (!isJumpPressed && characterController.isGrounded && isJumping)
        {
            Debug.Log("pulo3");

            isJumping = false;
        }
    }

    void HandleGravity()
    {
        if (!characterController.isGrounded)
        {
            float previousYVelocity = characterController.transform.position.y;
            float newYVelocity = characterController.transform.position.y + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .2f;

            //Debug.Log("Dir: " + -characterController.transform.up * nextYVelocity);

            characterController.Move(-characterController.transform.up * nextYVelocity);
        }
        else
        {
            //Debug.Log("DirG: " + characterController.transform.up * groundedGravity);
            characterController.Move(characterController.transform.up * groundedGravity);
        }
    }

    void OnDrawGizmos()
    {

    }

    #region EnableAndDisablePlayerInput
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnEnable()
    {
        playerInput.HumanControls.Enable();
    }

    void OnDisable()
    {
        playerInput.HumanControls.Disable();
    }
    #endregion EnableAndDisablePlayerInput

}
