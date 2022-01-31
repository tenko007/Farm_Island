using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Shop/StructureShop")]
    public class StructureShop : ScriptableObject, IShop<StructureShopItem>
    {
        [SerializeField] private List<StructureShopItem> items;
        public List<StructureShopItem> Items => items;
        public void Buy(StructureShopItem item, int count)
        {
            item.Buy(count);
        }

        public bool CanBeBought(StructureShopItem item, int count)
        {
            throw new NotImplementedException();
        }
    }
}