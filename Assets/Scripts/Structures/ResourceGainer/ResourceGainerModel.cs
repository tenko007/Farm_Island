using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.ResourcesSystem;
using UnityEngine;

namespace Systems.BuildingSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/ResourceGainer")]
    public class ResourceGainerModel : Structure
    {
        [SerializeField] private int level = 1;
        [SerializeField] private Resource gainingResource;
        [SerializeField] private GameObject collectNotificationPrefab;
        [SerializeField] private List<LevelData> _levelDatas;
        public DateTime LastUsedTime = DateTime.Now;

        public int Level => level;
        public float ResourcePerSecond => _levelDatas[level - 1].resourcePerSecond;
        public int MinQtyToCollect => _levelDatas[level - 1].minQtyToCollect;
        public int MaxQtyToCollect => _levelDatas[level - 1].maxQtyToCollect;
        public override GameObject Prefab => _levelDatas[level - 1].prefab;
        public Resource GainingResource => gainingResource;
        public GameObject CollectNotificationPrefab => collectNotificationPrefab;

        
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