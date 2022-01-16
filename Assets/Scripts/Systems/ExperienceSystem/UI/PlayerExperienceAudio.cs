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
            Events.Subscribe<PlayerGotExperienceEvent>(PlayAddExpSound);
            Events.Subscribe<PlayerGotNewLevelEvent>(PlayNewLevelSound);
        }
        
        private void PlayAddExpSound(PlayerGotExperienceEvent eventData)
        {
            addExpSource.clip = addExpSound;
            addExpSource.Play();
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