using Structures;
using UnityEngine;

namespace Foundation.MVC
{
    public abstract class BuildingModel : BaseModel, IStructure
    {
        [SerializeField] private string name;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
        public string Name => name;
        public string Description => description;
        public Sprite Icon => icon;
    }
}