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

        public void GetSound(
            out AudioClip clip,
            out float volume,
            out float pitch)
        {
            clip = clips[Random.Range(0, clips.Length)];
            volume = Random.Range(this.volume.min, this.volume.max);
            pitch = Random.Range(this.pitch.min, this.pitch.max);
        }

        public void GetSound(
            int index,
            float volumeIn,
            float pitchIn,
            out AudioClip clipOut,
            out float volumeOut,
            out float pitchOut)
        {
            clipOut = clips[Mathf.Clamp(index, 0, clips.Length)];
            volumeOut = Mathf.Clamp(volumeIn, this.volume.min, this.volume.max);
            pitchOut = Mathf.Clamp(pitchIn, this.pitch.min, this.pitch.max);
        }
    }
}