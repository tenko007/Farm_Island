using System;
using ExperienceSystem;
using UnityEngine;
using Utils.EventSystem;
using Utils.Services;

namespace Systems.ResourcesSystem
{
    [Serializable]
    public class ResourceShopItem : IShopItem
    {
        [SerializeField] private Resource resource;
        [SerializeField] private int price;
        [SerializeField] private int minLevelToBuy;

        public Resource Resource => resource;
        public int Price => price;
        public int MinLevelToBuy => minLevelToBuy;
        public Sprite Icon => resource.Icon;
        public string Name => resource.Name;

        public void Buy(int count)
        {
            Events.Invoke(new ResourceBoughtEvent(new ResourceObject(Resource,count),Price*count));
        }

        public bool CanBeBought()
        {
            return Services.GetService<IPlayerExperience>().Level >= minLevelToBuy;
        }

    }
}