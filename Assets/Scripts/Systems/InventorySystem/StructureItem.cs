using Structures;
using UnityEngine;

namespace Systems.InventorySystem
{
    public class StructureItem : IItem
    {
        private IStructure _structure;
        public int Count { get; }

        public string Name => _structure.Name;
        public string Description => _structure.Description;
        public Sprite Icon => _structure.Icon;
        public object Item => _structure;
        
        public StructureItem(IStructure structure, int count)
        {
            this._structure = structure;
            this.Count = count;
        }
    }
}