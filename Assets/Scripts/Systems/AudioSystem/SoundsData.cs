using UnityEngine;

namespace Systems.AudioSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Audio/SoundsData")]
    public class SoundsData : ScriptableObject
    {
        public AudioClipData newLevel;
        public AudioClipData addExperience;
        
    }
}