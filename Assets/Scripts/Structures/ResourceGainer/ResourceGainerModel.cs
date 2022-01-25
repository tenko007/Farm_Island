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
        [SerializeField] private int level = 1;
        public int Level => level;
        [SerializeField] private Resource gainingResource;
        public Resource GainingResource => gainingResource;
        private DateTime lastUseTime = DateTime.Now;
        
        [SerializeField] private List<LevelData> _levelDatas;

        public float ResourcePerSecond => _levelDatas[level - 1].resourcePerSecond;
        public int MinQtyToCollect => _levelDatas[level - 1].minQtyToCollect;
        public int MaxQtyToCollect => _levelDatas[level - 1].maxQtyToCollect;
        public override GameObject Prefab => _levelDatas[level - 1].prefab;

        public DateTime LastUsedTime
        {
            get => lastUseTime;
            set => lastUseTime = value;
        }
        
        [Serializable]
        public class LevelData
        {
            public GameObject prefab;
            public float resourcePerSecond;
            public int minQtyToCollect;
            public int maxQtyToCollect;
        }
    }

}