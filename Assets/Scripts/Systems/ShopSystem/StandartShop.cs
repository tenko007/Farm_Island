using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    public abstract class StandartShop<T> : ScriptableObject, IShop<T>
        where T : IShopItem
    {
        [SerializeField] private List<T> items;
        public List<T> Items => items;
        public void Buy(T item, int count)
        {
            item.Buy(count);
        }

        public bool CanBeBought(T item)
        {
            int playerCoins = 10000;
                //Services.GetService<IPlayerResourceInventory>().Contains(); // TODO
                
            return item.CanBeBought() && item.Price <= playerCoins;
        }

        public bool CanBeBought(T item, int count)
        {
            int playerCoins = 10000;
                //Services.GetService<IPlayerResourceInventory>().Contains(); // TODO
                
            return item.CanBeBought() && item.Price * count <= playerCoins;
        }
    }
}