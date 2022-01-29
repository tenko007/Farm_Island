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

        public NewBuildingState(BuildingSystem buildingSystem)
        {
            this._buildingSystem = buildingSystem;
        }
        public void StartBuild()
        {
        }

        public void EndBuild()
        {
            // TODO: Remove Structure's price from Player Inventory
        }

        public void CancelBuild()
        {
            GameObject.Destroy(_buildingSystem.CurrentGameObject);
        }
    }
}