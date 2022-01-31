using System;
using Foundation.MVC;
using Systems.BuildingSystem;
using UnityEngine;
using Utils.EventSystem;
using Utils.Services;

namespace Systems.ResourcesSystem
{
    [Serializable]
    public class StructureShopItem : IShopItem
    {
        [SerializeField] private BuildingModel building;
        [SerializeField] private int price;
        [SerializeField] private int minLevelToBuy;

        public BuildingModel Building => building;
        public int Price => price;
        public int MinLevelToBuy => minLevelToBuy;
        public Sprite Icon => building.Icon;
        public string Name => building.name;

        public void Buy(int count)
        {
            Services.GetService<IBuildingSystem>().BuildModel(Building).StartBuild();
        }

        public bool CanBeBought()
        {
            // TODO
            return true;
        }

    }
}