using System.Collections.Generic;
using UnityEngine;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourcesData/AllResourcesList")]
    public class ResourceList : ScriptableObject, IResourceList 
    {
        [SerializeField] private List<Resource> resources;
        [SerializeField] private  Resource coin;
        [SerializeField] private  Resource gem;
        
        public List<Resource> Resources => resources;
        public Resource Coin => coin;
        public Resource Gem => gem;
    }
}