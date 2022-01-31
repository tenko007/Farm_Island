using System;
using System.Collections.Generic;
using Foundation.MVC;
using Systems.BuildingSystem;
using Systems.ResourcesSystem;
using UnityEngine;

namespace Structures.ResourceGainerFluent
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/ResourceGainerFluent")]
    public class ResourceGainerFluentModel : BuildingModel
    {
        [SerializeField] private  GameObject prefab;
        public override GameObject Prefab => prefab;
        
        [SerializeField] private int level = 1;
        [SerializeField] private Resource gainingResource;
        [SerializeField] private GameObject collectNotificationPrefab;
        [SerializeField] private float resourcePerSecond;
        [SerializeField] private int minQtyToCollect;
        [SerializeField] private int maxQtyToCollect;
        public DateTime LastUsedTime = DateTime.Now;

        public int Level => level;
        public float ResourcePerSecond => resourcePerSecond;
        public int MinQtyToCollect => minQtyToCollect;
        public int MaxQtyToCollect => maxQtyToCollect;
        public Resource GainingResource => gainingResource;
        public GameObject CollectNotificationPrefab => collectNotificationPrefab;
    }
}