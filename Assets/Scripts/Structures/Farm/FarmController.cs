using System;
using ExperienceSystem;
using Foundation.MVC;
using Systems.InventorySystem;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils.Services;

namespace Systems.PlantingSystem
{
    public class FarmController : BaseContoller
    {
        public FarmModel Model => (FarmModel) model;
        public void Plant(Seed seed, DateTime startTime)
        {
            Model.CurrentPlant = seed.resultPlant;
            Model.StartTime = startTime;
        }

        private void OnClickAction()
        {
            if (CanBeCollected())
                Collect();
        }

        public bool CanBeCollected() => true; // TODO

        public void Collect()
        {
            var resultRO = Model.CurrentPlant.PlantResult;
            Services.GetService<IPlayerResourceInventory>().Add(resultRO.Resource, resultRO.Count);
        }
    }
}