using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem.States
{
    public class MoveBuildingState : IBuildingState
    {
        private readonly BuildingSystem _buildingSystem;
        private Coroutine buildingCoroutine;
        private Vector3 prevPosition;
        
        public MoveBuildingState(BuildingSystem buildingSystem)
        {
            this._buildingSystem = buildingSystem;
        }

        public void StartBuild()
        {
            prevPosition = _buildingSystem.CurrentGameObject.transform.position;
            buildingCoroutine = Services.GetService<ICoroutinesUpdater>().StartA(_buildingSystem.BuildProcess());
        }

        public void EndBuild()
        {
            StopBuildingProcess();
            // TODO Event - Building was moved
        }

        public void CancelBuild()
        {
            StopBuildingProcess();
            _buildingSystem.CurrentGameObject.transform.position = prevPosition;
        }
        
        public void StopBuildingProcess()
        {            
            Services.GetService<ICoroutinesUpdater>().Stop(buildingCoroutine);
        }
    }
}