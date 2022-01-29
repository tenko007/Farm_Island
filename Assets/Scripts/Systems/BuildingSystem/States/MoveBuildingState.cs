using UnityEngine;
using Utils.Services;
using Utils.EventSystem;

namespace Systems.BuildingSystem.States
{
    public class MoveBuildingState : IBuildingState
    {
        private readonly BuildingSystem _buildingSystem;
        private Vector3 prevPosition;
        
        public MoveBuildingState(BuildingSystem buildingSystem)
        {
            this._buildingSystem = buildingSystem;
        }

        public void StartBuild()
        {
            prevPosition = _buildingSystem.CurrentGameObject.transform.position;
        }

        public void EndBuild()
        {
            Events.Invoke<BuildingMoved>(new BuildingMoved(
                _buildingSystem.CurrentGameObject.gameObject, 
                prevPosition, 
                _buildingSystem.CurrentGameObject.transform.position));
        }

        public void CancelBuild()
        {
            _buildingSystem.CurrentGameObject.transform.position = prevPosition;
        }
    }
}