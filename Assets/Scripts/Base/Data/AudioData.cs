using ShhhSilence.Base.Interfaces;
using ShhhSilence.Library.HelperL;
using UnityEngine;

namespace ShhhSilence.Base.Data
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "ShhhSilence/AudioData", order = 0)]
    public class AudioData : ScriptableObject, IAudioDeliver
    {
        public AudioClip[] clips;
        public FloatMinMax volume;
        public FloatMinMax pitch;

        public void GetSound(out AudioClip clip, out float volume, out float pitch)
        {
            clip = clips[Random.Range(0, clips.Length)];
            volume = Random.Range(this.volume.min, this.volume.max);
            pitch = Random.Range(this.pitch.min, this.pitch.max);
        }
    }
}