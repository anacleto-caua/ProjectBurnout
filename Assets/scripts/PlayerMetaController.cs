using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMetaController : MonoBehaviour
{
    PlayerInput playerInput;

    bool isHuman = true;

    [SerializeField]
    GameObject Human;
    HumanPlayerMovement humanPlayerMovement;
    [SerializeField]
    GameObject humanCamera;

    [SerializeField]
    GameObject Ghost;
    GhostPlayerMovement ghostPlayerMovement;
    [SerializeField]
    GameObject ghostCamera;

    bool isTutorialOnScreen = true;

    [SerializeField]
    Canvas tut;


    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        humanPlayerMovement = Human.GetComponent<HumanPlayerMovement>();
        ghostPlayerMovement = Ghost.GetComponent<GhostPlayerMovement>();
       
        humanPlayerMovement.playerInput = playerInput;
        ghostPlayerMovement.playerInput = playerInput;


        isHuman = true;

        humanCamera.SetActive(true);
        playerInput.HumanControls.Enable();

        ghostCamera.SetActive(false);
        playerInput.GhostControls.Disable();

        #region InputSetup
        playerInput.GameConfig.SwitchChar.started += OnSwitchChar;
        #endregion InputSetups
        
        LockCursor();

    }

    #region InputCallbacks
    void OnSwitchChar(InputAction.CallbackContext context)
    {
        isHuman = !isHuman;

        if (isHuman) {
            humanCamera.SetActive(true);
            playerInput.HumanControls.Enable();

            ghostCamera.SetActive(false);
            playerInput.GhostControls.Disable();

        }
        else
        {
            humanCamera.SetActive(false);
            playerInput.HumanControls.Disable();

            ghostCamera.SetActive(true);
            playerInput.GhostControls.Enable();
        }
    }

    #endregion InputCallbacks

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isTutorialOnScreen)
            {
                isTutorialOnScreen = false;
                Destroy(tut);
            }
        }


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
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
    #endregion EnableAndDisablePlayerInput

}
