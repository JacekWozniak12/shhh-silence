using System.Collections.Generic;
using ShhhSilence.Game.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace ShhhSilence.Base.Managers
{
    public class AudioManager : BaseManager<AudioManager>
    {
        public AudioAmbience CurrentAmbience;
        public AudioAmbience DefaultAmbience;

        [SerializeField]
        private AudioMixer audioMixer;

        public AudioMixer AudioMixers
        {
            get { return audioMixer; }
            private set { audioMixer = value; }
        }

        [SerializeField]
        private bool muted = true;

        public bool Muted
        {
            get => muted;
            set
            {
                muted = value;
                MuteMixers(muted);
            }
        }

        private void OnValidate()
        {
            MuteMixers(muted);
        }

        private void Start()
        {
            MuteMixers(muted);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                muted = !muted;
            }
        }

        public void MuteRequest(bool isTrue)
        {
            MuteMixers(isTrue);
        }

        public void SetSnapshot(string snapshotName)
        {
            var snapshot = audioMixer.FindSnapshot(snapshotName);
            Debug.Log(snapshot);
            audioMixer.TransitionToSnapshots(
               new AudioMixerSnapshot[] { snapshot }, new float[] { 1f }, 0
            );
        }

        public void MuteToggle()
        {
            muted = !muted;
            MuteRequest(muted);
        }

        private float tempMasterVolume = 0;

        private void MuteMixers(bool isTrue)
        {
            if (isTrue)
            {
                audioMixer.GetFloat("MasterVolume", out float temp);
                if(temp != -80) tempMasterVolume = temp;
                audioMixer.SetFloat("MasterVolume", -80);
            }
            else
            {
                audioMixer.SetFloat("MasterVolume", tempMasterVolume);
            }
        }
    }
}