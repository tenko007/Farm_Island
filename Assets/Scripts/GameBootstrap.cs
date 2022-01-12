using ExperienceSystem;
using ExperienceSystem.Events;
using InputStateSystem;
using InputSystem;
using PlayerMovementSystem;
using UnityEngine;
using Utils;
using Utils.EventSystem;
using Utils.Services;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private InputStateManager inputStateManager;
    [SerializeField] private ExperienceForLevels experienceForLevels;
    
    private IInputSystem inputSystem;
    private IPlayerExperience playerExperience;
    private IExperienceAwarder experienceAwarder;

    private void Awake()
    {
        Services.SetServiceLocator(new ServiceLocator());
        EventSystem.SetEventAggregator(new EventAggregator());

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
        Services.RegisterService<IPlayerMovement>(playerMovement);
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