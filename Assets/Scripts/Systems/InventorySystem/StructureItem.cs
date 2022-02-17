using Foundation.MVC;
using UnityEngine;

namespace Systems.InventorySystem
{
    public class StructureItem : IItem<BuildingModel>
    {
        private readonly BuildingModel _buildingModel;
        public int Count { get; }
        public string Name => _buildingModel.Name;
        public string Description => _buildingModel.Description;
        public Sprite Icon => _buildingModel.Icon;
        public BuildingModel Item => _buildingModel;
        public GameObject Prefab => _buildingModel.Prefab;
        
        public StructureItem(BuildingModel buildingModel, int count)
        {
            this._buildingModel = buildingModel;
            this.Count = count;
        }
    }
}