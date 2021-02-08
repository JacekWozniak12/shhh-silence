using ShhhSilence.Base.Data;
using ShhhSilence.Game.Behaviours;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Static.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    /// <summary>
    /// Handles user interaction
    /// Overrides layer to "Interactable"
    /// </summary>
    [RequireComponent(typeof(AudioBase))]
    [RequireComponent(typeof(EventOnUserInteraction))]
    public class Interactable : MonoBehaviour
    {
        private LayerMask layer;

        private EventOnUserInteraction interaction;

        [SerializeField]
        private AudioData audioOnUse;

        [SerializeField]
        private AudioBase audioBase;

        private void Awake()
        {
            layer = LayerMask.NameToLayer(Layers.INTERACTABLE_LAYER);
            gameObject.layer = layer;
            audioBase = GetComponent<AudioBase>();
            interaction = GetComponent<EventOnUserInteraction>();
        }

        private void Start()
        {
            interaction.Event.AddListener(PlaySound);
        }

        /// <summary>
        /// Object that are interacting with interactable
        /// </summary>
        public void Interact(GameObject gameObject)
        {
            interaction.Interact(gameObject);
        }

        public void PlaySound(GameObject agent) => audioBase.Play(audioOnUse);
    }
}