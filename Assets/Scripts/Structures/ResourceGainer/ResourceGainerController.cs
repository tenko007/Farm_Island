using System;
using Foundation.MVC;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class ResourceGainerController : BaseContoller
    {
        protected ResourceGainerModel Model => (ResourceGainerModel)model;

        public int CollectResource(DateTime currentTime)
        {
            Debug.Log("Give me your stuff!");
            
            int coinsCount = GetResourceCount(currentTime);
            if (coinsCount > 0)
            {
                Model.LastUsedTime = currentTime;
                Services.GetService<IPlayerResourceInventory>().Add(Model.GainingResource, GetResourceCount(currentTime));
                Debug.Log($"{coinsCount.ToString()} pcs. of {Model.GainingResource.Name} added to PlayerResourceInventory!");
            }
            return coinsCount;
        }

        public int GetResourceCount(DateTime currentTime)
        {
            float secondsSpent = (currentTime - Model.LastUsedTime).Seconds;
            int resourceCount = (int) (secondsSpent * Model.ResourcePerSecond);
            
            if (resourceCount > Model.MaxQtyToCollect)
                resourceCount = Model.MaxQtyToCollect;
            if (resourceCount < Model.MinQtyToCollect)
                resourceCount = 0;

            return resourceCount;
        }

    }
}