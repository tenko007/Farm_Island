using Systems.ResourcesSystem;

namespace Systems.InventorySystem
{
    public interface IPlayerInventory
    {
        public void Add(ResourceObject resourceObject);
        public void Remove(ResourceObject resourceObject);
        public bool Contains(Resource resource);
        public bool Contains(ResourceObject resourceObject);
    }
}