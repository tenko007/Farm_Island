using Structures;
using UnityEngine;

namespace Foundation.MVC
{
    public abstract class StructureModel : BaseModel, IStructure
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}