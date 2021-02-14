using System.Collections;
using ShhhSilence.Base.Data;
using ShhhSilence.Base.Interfaces;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    public class AudioBase : MonoBehaviour, IAudioPlayer
    {
        protected AudioSource audioSource;

        public void Pause() => audioSource.Pause();
        public void Play() => audioSource.Play();
        public void Resume() => audioSource.UnPause();
        public void Stop() => audioSource.Stop();

        private void Awake()
        {
            GetAudioSource();
        }

        private void Start()
        {
            CustomStart();
        }

        protected virtual void GetAudioSource()
        {
            audioSource = audioSource ?? GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
        }

        protected virtual void CustomStart() { }

        /// <summary>
        /// Sets and plays audio data one time.
        /// </summary>
        /// <param name="data">Data passed to AudioBase</param>
        public void Play(AudioData data)
        {
            SetAudio(data);
            audioSource.PlayOneShot(audioSource.clip);
        }

        public void SetAudio(AudioData data)
        {
            data.GetSound(out AudioClip clip, out float volume, out float pitch);
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.clip = clip;
        }

        /// <summary>
        /// Pauses audio and after certain amount of time
        /// resumes playing.
        /// </summary>
        /// <param name="time">In seconds</param>
        public void Pause(float time)
        {
            audioSource.Stop();
            StartCoroutine(ResumeAfterTime(time));
        }

        private IEnumerator ResumeAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            if (this.gameObject != null) Resume();
        }
    }
}


