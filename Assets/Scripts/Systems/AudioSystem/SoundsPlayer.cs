using ExperienceSystem;
using UnityEngine;
using Utils.EventSystem;

namespace Systems.AudioSystem
{
    public class SoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsData data;
        [SerializeField] private AudioSource audioSource;
        private void Start()
        {
            Events.Subscribe<PlayerGotExperienceEvent>(_ => PlaySound(data.addExperience));
            Events.Subscribe<PlayerGotNewLevelEvent>(_ => PlaySound(data.newLevel));
        }
        
        private void PlaySound(AudioClipData audioClipData)
        {
            audioSource.clip = audioClipData.AudioClip;
            audioSource.volume = audioClipData.Volume;
            audioSource.Play();
        }
    }
}