using ExperienceSystem;
using InputSystem;
using CameraMovementSystem;
using Systems.AudioSystem;
using Systems.BuildingSystem;
using Systems.InventorySystem;
using UnityEngine;
using Utils;
using Utils.EventSystem;
using Utils.Services;

public class GameBootstrap : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ExperienceForLevels experienceForLevels;
    [SerializeField] private CameraMovementSettings cameraMovementSettings;
    
    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundsData soundsData;
    
    private IInputSystem inputSystem;
    private IPlayerExperience playerExperience;

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
    }

    private void RegisterServices()
    {
        Services.RegisterService<IInputSystem>(inputSystem);
        Services.RegisterService<ICameraMovement>(new CameraMovement(Camera.main, cameraMovementSettings));
        Services.RegisterService<IPlayerExperience>(playerExperience);
        Services.RegisterService<ISoundSystem>(new SoundSystem(audioSource, soundsData));
        Services.RegisterService<IExperienceAwarder>(new ExperienceAwarder(playerExperience));
        Services.RegisterService<IPlayerResourceInventory>(new PlayerResourceInventory());
        Services.RegisterService<IBuildingSystem>(new BuildingSystem());
    }
    
    private void SetupUtils()
    {
        WorldPoints.SetInputSystem(inputSystem);
        WorldPoints.SetCamera(Camera.main);
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