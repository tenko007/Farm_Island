using System;
using UnityEditor;
using UnityEngine;

namespace Systems.AudioSystem
{
    [Serializable]
    public class AudioClipData
    {
        public AudioClip AudioClip;
        [Range(0,1)]
        public float Volume;
    }
}