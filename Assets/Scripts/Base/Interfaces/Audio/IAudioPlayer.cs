using ShhhSilence.Base.Data;

namespace ShhhSilence.Base.Interfaces
{
    public interface IAudioPlayer
    {
        void Play();
        void SetAudio(AudioData data);
        void Play(AudioData data);
        void Stop();
        void Pause(float time);
        void Pause();
        void Resume();
    }
}