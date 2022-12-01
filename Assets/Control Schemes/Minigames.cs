//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Control Schemes/Minigames.inputactions
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

public partial class @Minigames : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Minigames()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Minigames"",
    ""maps"": [
        {
            ""name"": ""Hotdog"",
            ""id"": ""1d6864ef-e160-4c47-a89f-bfef4d547b72"",
            ""actions"": [
                {
                    ""name"": ""Button1"",
                    ""type"": ""Button"",
                    ""id"": ""a24d0903-5f1b-47d7-8827-750e3253c7c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button2"",
                    ""type"": ""Button"",
                    ""id"": ""443236b2-bfcd-4f02-832a-e36e8fa45b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button3"",
                    ""type"": ""Button"",
                    ""id"": ""57b672dd-f121-460f-9592-d203355eb95c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button4"",
                    ""type"": ""Button"",
                    ""id"": ""008f7b3c-55e0-46bc-9acb-ea055fa87a60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""805e0fb4-8f0b-408a-b2d4-984e1d33daf9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f5affd2-dbef-425e-accf-d9cc42141795"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d37c83d8-5ccb-4d3e-bcb9-9cda1070bcc9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a3827ba-8454-4e78-b0d4-7421776a8953"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86c5986e-a007-43d0-8a6e-9da67cf3aa96"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c73dbd67-e47c-4469-8d25-b32967e9caab"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d504f049-3b6d-4cc6-a467-791b2bb0ea2e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeefa0c4-2def-4a3a-9814-3f18c5e7dc0b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HighNoon"",
            ""id"": ""2c69f885-ec9c-4caa-897e-e45b542c2117"",
            ""actions"": [
                {
                    ""name"": ""Stop"",
                    ""type"": ""Button"",
                    ""id"": ""61399d7a-7595-493f-bfe6-45cc95d33ceb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01c4bb46-f682-45e2-8814-bc368276bb87"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76ca26c0-7206-4c8d-ad41-b9a2abf3605d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21517e93-7d95-4aef-9968-c8ce5ca7981a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ClearSky"",
            ""id"": ""72ca659a-2709-41fc-b588-80da7a60b31c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""91dd7dd2-98b0-4e0a-8718-95dbeee175ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ea66a1e0-7a3d-483a-ab08-66165801ea8a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Button"",
                    ""id"": ""32416362-1a2b-455a-942d-bdf6077e642e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""035c726c-4ad5-4da8-937b-d4bd0bac4494"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""71f45fc5-c8dc-4794-8840-8a09c20f0b16"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8dd0515c-5764-4b6b-b88e-7b00654c2869"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""03dc1877-94d5-40b0-a28f-6818c85859aa"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3fb77d9a-2e3d-4cfa-9b95-c2d68e026cf4"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a6101cd8-0a1d-405c-9d7c-6ef77e396e93"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e28d0d27-a42d-4514-8b8f-758bf30689b4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""26cd7124-8598-4485-b03a-e8ac80efb785"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c260c121-3e80-46a6-b94f-9c30f24932c2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""caee8e23-201b-47be-9d56-895ac2a68f46"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f4c40249-695a-4838-86e4-817e7778a971"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a361a3d8-0cae-431a-9646-32fc23d6b2a6"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""34f0fd30-d403-4a7e-bf65-c7819af556d9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d92c83b-ba0d-4e7b-a216-a3312c456ff3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TelevisionManager"",
            ""id"": ""163017b9-ddf3-4a16-a80e-53528ef1145c"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""72443f74-adc2-4184-970e-d2935b68987a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Continue"",
                    ""type"": ""Button"",
                    ""id"": ""fbab2ab1-97e7-4451-badb-32f70cf41d2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""76afaab7-9bd6-46ee-880f-4d4968073a07"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4629a921-98c6-4a18-9827-4de9f45c077c"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hotdog
        m_Hotdog = asset.FindActionMap("Hotdog", throwIfNotFound: true);
        m_Hotdog_Button1 = m_Hotdog.FindAction("Button1", throwIfNotFound: true);
        m_Hotdog_Button2 = m_Hotdog.FindAction("Button2", throwIfNotFound: true);
        m_Hotdog_Button3 = m_Hotdog.FindAction("Button3", throwIfNotFound: true);
        m_Hotdog_Button4 = m_Hotdog.FindAction("Button4", throwIfNotFound: true);
        // HighNoon
        m_HighNoon = asset.FindActionMap("HighNoon", throwIfNotFound: true);
        m_HighNoon_Stop = m_HighNoon.FindAction("Stop", throwIfNotFound: true);
        // ClearSky
        m_ClearSky = asset.FindActionMap("ClearSky", throwIfNotFound: true);
        m_ClearSky_Move = m_ClearSky.FindAction("Move", throwIfNotFound: true);
        m_ClearSky_Rotate = m_ClearSky.FindAction("Rotate", throwIfNotFound: true);
        m_ClearSky_Zoom = m_ClearSky.FindAction("Zoom", throwIfNotFound: true);
        // TelevisionManager
        m_TelevisionManager = asset.FindActionMap("TelevisionManager", throwIfNotFound: true);
        m_TelevisionManager_Pause = m_TelevisionManager.FindAction("Pause", throwIfNotFound: true);
        m_TelevisionManager_Continue = m_TelevisionManager.FindAction("Continue", throwIfNotFound: true);
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

    // Hotdog
    private readonly InputActionMap m_Hotdog;
    private IHotdogActions m_HotdogActionsCallbackInterface;
    private readonly InputAction m_Hotdog_Button1;
    private readonly InputAction m_Hotdog_Button2;
    private readonly InputAction m_Hotdog_Button3;
    private readonly InputAction m_Hotdog_Button4;
    public struct HotdogActions
    {
        private @Minigames m_Wrapper;
        public HotdogActions(@Minigames wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button1 => m_Wrapper.m_Hotdog_Button1;
        public InputAction @Button2 => m_Wrapper.m_Hotdog_Button2;
        public InputAction @Button3 => m_Wrapper.m_Hotdog_Button3;
        public InputAction @Button4 => m_Wrapper.m_Hotdog_Button4;
        public InputActionMap Get() { return m_Wrapper.m_Hotdog; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HotdogActions set) { return set.Get(); }
        public void SetCallbacks(IHotdogActions instance)
        {
            if (m_Wrapper.m_HotdogActionsCallbackInterface != null)
            {
                @Button1.started -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton1;
                @Button1.performed -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton1;
                @Button1.canceled -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton1;
                @Button2.started -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton2;
                @Button2.performed -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton2;
                @Button2.canceled -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton2;
                @Button3.started -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton3;
                @Button3.performed -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton3;
                @Button3.canceled -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton3;
                @Button4.started -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton4;
                @Button4.performed -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton4;
                @Button4.canceled -= m_Wrapper.m_HotdogActionsCallbackInterface.OnButton4;
            }
            m_Wrapper.m_HotdogActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button1.started += instance.OnButton1;
                @Button1.performed += instance.OnButton1;
                @Button1.canceled += instance.OnButton1;
                @Button2.started += instance.OnButton2;
                @Button2.performed += instance.OnButton2;
                @Button2.canceled += instance.OnButton2;
                @Button3.started += instance.OnButton3;
                @Button3.performed += instance.OnButton3;
                @Button3.canceled += instance.OnButton3;
                @Button4.started += instance.OnButton4;
                @Button4.performed += instance.OnButton4;
                @Button4.canceled += instance.OnButton4;
            }
        }
    }
    public HotdogActions @Hotdog => new HotdogActions(this);

    // HighNoon
    private readonly InputActionMap m_HighNoon;
    private IHighNoonActions m_HighNoonActionsCallbackInterface;
    private readonly InputAction m_HighNoon_Stop;
    public struct HighNoonActions
    {
        private @Minigames m_Wrapper;
        public HighNoonActions(@Minigames wrapper) { m_Wrapper = wrapper; }
        public InputAction @Stop => m_Wrapper.m_HighNoon_Stop;
        public InputActionMap Get() { return m_Wrapper.m_HighNoon; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HighNoonActions set) { return set.Get(); }
        public void SetCallbacks(IHighNoonActions instance)
        {
            if (m_Wrapper.m_HighNoonActionsCallbackInterface != null)
            {
                @Stop.started -= m_Wrapper.m_HighNoonActionsCallbackInterface.OnStop;
                @Stop.performed -= m_Wrapper.m_HighNoonActionsCallbackInterface.OnStop;
                @Stop.canceled -= m_Wrapper.m_HighNoonActionsCallbackInterface.OnStop;
            }
            m_Wrapper.m_HighNoonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Stop.started += instance.OnStop;
                @Stop.performed += instance.OnStop;
                @Stop.canceled += instance.OnStop;
            }
        }
    }
    public HighNoonActions @HighNoon => new HighNoonActions(this);

    // ClearSky
    private readonly InputActionMap m_ClearSky;
    private IClearSkyActions m_ClearSkyActionsCallbackInterface;
    private readonly InputAction m_ClearSky_Move;
    private readonly InputAction m_ClearSky_Rotate;
    private readonly InputAction m_ClearSky_Zoom;
    public struct ClearSkyActions
    {
        private @Minigames m_Wrapper;
        public ClearSkyActions(@Minigames wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ClearSky_Move;
        public InputAction @Rotate => m_Wrapper.m_ClearSky_Rotate;
        public InputAction @Zoom => m_Wrapper.m_ClearSky_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_ClearSky; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClearSkyActions set) { return set.Get(); }
        public void SetCallbacks(IClearSkyActions instance)
        {
            if (m_Wrapper.m_ClearSkyActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnRotate;
                @Zoom.started -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_ClearSkyActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_ClearSkyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public ClearSkyActions @ClearSky => new ClearSkyActions(this);

    // TelevisionManager
    private readonly InputActionMap m_TelevisionManager;
    private ITelevisionManagerActions m_TelevisionManagerActionsCallbackInterface;
    private readonly InputAction m_TelevisionManager_Pause;
    private readonly InputAction m_TelevisionManager_Continue;
    public struct TelevisionManagerActions
    {
        private @Minigames m_Wrapper;
        public TelevisionManagerActions(@Minigames wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_TelevisionManager_Pause;
        public InputAction @Continue => m_Wrapper.m_TelevisionManager_Continue;
        public InputActionMap Get() { return m_Wrapper.m_TelevisionManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TelevisionManagerActions set) { return set.Get(); }
        public void SetCallbacks(ITelevisionManagerActions instance)
        {
            if (m_Wrapper.m_TelevisionManagerActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnPause;
                @Continue.started -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnContinue;
                @Continue.performed -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnContinue;
                @Continue.canceled -= m_Wrapper.m_TelevisionManagerActionsCallbackInterface.OnContinue;
            }
            m_Wrapper.m_TelevisionManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Continue.started += instance.OnContinue;
                @Continue.performed += instance.OnContinue;
                @Continue.canceled += instance.OnContinue;
            }
        }
    }
    public TelevisionManagerActions @TelevisionManager => new TelevisionManagerActions(this);
    public interface IHotdogActions
    {
        void OnButton1(InputAction.CallbackContext context);
        void OnButton2(InputAction.CallbackContext context);
        void OnButton3(InputAction.CallbackContext context);
        void OnButton4(InputAction.CallbackContext context);
    }
    public interface IHighNoonActions
    {
        void OnStop(InputAction.CallbackContext context);
    }
    public interface IClearSkyActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface ITelevisionManagerActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnContinue(InputAction.CallbackContext context);
    }
}
