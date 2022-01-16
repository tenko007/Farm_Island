using UnityEngine;

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
            Utils.EventSystem.Events.Subscribe<PlayerGotExperienceEvent>(PlayAddExpSound);
            Utils.EventSystem.Events.Subscribe<PlayerGotNewLevelEvent>(PlayNewLevelSound);
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