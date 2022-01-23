using Foundation.MVC;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public interface IBuildingSystem : IService
    {
        public BaseModel CurrentStructure { get; }

        public IBuildingSystem SetStructureToBuild(BaseModel structure)
        {
            return this;
        }

        public void StartBuild()
        {
            
        }

        public void EndBuild()
        {
            
        }

        public void Build(Vector3 position, Vector3 rotation)
        {
            
        }
    }
}