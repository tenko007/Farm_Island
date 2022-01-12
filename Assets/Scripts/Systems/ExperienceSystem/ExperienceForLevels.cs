using System.Collections.Generic;
using UnityEngine;

namespace ExperienceSystem.Events
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ExperienceForLevels")]
    public class ExperienceForLevels : ScriptableObject
    {
        [SerializeField] private List<int> list;
        public List<int> List => list;
    }
}