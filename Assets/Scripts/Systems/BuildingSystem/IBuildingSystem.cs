using System;
using Foundation.MVC;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public interface IBuildingSystem : IService
    {
        public BaseModel CurrentModel { get; }
        public event Action<BaseModel> OnBuildingStart;
        public event Action<GameObject> OnBuildingEnd;

        public IBuildingSystem SetStructureToBuild(BaseModel model) => this;

        public void StartBuild();
        public void EndBuild();
        public void CancelBuild();
        public GameObject Instantiate(Vector3 position, Vector3 rotation);
    }
}