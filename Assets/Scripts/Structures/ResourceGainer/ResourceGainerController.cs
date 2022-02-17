using System;
using Foundation.MVC;
using Systems.InventorySystem;
using Unity.Mathematics;
using UnityEngine;
using Utils.Services;
using Utils.UpdateSystem;

namespace Systems.BuildingSystem
{
    public class ResourceGainerController : BuildingController, IUpdatable
    {
        public event Action OnCanBeCollected;
        public event Action OnCollected;
        private bool isNotificationShown = false;
        protected ResourceGainerModel Model => (ResourceGainerModel)model;

        public override void Setup(BaseModel model)
        {
            base.Setup(model);
            Services.GetService<IUpdateSystem>().Add(this);
        }
        public override void Dispose()
        {
            Services.GetService<IUpdateSystem>().Remove(this);
        }
        public int CollectResource(DateTime currentTime)
        {
            Debug.Log("Give me your stuff!");
            
            int coinsCount = GetResourceCount(currentTime);
            if (coinsCount > 0)
            {
                Model.LastUsedTime = currentTime;
                Services.GetService<IPlayerResourceInventory>().Add(Model.GainingResource, coinsCount);
                HideCollectNotification();
            }
            return coinsCount;
        }
        public int GetResourceCount(DateTime currentTime)
        {
            float secondsSpent = (currentTime - Model.LastUsedTime).Seconds;
            int resourceCount = (int) (secondsSpent * Model.ResourcePerSecond);

            return math.clamp(resourceCount, Model.MinQtyToCollect, Model.MaxQtyToCollect);
        }
        public bool CanBeCollected(DateTime currentTime) =>
            GetResourceCount(currentTime) >= Model.MinQtyToCollect;
        public bool CanBeCollected() =>
            CanBeCollected(DateTime.Now);
        public void Update()
        {
            if (!isNotificationShown)
                if (CanBeCollected(DateTime.Now))
                    ShowCollectNotification();
        }
        public void ShowCollectNotification()
        {
            if (!isNotificationShown)
            {
                OnCanBeCollected?.Invoke();
                isNotificationShown = true;
            }
        }
        public void HideCollectNotification()
        {
            if (isNotificationShown)
            {
                OnCollected?.Invoke();
                isNotificationShown = false;
            }
        }
    }
}