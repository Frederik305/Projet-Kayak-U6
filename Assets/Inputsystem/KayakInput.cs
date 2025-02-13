//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputsystem/KayakInput.inputactions
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

public partial class @KayakInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KayakInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KayakInput"",
    ""maps"": [
        {
            ""name"": ""InGameControl"",
            ""id"": ""ed62c00e-783d-4e87-8a84-ee47f4b82da1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aa89e4ee-ea44-45b6-b0f1-7e2fa6438b08"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""a1a17c34-2ae5-44c3-b704-2482db429b7f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f26d21d5-a7bd-4633-8eec-6a0d772fa81e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bb992c45-1250-4ff9-a7ad-a8dce888268e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""d9a75c17-248e-4ce5-b50a-c0c727292ea4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""bd340745-6816-49e3-b1d0-22b1265f0a8e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""9d0da1bb-45c9-4127-832b-ddcb62751d65"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""8f095fe9-d196-495b-9ea3-f2de300bdc01"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""404c0f5f-66ee-470f-9700-f6083587199d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cc3e36e-3f30-4a70-a9f2-88fe4e8f598e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""f4302035-a8dc-408c-98cf-73cc212e25ac"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""4bbdc1b5-a78a-47f1-b8cb-2e77c2463d6b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef4e96c3-c4d9-48a9-b41d-fdecaa2d3890"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""e8d98154-02ca-4a26-af02-b4e0dd6d56d5"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9e99ad98-36ea-4ddd-a789-a2be78d79169"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65629daf-4d40-4e6b-802e-2e0eaae9bf12"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGameControl
        m_InGameControl = asset.FindActionMap("InGameControl", throwIfNotFound: true);
        m_InGameControl_Move = m_InGameControl.FindAction("Move", throwIfNotFound: true);
        m_InGameControl_Look = m_InGameControl.FindAction("Look", throwIfNotFound: true);
        m_InGameControl_Pause = m_InGameControl.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Resume = m_UI.FindAction("Resume", throwIfNotFound: true);
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Newaction = m_Newactionmap.FindAction("New action", throwIfNotFound: true);
    }

    ~@KayakInput()
    {
        UnityEngine.Debug.Assert(!m_InGameControl.enabled, "This will cause a leak and performance issues, KayakInput.InGameControl.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_UI.enabled, "This will cause a leak and performance issues, KayakInput.UI.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_Newactionmap.enabled, "This will cause a leak and performance issues, KayakInput.Newactionmap.Disable() has not been called.");
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

    // InGameControl
    private readonly InputActionMap m_InGameControl;
    private List<IInGameControlActions> m_InGameControlActionsCallbackInterfaces = new List<IInGameControlActions>();
    private readonly InputAction m_InGameControl_Move;
    private readonly InputAction m_InGameControl_Look;
    private readonly InputAction m_InGameControl_Pause;
    public struct InGameControlActions
    {
        private @KayakInput m_Wrapper;
        public InGameControlActions(@KayakInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InGameControl_Move;
        public InputAction @Look => m_Wrapper.m_InGameControl_Look;
        public InputAction @Pause => m_Wrapper.m_InGameControl_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGameControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameControlActions set) { return set.Get(); }
        public void AddCallbacks(IInGameControlActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameControlActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IInGameControlActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IInGameControlActions instance)
        {
            if (m_Wrapper.m_InGameControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameControlActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameControlActions @InGameControl => new InGameControlActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Resume;
    public struct UIActions
    {
        private @KayakInput m_Wrapper;
        public UIActions(@KayakInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Resume => m_Wrapper.m_UI_Resume;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Resume.started += instance.OnResume;
            @Resume.performed += instance.OnResume;
            @Resume.canceled += instance.OnResume;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Resume.started -= instance.OnResume;
            @Resume.performed -= instance.OnResume;
            @Resume.canceled -= instance.OnResume;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private List<INewactionmapActions> m_NewactionmapActionsCallbackInterfaces = new List<INewactionmapActions>();
    private readonly InputAction m_Newactionmap_Newaction;
    public struct NewactionmapActions
    {
        private @KayakInput m_Wrapper;
        public NewactionmapActions(@KayakInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void AddCallbacks(INewactionmapActions instance)
        {
            if (instance == null || m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(INewactionmapActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INewactionmapActions instance)
        {
            foreach (var item in m_Wrapper.m_NewactionmapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface IInGameControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnResume(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
