using UnityEngine;

namespace Structures
{
    public interface IStructure
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}