using System;
using InputStateSystem;
using InputSystem;
using PlayerMovementSystem;
using UnityEngine;
using Utils;
using Utils.Services;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private InputStateManager inputStateManager;
    private IInputSystem inputSystem;

    private void Awake()
    {
        ChooseInputSystem();
        RegisterServices();
        SetupUtils();
    }
    
    private void ChooseInputSystem()
    {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
        InputSystem = new MobileTouchInput();
#else
        inputSystem = new DesktopInput();
#endif
    }
    
    private void RegisterServices()
    {
        ServiceLocator.RegisterService<IInputSystem>(inputSystem);
        ServiceLocator.RegisterService<IPlayerMovement>(playerMovement);
        ServiceLocator.RegisterService<InputStateManager>(inputStateManager);
    }
    
    private void SetupUtils()
    {
        WorldPoints.SetInputSystem(inputSystem);
    }
}