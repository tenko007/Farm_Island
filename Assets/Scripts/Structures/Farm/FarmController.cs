using System;
using ExperienceSystem;
using Foundation.MVC;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils.Services;

namespace Systems.PlantingSystem
{
    public class FarmController : BaseContoller<FarmModel>
    {
        private new FarmModel model;

        public void Plant(Seed seed, DateTime startTime)
        {
            model.CurrentPlant = seed.resultPlant;
            model.StartTime = startTime;
        }

        private void OnClickAction()
        {
            if (CanBeCollected())
                Collect();
        }

        public bool CanBeCollected() => true; // TODO

        public void Collect()
        {
            var resultRO = model.CurrentPlant.PlantResult;
            Services.GetService<IPlayerResourceInventory>().Add(resultRO.Resource, resultRO.Count);
        }
    }
}