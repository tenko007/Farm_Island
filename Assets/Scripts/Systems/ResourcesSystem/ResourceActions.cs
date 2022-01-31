using Systems.InventorySystem;
using Utils.EventSystem;
using Utils.Services;

namespace Systems.ResourcesSystem
{
    public class ResourceActions : IResourceActions
    {
        public void Add(Resource resource, int count)
        {
            Services.GetService<IPlayerResourceInventory>().Add(resource, count);
        }

        public void Remove(Resource resource, int count)
        {
            Services.GetService<IPlayerResourceInventory>().Remove(resource, count);
        }

        public void Buy(Resource resource, int count, int price)
        {
            Remove(Services.GetService<IResourceList>().Coin, CalcTotalPrice(count, price));
            Add(resource, count);
            
            Events.Invoke(new ResourceBoughtEvent(new ResourceObject(resource,count), CalcTotalPrice(count,price)));
        }

        public void Sell(Resource resource, int count, int price)
        {
            Remove(resource, count);
            Add(Services.GetService<IResourceList>().Coin, CalcTotalPrice(count, price));
            
            Events.Invoke(new ResourceSoldEvent(new ResourceObject(resource,count), CalcTotalPrice(count,price)));
        }

        public int GetCount(Resource resource)
        {
            Services.GetService<IPlayerResourceInventory>().Items.TryGetValue(resource, out int count);
            return count;
        }

        public bool Contains(Resource resource)
        {
            return Services.GetService<IPlayerResourceInventory>().Items.ContainsKey(resource);
        }

        private int CalcTotalPrice(int count, int price)
        {
            return price * count; // may be there will be a discounts
        }
    }
}