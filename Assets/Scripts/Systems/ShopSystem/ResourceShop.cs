using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Shop/ResourceShop")]
    public class ResourceShop : ScriptableObject, IShop<ResourceShopItem>
    {
        [SerializeField] private List<ResourceShopItem> items;
        public List<ResourceShopItem> Items => items;
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