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
        List<AudioMixerSnapshot> snapshots = new List<AudioMixerSnapshot>();

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

        public AudioMixerSnapshot AddSnapshot(string snapshotName)
        {
            var snapshot = audioMixer.FindSnapshot(snapshotName);
            return AddSnapshot(snapshot);
        }

        public AudioMixerSnapshot AddSnapshot(AudioMixerSnapshot snapshot)
        {
            if (snapshot == null) return null;
            Debug.Log("SNAPSHOT ADDED:" + snapshot);
            snapshots.Add(snapshot);
            UpdateMixer();
            return snapshot;
        }

        public AudioMixerSnapshot DeleteSnapshot(string snapshotName)
        {
            var snapshot = audioMixer.FindSnapshot(snapshotName);
            return DeleteSnapshot(snapshot);
        }

        public AudioMixerSnapshot DeleteSnapshot(AudioMixerSnapshot snapshot)
        {
            if (snapshot == null) return null;
            Debug.Log("SNAPSHOT DELETE:" + snapshot);
            snapshots?.Remove(snapshot);
            UpdateMixer();
            return snapshot;
        }

        private void UpdateMixer()
        {
            float[] weights = new float[snapshots.Count];

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = (float)1 / (float)weights.Length;
            }

            audioMixer.TransitionToSnapshots(
               snapshots.ToArray(), weights, 0
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
                if (temp != -80) tempMasterVolume = temp;
                audioMixer.SetFloat("MasterVolume", -80);
            }
            else
            {
                audioMixer.SetFloat("MasterVolume", tempMasterVolume);
            }
        }
    }
}