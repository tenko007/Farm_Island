using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.ResourcesSystem;
using UnityEngine;

namespace Systems.BuildingSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/ResourceGainer")]
    public class ResourceGainerModel : BaseModel
    {
        [SerializeField] public int level;
        public Resource gainingResource;
        private DateTime lastUseTime;
        
        [SerializeField] private List<ResourceGainerLevelData> _levelDatas;

        public float ResourcePerSecond => _levelDatas[level - 1].resourcePerSecond;

        public DateTime LastUsedTime
        {
            get => lastUseTime;
            set => lastUseTime = value;
        }
    }
    
    [Serializable]
    public class ResourceGainerLevelData
    {
        public GameObject prefab;
        public float resourcePerSecond;
    }

}