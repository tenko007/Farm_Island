using Foundation.MVC;
using InputSystem;
using UnityEngine;
using Utils.Services;

namespace Systems.BuildingSystem
{
    public class BuildingSystem : IBuildingSystem
    {
        public BaseModel CurrentStructure { get; private set; }
        private IInputSystem _inputSystem;

        
        public IBuildingSystem SetStructureToBuild(BaseModel structure)
        {
            this.CurrentStructure = structure;
            _inputSystem = Services.GetService<IInputSystem>();
            return this;
        }

        public void StartBuild()
        {

        }

        public void Build(Vector3 position, Vector3 rotation)
        {
            var prefab = CurrentStructure.Prefab;
            GameObject.Instantiate(prefab, position, Quaternion.Euler(rotation));
        }

        public void EndBuild()
        {
            
        }
        
        
    }
}