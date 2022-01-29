using UnityEngine;

namespace Systems.BuildingSystem.States
{
    public interface IBuildingState
    {
        public void StartBuild();
        public void EndBuild();
        public void CancelBuild();
    }
}