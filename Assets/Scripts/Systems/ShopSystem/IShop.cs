using System.Collections.Generic;

namespace Systems.ResourcesSystem
{
    public interface IShop<T> where T : IShopItem
    {
        List<T> Items { get; }
        void Buy(T item, int count);
        bool CanBeBought(T item);
        bool CanBeBought(T item, int count);
    }
}