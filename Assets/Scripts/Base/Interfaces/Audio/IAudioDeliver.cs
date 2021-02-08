using UnityEngine;

namespace ShhhSilence.Base.Interfaces
{
    public interface IAudioDeliver
    {
         void GetSound(out AudioClip clip, out float volume, out float pitch);
    }
}