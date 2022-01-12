using System;
using InputSystem;
using PlayerMovementSystem;
using SceneStateSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement PlayerMovement;
    public InputStateManager inputStateManager;
    public IInputSystem InputSystem;

    private void Awake()
    {
        Instance = this;
        SetInputSystem();
    }

    private void SetInputSystem()
    {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
        InputSystem = new MobileTouchInput();
#else
        InputSystem = new DesktopInput();
#endif
    }
}