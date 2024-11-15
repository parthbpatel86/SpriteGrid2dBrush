//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputs/ColorCellControls.inputactions
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

public partial class @ColorCellControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ColorCellControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ColorCellControls"",
    ""maps"": [
        {
            ""name"": ""TouchCell"",
            ""id"": ""7975ea99-444e-430a-ac1c-fb63e0c55165"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""4661e183-2e4a-4387-b956-2af5d4268bdf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""032fb98c-1bfc-4d0e-a472-4abdba9d504d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4194217b-7329-4384-8db5-7a11ca4e7372"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39c7a168-8b17-40de-be4a-539d9321e41a"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchCell
        m_TouchCell = asset.FindActionMap("TouchCell", throwIfNotFound: true);
        m_TouchCell_TouchPosition = m_TouchCell.FindAction("TouchPosition", throwIfNotFound: true);
        m_TouchCell_TouchPress = m_TouchCell.FindAction("TouchPress", throwIfNotFound: true);
    }

    ~@ColorCellControls()
    {
        UnityEngine.Debug.Assert(!m_TouchCell.enabled, "This will cause a leak and performance issues, ColorCellControls.TouchCell.Disable() has not been called.");
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

    // TouchCell
    private readonly InputActionMap m_TouchCell;
    private List<ITouchCellActions> m_TouchCellActionsCallbackInterfaces = new List<ITouchCellActions>();
    private readonly InputAction m_TouchCell_TouchPosition;
    private readonly InputAction m_TouchCell_TouchPress;
    public struct TouchCellActions
    {
        private @ColorCellControls m_Wrapper;
        public TouchCellActions(@ColorCellControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_TouchCell_TouchPosition;
        public InputAction @TouchPress => m_Wrapper.m_TouchCell_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_TouchCell; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchCellActions set) { return set.Get(); }
        public void AddCallbacks(ITouchCellActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchCellActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchCellActionsCallbackInterfaces.Add(instance);
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
            @TouchPress.started += instance.OnTouchPress;
            @TouchPress.performed += instance.OnTouchPress;
            @TouchPress.canceled += instance.OnTouchPress;
        }

        private void UnregisterCallbacks(ITouchCellActions instance)
        {
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
            @TouchPress.started -= instance.OnTouchPress;
            @TouchPress.performed -= instance.OnTouchPress;
            @TouchPress.canceled -= instance.OnTouchPress;
        }

        public void RemoveCallbacks(ITouchCellActions instance)
        {
            if (m_Wrapper.m_TouchCellActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchCellActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchCellActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchCellActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchCellActions @TouchCell => new TouchCellActions(this);
    public interface ITouchCellActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
