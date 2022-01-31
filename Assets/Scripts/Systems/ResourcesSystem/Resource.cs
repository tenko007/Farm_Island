using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourcesData/Resource")]
    public class Resource : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        public int basePurchasePrice;
        public int baseSellPrice;
    }
}