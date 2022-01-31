using System;
using ExperienceSystem;
using ExperienceSystem.UI;
using Foundation.MVC;
using Systems.BuildingSystem;
using Systems.ResourcesSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils.Services;

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

        [Header("Canvases")]
        [SerializeField] private GameObject MainCanvas;
        [SerializeField] private GameObject NotificationsCanvas;
        [SerializeField] private GameObject PopupsCanvas;

        [Header("Buttons")] 
        [SerializeField] private GameObject BuildButton;
        private void Start()
        {
            Services.GetService<IBuildingSystem>().OnBuildingStart +=
                _ => Instantiate(buildingActions.gameObject, PopupsCanvas.transform);
            
            BuildButton.GetComponent<Button>().onClick.AddListener(()
                => Instantiate(StructureShopWindow, PopupsCanvas.transform));
            
            Utils.EventSystem.Events.Subscribe<PlayerGotNewLevelEvent>(eventData 
                => Instantiate(LevelupPopupPrefab.gameObject, PopupsCanvas.transform)
                    .GetComponent<LevelupPopup>().SetLevel(eventData.NewLevel));
        }

    }
}