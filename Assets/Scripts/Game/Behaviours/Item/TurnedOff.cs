using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using ShhhSilence.Base.Data;
using System.Collections;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(AudioAmbienceItem))]
    public class TurnedOff : MonoBehaviour
    {
        public bool ModifyVisibility = true;
        public bool State = false;

        private new Renderer renderer;
        private new Collider collider;

        private AudioAmbienceItem ambienceItem;

        private void Start()
        {
            renderer = GetComponent<Renderer>();
            collider = GetComponent<Collider>();
            ambienceItem = GetComponent<AudioAmbienceItem>();
            SetActive(State);
        }

        public void SetActive(bool active)
        {
            if (active)
            {
                if (ModifyVisibility)
                {
                    if(renderer != null) renderer.enabled = true;
                    if(collider != null) collider.enabled = true;
                }
                State = true;
                ambienceItem.Resume();
            }

            else
            {
                if (ModifyVisibility)
                {
                    if(renderer != null) renderer.enabled = false;
                    if(collider != null) collider.enabled = false;
                }
                State = false;
                ambienceItem.Pause();
            }
        }
    }
}