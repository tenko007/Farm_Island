using Foundation.MVC;
using Structures;
using UnityEngine;

namespace Systems.InventorySystem
{
    public class StructureItem : IItem<StructureModel>
    {
        private StructureModel _structureModel;
        public int Count { get; }

        public string Name => _structureModel.Name;
        public string Description => _structureModel.Description;
        public Sprite Icon => _structureModel.Icon;
        public StructureModel Item => _structureModel;
        public GameObject Prefab => _structureModel.Prefab;
        
        public StructureItem(StructureModel structureModel, int count)
        {
            this._structureModel = structureModel;
            this.Count = count;
        }
    }
}