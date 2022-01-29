﻿using System;
using Foundation.MVC;
using Systems.InventorySystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class ResourceGainerController : StructureController
    {
        protected ResourceGainerModel Model => (ResourceGainerModel)model;

        public int CollectResource(DateTime currentTime)
        {
            Debug.Log("Give me your stuff!");
            
            int coinsCount = GetResourceCount(currentTime);
            if (coinsCount > 0)
            {
                Model.LastUsedTime = currentTime;
                Services.GetService<IPlayerResourceInventory>().Add(Model.GainingResource, coinsCount);
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

        public bool CanBeCollected(DateTime currentTime)
        {
            return GetResourceCount(currentTime) >= Model.MinQtyToCollect;
        }
        public bool CanBeCollected()
        {
            return CanBeCollected(DateTime.Now);
        }

        public void ShowCollectNotification()
        {
            Debug.Log("YOU NOW CAN COLLECT!!!");
        }
    }
  
}