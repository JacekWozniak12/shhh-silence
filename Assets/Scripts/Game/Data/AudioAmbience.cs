using UnityEngine;
using UnityEngine.Audio;

namespace ShhhSilence.Game.Data
{
    [CreateAssetMenu(fileName = "AudioAmbience", menuName = "ShhhSilence/AudioAmbience", order = 0)]
    public class AudioAmbience : ScriptableObject
    {
        public string Name = "Default";
        public AudioMixerGroup Group;
    }
}

