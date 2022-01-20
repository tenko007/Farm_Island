using System;
using Foundation.MVC;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public class ResourceGainerController : BaseContoller<ResourceGainerModel>
    {
        public int CollectResource(DateTime currentTime)
        {
            Debug.Log("Give me your money!");
            
            int coinsCount = GetResourceCount(currentTime);
            if (coinsCount > 0)
            {
                model.LastUsedTime = currentTime;
                //Services.GetService<IPlayerInventory>().Add(new ResourceObject()); // TODO uncomment where IPlayerInventory will be allowed
                Debug.Log($"Add Coins! {coinsCount.ToString()} pcs.");
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