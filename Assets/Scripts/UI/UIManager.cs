using System;
using Foundation.MVC;
using Systems.BuildingSystem;
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
            BuildButton.GetComponent<Button>().onClick.AddListener(() => Services.GetService<IBuildingSystem>()
                .SetModelToBuild(houseModel).StartBuild());
        }

    }
}