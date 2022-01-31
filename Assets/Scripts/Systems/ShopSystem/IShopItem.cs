using UnityEngine;

namespace Systems.ResourcesSystem
{
    public interface IShopItem
    {
        void Buy(int count);
        bool CanBeBought(); // TODO Do i need it?
    }
}