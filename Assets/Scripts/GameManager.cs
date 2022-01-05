using System;
using InputSystem;
using PlayerMovementSystem;
using SceneStateSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement PlayerMovement;
    public SceneStateManager SceneStateManager;
    public IInputSystem InputSystem;

    private void Awake()
    {
        Instance = this;
        SetInputSestem();
    }

    private void SetInputSestem()
    {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
        InputSystem = new MobileTouchInput();
#else
        InputSystem = new DesktopTouchInput();
#endif
    }
}