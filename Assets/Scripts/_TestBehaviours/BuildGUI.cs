using System;
using Foundation.MVC;
using Systems.BuildingSystem;
using UnityEngine;
using Utils.Services;

namespace _TestBehaviors
{
    public class BuildGUI : MonoBehaviour
    {
        [SerializeField] private BaseModel houseModel; 
        [SerializeField] private BaseModel farmModel; 

        private void OnGUI()
        {
            GUILayout.Space(300);

            if (GUILayout.Button("Build House"))
                Build(houseModel);
            if (GUILayout.Button("Build Farm"))
                Build(farmModel);
        }

        private void Build(BaseModel model)
        {
            Services.GetService<IBuildingSystem>().SetStructureToBuild(model).StartBuild();
        }

        private void OldBuild(BaseModel model)
        {
            var buildingSystem = Services.GetService<IBuildingSystem>();
            buildingSystem.SetStructureToBuild(model);
            buildingSystem.StartBuild();
        }
    }
}