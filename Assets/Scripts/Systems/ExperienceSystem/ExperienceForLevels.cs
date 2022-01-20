using System.Collections.Generic;
using UnityEngine;

namespace ExperienceSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Settings/ExperienceForLevels")]
    public class ExperienceForLevels : ScriptableObject
    {
        [SerializeField] private List<int> list;
        public List<int> List => list;
    }
}