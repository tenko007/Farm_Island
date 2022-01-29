using Systems.InventorySystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem.States
{
    public class BuildFromInventoryState : IBuildingState
    {
        private readonly BuildingSystem _buildingSystem;
        private Coroutine buildingCoroutine;
        private StructureItem _structureItem;
        
        public BuildFromInventoryState(BuildingSystem buildingSystem, StructureItem structureItem)
        {
            this._buildingSystem = buildingSystem;
            this._structureItem = structureItem;
        }

        public void StartBuild()
        {
            buildingCoroutine = Services.GetService<ICoroutinesUpdater>().StartA(_buildingSystem.BuildProcess());
        }

        public void EndBuild()
        {
            StopBuildingProcess();
            // TODO: Delete from PlayerStructuresInventory;
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