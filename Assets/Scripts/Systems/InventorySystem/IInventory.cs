using Systems.ResourcesSystem;

namespace Systems.InventorySystem
{
    public interface IInventory<TItem, TCount>
    {
        public bool Add(TItem item, TCount count);
        public bool Remove(TItem item, TCount count);
        public bool Contains(TItem item);
        public bool Contains(TItem item, TCount count);
    }
}