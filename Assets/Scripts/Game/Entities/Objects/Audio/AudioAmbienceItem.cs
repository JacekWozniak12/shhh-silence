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
        public AudioAmbience Ambience { get; private set; }

        protected override void CustomStart()
        {
            Ambience = AudioManager.Instance.DefaultAmbience;
        }

        public void SetAudioAmbience(AudioAmbience ambience)
        {
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

