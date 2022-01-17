using System;
using ExperienceSystem;
using UnityEngine;
using Utils.EventSystem;

namespace Systems.AudioSystem
{
    public class SoundSystem : ISoundSystem
    {
        private readonly AudioSource audioSource;
        private readonly SoundsData data;
        public SoundSystem(AudioSource audioSource, SoundsData data)
        {
            this.audioSource = audioSource;
            this.data = data;
            Start();
        }

        public void Start()
        {
            PlayOnEvent<PlayerGotExperienceEvent>(data.addExperience);
            PlayOnEvent<PlayerGotNewLevelEvent>(data.newLevel);
        }
        
        private void PlayOnEvent<T>(AudioClipData audioClip) where T: EventArgs
        {
            var ds = new SoundPlayer(audioSource, audioClip);
            Events.Subscribe<T>(_ => ds.Play());
        }
    }
}