//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/Settings/PlayerInput.inputactions
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
            ""name"": ""MainMap"",
            ""id"": ""3d2e5ce8-aa31-433a-86ea-4a9bdc61d820"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""806d4a42-f21d-4acf-bf36-feed751e458b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45a8e1fa-ddab-484f-b455-d49635a004cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMap
        m_MainMap = asset.FindActionMap("MainMap", throwIfNotFound: true);
        m_MainMap_MouseClick = m_MainMap.FindAction("MouseClick", throwIfNotFound: true);
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

    // MainMap
    private readonly InputActionMap m_MainMap;
    private List<IMainMapActions> m_MainMapActionsCallbackInterfaces = new List<IMainMapActions>();
    private readonly InputAction m_MainMap_MouseClick;
    public struct MainMapActions
    {
        private @PlayerInput m_Wrapper;
        public MainMapActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_MainMap_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_MainMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMapActions set) { return set.Get(); }
        public void AddCallbacks(IMainMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MainMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainMapActionsCallbackInterfaces.Add(instance);
            @MouseClick.started += instance.OnMouseClick;
            @MouseClick.performed += instance.OnMouseClick;
            @MouseClick.canceled += instance.OnMouseClick;
        }

        private void UnregisterCallbacks(IMainMapActions instance)
        {
            @MouseClick.started -= instance.OnMouseClick;
            @MouseClick.performed -= instance.OnMouseClick;
            @MouseClick.canceled -= instance.OnMouseClick;
        }

        public void RemoveCallbacks(IMainMapActions instance)
        {
            if (m_Wrapper.m_MainMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MainMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainMapActions @MainMap => new MainMapActions(this);
    public interface IMainMapActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
}