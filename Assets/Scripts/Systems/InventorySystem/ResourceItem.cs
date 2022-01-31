using Systems.ResourcesSystem;
using UnityEngine;
using UnityEngine.SearchService;
using Utils.Services;

namespace Systems.InventorySystem
{
    public class ResourceItem : IItem<Resource>
    {
        private Resource resource;
        public int Count { get; }
        public string Name => resource.Name;
        public string Description => resource.Description;
        public Sprite Icon => resource.Icon;
        public Resource Item => resource;

        public ResourceItem(Resource resource, int count)
        {
            this.resource = resource;
            this.Count = count;
        }
    }
}