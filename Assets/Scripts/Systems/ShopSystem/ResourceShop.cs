using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Shop/ResourceShop")]
    public class ResourceShop : ScriptableObject, IShop<ResourceShopItem>
    {
        public List<ResourceShopItem> Items { get; }
        public void Buy(ResourceShopItem item, int count)
        {
            item.Buy(count);
        }

        public bool CanBeBought(ResourceShopItem item, int count)
        {
            throw new NotImplementedException();
        }
    }
}