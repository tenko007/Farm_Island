using UnityEngine;

namespace Systems.InventorySystem
{
    public interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        //public int Count { get; }
        public Sprite Icon { get; }
        public object Item { get; }
    }
}