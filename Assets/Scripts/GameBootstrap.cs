using ExperienceSystem;
using InputStateSystem;
using InputSystem;
using CameraMovementSystem;
using UnityEngine;
using Utils;
using Utils.EventSystem;
using Utils.Services;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private InputStateManager inputStateManager;
    [SerializeField] private ExperienceForLevels experienceForLevels;
    [SerializeField] private CameraMovementSetup cameraMovementSetup;
    
    private IInputSystem inputSystem;
    private IPlayerExperience playerExperience;
    private IExperienceAwarder experienceAwarder;

    private void Awake()
    {
        Services.SetServiceLocator(new ServiceLocator());
        Events.SetEventAggregator(new EventAggregator());

        SetupVariables();
        RegisterServices();
        SetupUtils();
    }

    private void SetupVariables()
    {
        ChooseInputSystem();
        playerExperience = new PlayerExperience(1,0,experienceForLevels); // TODO Load level from somewhere
        experienceAwarder = new ExperienceAwarder(playerExperience);
    }

    private void RegisterServices()
    {
        Services.RegisterService<IInputSystem>(inputSystem);
        Services.RegisterService<ICameraMovement>(new CameraMovement(Camera.main, cameraMovementSetup));
        Services.RegisterService<InputStateManager>(inputStateManager);
        Services.RegisterService<IPlayerExperience>(playerExperience);
    }
    
    private void SetupUtils()
    {
        WorldPoints.SetInputSystem(inputSystem);
    }
        
    private void ChooseInputSystem()
    {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
        InputSystem = new MobileTouchInput();
#else
        inputSystem = new DesktopInput();
#endif
    }

}