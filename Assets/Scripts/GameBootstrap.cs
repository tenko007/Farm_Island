using ExperienceSystem;
using InputSystem;
using CameraMovementSystem;
using Systems.AudioSystem;
using Systems.BuildingSystem;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils;
using Utils.EventSystem;
using Utils.Services;
using Utils.UpdateSystem;

public class GameBootstrap : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ExperienceForLevels experienceForLevels;
    [SerializeField] private CameraMovementSettings cameraMovementSettings;
    
    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundsData soundsData;

    [Header("GameObjects")] 
    [SerializeField] private Map map;

    [Header("Data")] 
    [SerializeField] private ResourceList ResourcesList;
    
    private IInputSystem inputSystem;
    private IPlayerExperience playerExperience;

    private void Awake()
    {
        Services.SetServiceLocator(new ServiceLocator());
        Events.SetEventAggregator(new EventAggregator());
        ResourceManager.SetResourceActions(new ResourceActions());

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
        Services.RegisterService<IBuildingSystem>(new BuildingSystem(map));
        Services.RegisterService<IUpdateSystem>(Instantiate(new GameObject().AddComponent<UpdateSystem>(), this.transform));
        Services.RegisterService<IResourceList>(ResourcesList);
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