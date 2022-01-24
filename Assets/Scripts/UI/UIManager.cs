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
        [Header("Main UI")] 
        [SerializeField] private Button buildButton;

        [SerializeField] private UIBuildingActions buildingActions;
        [SerializeField] private ResourceGainerModel model; //TODO delete

        [Header("Canvases")]
        [SerializeField] private GameObject PopupsCanvas;
        private void Start()
        {
            /*
            BuildButton.onClick.AddListener(() =>
            {
                var system = Services.GetService<IBuildingSystem>();
                system.SetStructureToBuild(_model);
                system.Build(Vector3.zero, Vector3.zero);
                
                Services.GetService<IBuildingSystem>().SetStructureToBuild(_model).Build(Vector3.zero, Vector3.zero);
            });
            */

            buildButton.onClick.AddListener(() =>
                Services.GetService<IBuildingSystem>().SetStructureToBuild(model).StartBuild());

            Services.GetService<IBuildingSystem>().OnBuildingStart +=
                _ => Instantiate(buildingActions.gameObject, PopupsCanvas.transform);
        }

    }
}