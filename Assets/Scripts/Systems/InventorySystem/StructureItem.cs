using Foundation.MVC;
using Structures;
using UnityEngine;

namespace Systems.InventorySystem
{
    public class StructureItem : IItem<Structure>
    {
        private Structure _structure;
        public int Count { get; }

        public string Name => _structure.Name;
        public string Description => _structure.Description;
        public Sprite Icon => _structure.Icon;
        public Structure Item => _structure;
        public GameObject Prefab => _structure.Prefab;
        
        public StructureItem(Structure structure, int count)
        {
            this._structure = structure;
            this.Count = count;
        }
    }
}