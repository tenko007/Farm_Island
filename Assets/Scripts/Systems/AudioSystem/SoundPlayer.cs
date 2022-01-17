using UnityEngine;

namespace Systems.AudioSystem
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource source;
        private readonly AudioClipData clipData;
        private float lastPlayTime = float.NegativeInfinity;
        private float delay = .1f;
        
        public SoundPlayer(AudioSource source, AudioClipData clipData)
        {
            this.source = source;
            this.clipData = clipData;
        }
        
        public void Play()
        {
            if (Time.time - lastPlayTime < delay)
                return;
            
            source.volume = clipData.Volume;
            source.PlayOneShot(clipData.AudioClip);

            lastPlayTime = Time.time;
        }
    }
}