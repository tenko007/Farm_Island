using System;
using Foundation.MVC;
using Systems.InventorySystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public interface IBuildingSystem : IService
    {
        public BaseModel CurrentModel { get; }
        public event Action<BaseModel> OnBuildingStart;
        public event Action<GameObject> OnBuildingEnd;
        public event Action<GameObject> OnBuildingCancelled;


        public IBuildingSystem BuildModel(BaseModel model);
        public IBuildingSystem BuildStructureItem(StructureItem structureItem);
        public IBuildingSystem MoveObject(GameObject gameObject);

        public void StartBuild();
        public void EndBuild();
        public void CancelBuild();
        public GameObject Instantiate(Vector3 position, Vector3 rotation);
    }
}