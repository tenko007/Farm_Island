using System;
using System.Collections;
using Foundation.MVC;
using Systems.PlantingSystem;
using UnityEngine;
using Utils;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class BuildingSystem : IBuildingSystem
    {
        public BaseModel CurrentModel { get; private set; }
        public GameObject CurrentGameObject { get; private set; }

        private Map map;
        private Transform groundTransform;

        private Coroutine buildingCoroutine;

        public BuildingSystem(Map map)
        {
            this.map = map;
            groundTransform = map.GroundGameObject.transform;
        }
        public event Action<BaseModel> OnBuildingStart;
        public event Action<GameObject> OnBuildingEnd;
        public event Action<GameObject> OnBuildingCancelled;
        
        public IBuildingSystem SetModelToBuild(BaseModel model)
        {
            this.CurrentModel = model;
            return this;
        }
        
        public GameObject Instantiate(Vector3 position, Vector3 rotation)
        {
            var prefab = CurrentModel.Prefab;
            prefab.GetComponent<BaseView>().Init(CurrentModel);
            CurrentGameObject = GameObject.Instantiate(prefab, position, Quaternion.Euler(rotation));
            CurrentGameObject.transform.SetParent(groundTransform);
            return CurrentGameObject;
        }

        public void StartBuild()
        {
            OnBuildingStart?.Invoke(CurrentModel);
            CurrentGameObject = Instantiate(WorldPoints.GetCameraCenterPositionOnWorldObject(), Vector3.zero);
            buildingCoroutine = Services.GetService<ICoroutinesUpdater>().StartA(BuildProcess());
        }

        public void CancelBuild()
        {
            OnBuildingCancelled?.Invoke(CurrentGameObject);
            StopBuildingProcess(true);
        }

        public void EndBuild()
        {
            OnBuildingEnd?.Invoke(CurrentGameObject);
            StopBuildingProcess();
        }

        private void StopBuildingProcess(bool cancel = false)
        {
            Services.GetService<ICoroutinesUpdater>().Stop(buildingCoroutine);
            
            if (cancel)
                GameObject.Destroy(CurrentGameObject);

            CurrentGameObject = null;
            CurrentModel = null;
            buildingCoroutine = null;
        }

        private IEnumerator BuildProcess()
        {
            for (;;)
            {
                CurrentGameObject.transform.position = 
                    WorldPoints.GetCameraCenterPositionOnLayer(map.GroundLayer);
                yield return null;
            }
        }
    }
} 