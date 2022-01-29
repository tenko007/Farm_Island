using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.ResourcesSystem;
using UnityEngine;

namespace Systems.PlantingSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/Farm")]
    public class FarmModel : Structure
    {
        public List<ResourceObject> Container;
        [HideInInspector] public Plant CurrentPlant;
        [HideInInspector] public DateTime StartTime = DateTime.Now;
        public override GameObject Prefab { get; }
    }
}