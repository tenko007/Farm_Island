using ExperienceSystem.Events;
using UnityEngine;
using Utils.EventSystem;

namespace ExperienceSystem.UI
{
    public class PlayerExperienceAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip newLevelSound;
        [SerializeField] private AudioClip addExpSound;

        [SerializeField] private AudioSource newLevelSource;
        [SerializeField] private AudioSource addExpSource;
        private void Start()
        {
            EventSystem.Subscribe<PlayerGotExperienceEvent>(PlayAddExpSound);
            EventSystem.Subscribe<PlayerGotNewLevelEvent>(PlayNewLevelSound);
        }
        
        private void PlayAddExpSound(PlayerGotExperienceEvent eventData)
        {
            if (!addExpSource.isPlaying)
            {
                addExpSource.clip = addExpSound;
                addExpSource.Play();
            }
        }
        private void PlayNewLevelSound(PlayerGotNewLevelEvent eventData)
        {
            if (!newLevelSource.isPlaying)
            {
                newLevelSource.clip = newLevelSound;
                newLevelSource.Play();
            }
        }
    }
}