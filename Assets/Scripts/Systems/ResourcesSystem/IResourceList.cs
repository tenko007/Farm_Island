using System.Collections.Generic;

namespace Systems.ResourcesSystem
{
    public interface IResourceList
    {
        public List<Resource> Resources { get; }
        public Resource Coin { get; }
        public Resource Gem { get; }
    }
}