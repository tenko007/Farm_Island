using ExperienceSystem;
using ExperienceSystem.UI;
using Foundation.MVC;
using Systems.BuildingSystem;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils.Services;
using Utils.EventSystem;

namespace UI
{
    public class UIManager : MonoBehaviour, IUIManager 
    {
        [Header("Temp prefabs")]
        [SerializeField] private BaseModel houseModel;
        
        [Header("Main UI")] 

        [Header("Popups")]
        [SerializeField] private UIBuildingActions buildingActions;
        [SerializeField] private LevelupPopup LevelupPopupPrefab;
        [SerializeField] private StructureShopView StructureShopWindow;
        [SerializeField] private ResourceShopView ResourceShopWindow;
        [SerializeField] private PlayerResourceInventoryView PlayerInventoryWindow;

        [Header("Canvases")]
        [SerializeField] private GameObject MainCanvas;
        [SerializeField] private GameObject NotificationsCanvas;
        [SerializeField] private GameObject PopupsCanvas;

        [Header("Buttons")] 
        [SerializeField] private GameObject BuildButton;
        [SerializeField] private GameObject InventoryButton;
        [SerializeField] private GameObject ShopButton;
        [SerializeField] private GameObject SearchButton;
        private void Start()
        {
            Services.GetService<IBuildingSystem>().OnBuildingStart +=
                _ => Instantiate(buildingActions.gameObject, PopupsCanvas.transform);
            
            Events.Subscribe<PlayerGotNewLevelEvent>(eventData 
                => Instantiate(LevelupPopupPrefab.gameObject, PopupsCanvas.transform)
                    .GetComponent<LevelupPopup>().SetLevel(eventData.NewLevel));
            
            SubscribeButtons();
        }

        private void SubscribeButtons()
        {
            BuildButton.GetComponent<Button>().onClick.AddListener(()
                => Instantiate(StructureShopWindow, PopupsCanvas.transform));
            
            InventoryButton.GetComponent<Button>().onClick.AddListener(()
                => Instantiate(PlayerInventoryWindow, PopupsCanvas.transform));
            
            ShopButton.GetComponent<Button>().onClick.AddListener(()
                => Instantiate(ResourceShopWindow, PopupsCanvas.transform));
            
            //SearchButton.GetComponent<Button>().onClick.AddListener(()
            //    => Instantiate(StructureShopWindow, PopupsCanvas.transform));
        }

    }
}