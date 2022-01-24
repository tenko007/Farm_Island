using System;
using Foundation.MVC;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class ResourceGainerController : BaseContoller<ResourceGainerModel>
    {
        public int CollectResource(DateTime currentTime)
        {
            Debug.Log("Give me your stuff!");
            
            int coinsCount = GetResourceCount(currentTime);
            if (coinsCount > 0)
            {
                model.LastUsedTime = currentTime;
                Services.GetService<IPlayerResourceInventory>().Add(model.gainingResource, GetResourceCount(currentTime));
                Debug.Log($"{coinsCount.ToString()} pcs. of {model.gainingResource.Name} added to PlayerResourceInventory!");
            }
            return coinsCount;
        }

        public int GetResourceCount(DateTime currentTime)
        {
            float secondsSpent = (currentTime - model.LastUsedTime).Seconds;
            int resourceCount = (int) (secondsSpent * model.ResourcePerSecond);
            
            if (resourceCount > model.MaxQtyToCollect)
                resourceCount = model.MaxQtyToCollect;
            if (resourceCount < model.MinQtyToCollect)
                resourceCount = 0;

            return resourceCount;
        }

    }
}