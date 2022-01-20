using System.Collections.Generic;
using Systems.ResourcesSystem;

namespace Systems.PlantingSystem
{
    public interface ICollectable
    {
        public bool CanBeCollected();
        public void Collect();
        public List<ResourceObject> Container { get; }
    }
}