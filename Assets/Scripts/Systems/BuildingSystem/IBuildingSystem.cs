using Foundation.MVC;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public interface IBuildingSystem : IService
    {
        public BaseModel CurrentStructure { get; }

        public void SetStructureToBuild(BaseModel structure)
        {
            
        }

        public void StartBuild()
        {
            
        }

        public void EndBuild()
        {
            
        }        
    }
}