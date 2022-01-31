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
        [SerializeField] private StructureModel structure;
        [SerializeField] private int price;
        [SerializeField] private int minLevelToBuy;

        public StructureModel Structure => structure;
        public int Price => price;
        public int MinLevelToBuy => minLevelToBuy;
        public Sprite Icon => structure.Icon;
        public string Name => structure.name;

        public void Buy(int count)
        {
            Services.GetService<IBuildingSystem>().BuildModel(Structure).StartBuild();
        }

        public bool CanBeBought()
        {
            // TODO
            return true;
        }

    }
}