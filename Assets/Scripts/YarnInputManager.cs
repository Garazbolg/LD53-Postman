using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class YarnInputManager : MonoBehaviour
{
    public InputActionAsset asset;
    public InputActionAsset UIasset;
    public string PlayerMap;
    public string UIMap;

    private static YarnInputManager instance;

    private void Awake()
    {
        instance = this;
    }

    [YarnCommand("input_player")]
    public static void InputPlayer()
    {
        instance.asset.FindActionMap(instance.PlayerMap).Enable();
        instance.UIasset.FindActionMap(instance.UIMap).Enable();
    }
    
    [YarnCommand("input_ui")]
    public static void InputUI()
    {
        instance.asset.FindActionMap(instance.PlayerMap).Disable();
        instance.UIasset.FindActionMap(instance.UIMap).Enable();
    }
    
    [YarnCommand("input_none")]
    public static void InputNone()
    {
        instance.asset.FindActionMap(instance.PlayerMap).Disable();
        instance.UIasset.FindActionMap(instance.UIMap).Disable();
    }
}