using UnityEngine;

namespace Systems.ResourcesSystem
{
    public interface IShopItem
    {
        int Price { get; }
        void Buy(int count);
        bool CanBeBought(); // TODO Do i need it?
    }
}