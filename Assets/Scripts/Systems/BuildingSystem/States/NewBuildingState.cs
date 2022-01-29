using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Utils.Services;

namespace Systems.BuildingSystem.States
{
    public class NewBuildingState : IBuildingState
    {
        private readonly BuildingSystem _buildingSystem;
        private Coroutine buildingCoroutine;

        public NewBuildingState(BuildingSystem buildingSystem)
        {
            this._buildingSystem = buildingSystem;
        }
        public void StartBuild()
        {
            buildingCoroutine = Services.GetService<ICoroutinesUpdater>().StartA(_buildingSystem.BuildProcess());
        }

        public void EndBuild()
        {
            StopBuildingProcess();
            // TODO: Remove Structure's price from Player Inventory
        }

        public void CancelBuild()
        {
            StopBuildingProcess();
            GameObject.Destroy(_buildingSystem.CurrentGameObject);
        }
        
        public void StopBuildingProcess()
        {            
            Services.GetService<ICoroutinesUpdater>().Stop(buildingCoroutine);
        }
    }
}