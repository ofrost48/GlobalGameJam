//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/OlliesInputs/Inputs.inputactions
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

public partial class @Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""MapAction"",
            ""id"": ""b47c42c7-9e7b-4e65-84f9-2b738c2828f4"",
            ""actions"": [
                {
                    ""name"": ""OpenMap"",
                    ""type"": ""Button"",
                    ""id"": ""02958dbf-d2da-4a15-a600-493e0fdc714f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CloseMap"",
                    ""type"": ""Button"",
                    ""id"": ""fe97cc14-4402-4381-b1da-be229b8ede0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2451078-12b3-4e9f-86c4-bb247bf1e474"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c32a151-bf07-48c9-bf2c-9e06459e00da"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MapAction
        m_MapAction = asset.FindActionMap("MapAction", throwIfNotFound: true);
        m_MapAction_OpenMap = m_MapAction.FindAction("OpenMap", throwIfNotFound: true);
        m_MapAction_CloseMap = m_MapAction.FindAction("CloseMap", throwIfNotFound: true);
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

    // MapAction
    private readonly InputActionMap m_MapAction;
    private List<IMapActionActions> m_MapActionActionsCallbackInterfaces = new List<IMapActionActions>();
    private readonly InputAction m_MapAction_OpenMap;
    private readonly InputAction m_MapAction_CloseMap;
    public struct MapActionActions
    {
        private @Inputs m_Wrapper;
        public MapActionActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenMap => m_Wrapper.m_MapAction_OpenMap;
        public InputAction @CloseMap => m_Wrapper.m_MapAction_CloseMap;
        public InputActionMap Get() { return m_Wrapper.m_MapAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActionActions set) { return set.Get(); }
        public void AddCallbacks(IMapActionActions instance)
        {
            if (instance == null || m_Wrapper.m_MapActionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MapActionActionsCallbackInterfaces.Add(instance);
            @OpenMap.started += instance.OnOpenMap;
            @OpenMap.performed += instance.OnOpenMap;
            @OpenMap.canceled += instance.OnOpenMap;
            @CloseMap.started += instance.OnCloseMap;
            @CloseMap.performed += instance.OnCloseMap;
            @CloseMap.canceled += instance.OnCloseMap;
        }

        private void UnregisterCallbacks(IMapActionActions instance)
        {
            @OpenMap.started -= instance.OnOpenMap;
            @OpenMap.performed -= instance.OnOpenMap;
            @OpenMap.canceled -= instance.OnOpenMap;
            @CloseMap.started -= instance.OnCloseMap;
            @CloseMap.performed -= instance.OnCloseMap;
            @CloseMap.canceled -= instance.OnCloseMap;
        }

        public void RemoveCallbacks(IMapActionActions instance)
        {
            if (m_Wrapper.m_MapActionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMapActionActions instance)
        {
            foreach (var item in m_Wrapper.m_MapActionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MapActionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MapActionActions @MapAction => new MapActionActions(this);
    public interface IMapActionActions
    {
        void OnOpenMap(InputAction.CallbackContext context);
        void OnCloseMap(InputAction.CallbackContext context);
    }
}
