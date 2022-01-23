using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourcesData/Plant")]
    public class Plant : ScriptableObject
    {
        public ResourceObject PlantResult;
        public int TimeToGrow;
        public CropGrowModelList Props;
    }
}