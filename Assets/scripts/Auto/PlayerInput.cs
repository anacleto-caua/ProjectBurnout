//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""HumanControls"",
            ""id"": ""51d42fce-affd-4951-b61d-66445670e2b7"",
            ""actions"": [
                {
                    ""name"": ""MovementDirection"",
                    ""type"": ""Value"",
                    ""id"": ""e7a39665-d4d2-4d28-b9f2-92fea307c57c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""8bbb4681-25cf-4c3e-a15e-85ec353d57cb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d11d8681-685d-435e-bbbd-ba492332ac09"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""af3a1632-4dc1-4f35-bdeb-3894e5490f63"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f9b4a06-17c6-4dc4-a54f-aea0b0ce575b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0dc9d683-f81e-4083-b3ba-6422005acde9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f7f40b5c-23ac-4528-958e-4cbea468988a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ab1528c0-6fbe-4ec9-ad1b-473ef2d0ceba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2dcd40a3-07fd-4e69-97e6-c82e511ccc2c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e1740d1f-03cc-4a33-84a5-e5f44cc3ea6f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8dabe68-f064-4082-9c6e-63bafea347b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cbed8876-d82c-46b0-b1d9-7d019f736b51"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1329de8f-05a7-4245-b905-a7d2930b9546"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f117830-666d-4e44-af43-043b058e24ac"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""09f85891-d1cc-451f-b13b-3c91978f9e15"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""415ff589-b7c8-44cc-876a-fe699a5a2679"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ed2a5fa1-f75b-4644-a6e8-a72e3eb31bb8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fe2f77a2-43d7-49ea-8f4b-0d7d7d4290d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""df303d3f-4c62-4d63-8f8a-d682caa0679a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""559f5dc4-a486-45b1-91db-ae5eab8c7c77"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""3d5a0473-786c-42e4-b23f-6daff5f11cd6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4330e6a0-79d0-4817-929c-8c3901aa5242"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""db0ba3f8-e48c-43ff-999f-aea6745f4179"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5f366241-5445-4730-9c88-eef43d853b18"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // HumanControls
        m_HumanControls = asset.FindActionMap("HumanControls", throwIfNotFound: true);
        m_HumanControls_MovementDirection = m_HumanControls.FindAction("MovementDirection", throwIfNotFound: true);
        m_HumanControls_Run = m_HumanControls.FindAction("Run", throwIfNotFound: true);
        m_HumanControls_Jump = m_HumanControls.FindAction("Jump", throwIfNotFound: true);
        m_HumanControls_Movement = m_HumanControls.FindAction("Movement", throwIfNotFound: true);
        m_HumanControls_MouseRotation = m_HumanControls.FindAction("MouseRotation", throwIfNotFound: true);
    }

    ~@PlayerInput()
    {
        UnityEngine.Debug.Assert(!m_HumanControls.enabled, "This will cause a leak and performance issues, PlayerInput.HumanControls.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // HumanControls
    private readonly InputActionMap m_HumanControls;
    private List<IHumanControlsActions> m_HumanControlsActionsCallbackInterfaces = new List<IHumanControlsActions>();
    private readonly InputAction m_HumanControls_MovementDirection;
    private readonly InputAction m_HumanControls_Run;
    private readonly InputAction m_HumanControls_Jump;
    private readonly InputAction m_HumanControls_Movement;
    private readonly InputAction m_HumanControls_MouseRotation;
    public struct HumanControlsActions
    {
        private @PlayerInput m_Wrapper;
        public HumanControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementDirection => m_Wrapper.m_HumanControls_MovementDirection;
        public InputAction @Run => m_Wrapper.m_HumanControls_Run;
        public InputAction @Jump => m_Wrapper.m_HumanControls_Jump;
        public InputAction @Movement => m_Wrapper.m_HumanControls_Movement;
        public InputAction @MouseRotation => m_Wrapper.m_HumanControls_MouseRotation;
        public InputActionMap Get() { return m_Wrapper.m_HumanControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanControlsActions set) { return set.Get(); }
        public void AddCallbacks(IHumanControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_HumanControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HumanControlsActionsCallbackInterfaces.Add(instance);
            @MovementDirection.started += instance.OnMovementDirection;
            @MovementDirection.performed += instance.OnMovementDirection;
            @MovementDirection.canceled += instance.OnMovementDirection;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MouseRotation.started += instance.OnMouseRotation;
            @MouseRotation.performed += instance.OnMouseRotation;
            @MouseRotation.canceled += instance.OnMouseRotation;
        }

        private void UnregisterCallbacks(IHumanControlsActions instance)
        {
            @MovementDirection.started -= instance.OnMovementDirection;
            @MovementDirection.performed -= instance.OnMovementDirection;
            @MovementDirection.canceled -= instance.OnMovementDirection;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MouseRotation.started -= instance.OnMouseRotation;
            @MouseRotation.performed -= instance.OnMouseRotation;
            @MouseRotation.canceled -= instance.OnMouseRotation;
        }

        public void RemoveCallbacks(IHumanControlsActions instance)
        {
            if (m_Wrapper.m_HumanControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHumanControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_HumanControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HumanControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HumanControlsActions @HumanControls => new HumanControlsActions(this);
    public interface IHumanControlsActions
    {
        void OnMovementDirection(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseRotation(InputAction.CallbackContext context);
    }
}
