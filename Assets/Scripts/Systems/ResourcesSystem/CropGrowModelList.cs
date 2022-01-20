using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    [Serializable]
    public class CropGrowModelList 
    {
        public List<GameObject> modelsByGrowLevel;
        
        public GameObject this[int index] => modelsByGrowLevel[index];
    }
}