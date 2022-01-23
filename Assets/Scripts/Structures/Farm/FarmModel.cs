using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.ResourcesSystem;

namespace Systems.PlantingSystem
{
    public class FarmModel : BaseModel
    {
        public List<ResourceObject> Container;
        public Plant CurrentPlant;
        public DateTime StartTime;
    }
}