//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Develop/Chapter 3/Inputs/VisionOSInputs.inputactions
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

public partial class @VisionOSInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @VisionOSInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VisionOSInputs"",
    ""maps"": [
        {
            ""name"": ""WindowedApp"",
            ""id"": ""1f381d9f-833f-4189-b46c-bb577229bdf8"",
            ""actions"": [
                {
                    ""name"": ""TouchTap"",
                    ""type"": ""Button"",
                    ""id"": ""68b7b6a0-4f23-402c-af61-814137b092f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""07b50786-e5d9-4a7d-871f-60ebaab564a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""753057b3-2b8b-4be2-94a5-8960cbc1102c"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""094f80b6-4c59-43b4-9d71-18e6badc7c9f"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // WindowedApp
        m_WindowedApp = asset.FindActionMap("WindowedApp", throwIfNotFound: true);
        m_WindowedApp_TouchTap = m_WindowedApp.FindAction("TouchTap", throwIfNotFound: true);
        m_WindowedApp_TouchPosition = m_WindowedApp.FindAction("TouchPosition", throwIfNotFound: true);
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

    // WindowedApp
    private readonly InputActionMap m_WindowedApp;
    private List<IWindowedAppActions> m_WindowedAppActionsCallbackInterfaces = new List<IWindowedAppActions>();
    private readonly InputAction m_WindowedApp_TouchTap;
    private readonly InputAction m_WindowedApp_TouchPosition;
    public struct WindowedAppActions
    {
        private @VisionOSInputs m_Wrapper;
        public WindowedAppActions(@VisionOSInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchTap => m_Wrapper.m_WindowedApp_TouchTap;
        public InputAction @TouchPosition => m_Wrapper.m_WindowedApp_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_WindowedApp; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WindowedAppActions set) { return set.Get(); }
        public void AddCallbacks(IWindowedAppActions instance)
        {
            if (instance == null || m_Wrapper.m_WindowedAppActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WindowedAppActionsCallbackInterfaces.Add(instance);
            @TouchTap.started += instance.OnTouchTap;
            @TouchTap.performed += instance.OnTouchTap;
            @TouchTap.canceled += instance.OnTouchTap;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(IWindowedAppActions instance)
        {
            @TouchTap.started -= instance.OnTouchTap;
            @TouchTap.performed -= instance.OnTouchTap;
            @TouchTap.canceled -= instance.OnTouchTap;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(IWindowedAppActions instance)
        {
            if (m_Wrapper.m_WindowedAppActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWindowedAppActions instance)
        {
            foreach (var item in m_Wrapper.m_WindowedAppActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WindowedAppActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WindowedAppActions @WindowedApp => new WindowedAppActions(this);
    public interface IWindowedAppActions
    {
        void OnTouchTap(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
