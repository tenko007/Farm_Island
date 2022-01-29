using Systems.ResourcesSystem;
using UnityEngine;

namespace Systems.InventorySystem
{
    public class ResourceItem : IItem<Resource>
    {
        private Resource _resource;
        public int Count { get; }

        public string Name => _resource.Name;
        public string Description => _resource.Description;
        public Sprite Icon => _resource.Icon;
        public Resource Item => _resource;

        public ResourceItem(Resource resource, int count)
        {
            this._resource = resource;
            this.Count = count;
        }
    }
}