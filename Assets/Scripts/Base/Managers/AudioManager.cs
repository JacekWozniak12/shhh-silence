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
        private List<AudioMixer> audioMixers;

        public List<AudioMixer> AudioMixers
        {
            get { return audioMixers; }
            set { audioMixers = value; }
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

        public void MuteToggle()
        {
            muted = !muted;
            MuteRequest(muted);
        }

        private void MuteMixers(bool isTrue)
        {
            if (isTrue)
            {
                foreach (AudioMixer mixer in audioMixers)
                {
                    mixer.SetFloat("MasterVolume", -80);
                }
            }
            else
            {
                foreach (AudioMixer mixer in audioMixers)
                {
                    mixer.SetFloat("MasterVolume", 0);
                }
            }
        }
    }
}