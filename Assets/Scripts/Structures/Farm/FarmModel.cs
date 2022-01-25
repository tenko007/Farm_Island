using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.ResourcesSystem;
using UnityEngine;

namespace Systems.PlantingSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/Farm")]
    public class FarmModel : BaseModel
    {
        public List<ResourceObject> Container;
        public Plant CurrentPlant;
        public DateTime StartTime;
    }
}