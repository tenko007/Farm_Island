using Systems.InventorySystem;
using UnityEngine;
using Utils.Services;
using Utils.UpdateSystem;

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
        }

        public void EndBuild()
        {
            // TODO: Delete from PlayerStructuresInventory;
        }

        public void CancelBuild()
        {
            GameObject.Destroy(_buildingSystem.CurrentGameObject);
        }
    }
}