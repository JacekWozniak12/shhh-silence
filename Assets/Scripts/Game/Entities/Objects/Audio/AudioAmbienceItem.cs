using System;
using System.Collections;
using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioAmbienceItem : AudioBase
    {
        public AudioAmbience Ambience
        {
            get => ambience;
            private set => ambience = value;
        }

        [SerializeField]
        private AudioAmbience ambience;

        public bool ForceCurrentAmbience = false;

        protected override void CustomStart()
        {
            if (gameObject.GetComponent<Collider>() == null)
            {
                BoxCollider collider = gameObject.AddComponent<BoxCollider>();
                collider.size = Vector3.one * 0.00001f;
            }

            if (gameObject.GetComponent<Rigidbody>() == null)
            {
                Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;
            }

            if(Ambience == null) Ambience = AudioManager.Instance.DefaultAmbience;
        }

        public void SetAudioAmbience(AudioAmbience ambience)
        {
            if(ForceCurrentAmbience) return;

            try
            {
                Ambience = ambience;
                audioSource.outputAudioMixerGroup = Ambience.Group;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e);
                Debug.LogWarning(this.gameObject);
            }
        }
    }
}

