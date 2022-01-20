using Foundation.MVC;
using InputSystem;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class BuildingSystem : IBuildingSystem
    {
        public BaseModel CurrentStructure { get; private set; }
        private IInputSystem _inputSystem;

        
        public void SetStructureToBuild(BaseModel structure)
        {
            this.CurrentStructure = structure;
            _inputSystem = Services.GetService<IInputSystem>();
        }

        public void StartBuild()
        {
            
        }

        public void EndBuild()
        {
            
        }
        
        
    }
}