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
        private bool mute = true;

        public bool Mute
        {
            get => mute;
            set
            {
                mute = value;
                MuteMixers(mute);
            }
        }

        private void OnValidate()
        {
            MuteMixers(mute);
        }

        private void Start()
        {
            MuteMixers(mute);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                mute = !mute;
            }
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