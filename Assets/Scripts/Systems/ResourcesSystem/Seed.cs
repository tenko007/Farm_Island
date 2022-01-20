using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourcesData/Seed")]
    public class Seed : ScriptableObject
    {
        public Resource SeedResource;
        public Plant resultPlant;
    }
}