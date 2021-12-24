// GENERATED AUTOMATICALLY FROM 'Assets/_Project/Scripts/new Input System/MinionControll.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MinionControll : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MinionControll()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MinionControll"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""c95178a2-440c-424d-892f-fedafe28b7a2"",
            ""actions"": [
                {
                    ""name"": ""Meve"",
                    ""type"": ""Button"",
                    ""id"": ""22eb7d2a-d9fb-4330-9c20-1cb25a6318d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18881cd6-ddaf-418b-a7d9-9235e2e5ad8c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Meve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Meve = m_Land.FindAction("Meve", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Meve;
    public struct LandActions
    {
        private @MinionControll m_Wrapper;
        public LandActions(@MinionControll wrapper) { m_Wrapper = wrapper; }
        public InputAction @Meve => m_Wrapper.m_Land_Meve;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Meve.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMeve;
                @Meve.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMeve;
                @Meve.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMeve;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Meve.started += instance.OnMeve;
                @Meve.performed += instance.OnMeve;
                @Meve.canceled += instance.OnMeve;
            }
        }
    }
    public LandActions @Land => new LandActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface ILandActions
    {
        void OnMeve(InputAction.CallbackContext context);
    }
}
