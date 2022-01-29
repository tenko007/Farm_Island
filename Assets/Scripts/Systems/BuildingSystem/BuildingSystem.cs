using System;
using System.Collections;
using Foundation.MVC;
using Structures;
using Systems.BuildingSystem.States;
using Systems.InventorySystem;
using UnityEngine;
using Utils;
using Utils.Services;
using Utils.UpdateSystem;

namespace Systems.BuildingSystem
{
    public class BuildingSystem : IBuildingSystem, IUpdatable
    {
        public BaseModel CurrentModel { get; private set; }
        public GameObject CurrentGameObject { get; private set; }

        public Map map;
        private Transform groundTransform;

        private IBuildingState state;
        
        public BuildingSystem(Map map)
        {
            this.map = map;
            groundTransform = map.GroundGameObject.transform;
        }
        public event Action<BaseModel> OnBuildingStart;
        public event Action<GameObject> OnBuildingEnd;
        public event Action<GameObject> OnBuildingCancelled;
        
        public IBuildingSystem BuildModel(BaseModel model)
        {
            this.CurrentModel = model;
            CurrentGameObject = Instantiate();
            state = new NewBuildingState(this);
            return this;
        }

        public IBuildingSystem BuildStructureItem(StructureItem structureItem)
        {
            BuildModel(structureItem.Item);
            state = new BuildFromInventoryState(this, structureItem);
            return this;
        }

        public IBuildingSystem MoveObject(GameObject gameObject)
        {
            CurrentGameObject = gameObject;
            CurrentModel = CurrentGameObject.GetComponent<IBaseView>().Model;
            state = new MoveBuildingState(this);
            return this;
        }

        public GameObject Instantiate() => Instantiate(Vector3.zero, Vector3.zero);
        public GameObject Instantiate(Vector3 position, Vector3 rotation)
        {
            var prefab = CurrentModel.Prefab;
            prefab.GetComponent<IBaseView>().Init(CurrentModel);
            CurrentGameObject = GameObject.Instantiate(prefab, position, Quaternion.Euler(rotation));
            CurrentGameObject.transform.SetParent(groundTransform);
            return CurrentGameObject;
        }

        public void StartBuild()
        {
            OnBuildingStart?.Invoke(CurrentModel);
            state.StartBuild();
            Services.GetService<IUpdateSystem>().Add(this);
        }
        
        public void CancelBuild()
        {
            OnBuildingCancelled?.Invoke(CurrentGameObject);
            StopBuildingProcess();
            state.CancelBuild();
        }

        public void EndBuild()
        {
            OnBuildingEnd?.Invoke(CurrentGameObject);
            StopBuildingProcess();
            state.EndBuild();
        }
        
        public void BuildProcess()
        {
            CurrentGameObject.transform.position = 
                WorldPoints.GetCameraCenterPositionOnLayer(map.GroundLayer);
        }
        public void StopBuildingProcess()
        {           
            Services.GetService<IUpdateSystem>().Remove(this);
        }
        
        public void Update()
        {
            BuildProcess();
        }
    }
} 