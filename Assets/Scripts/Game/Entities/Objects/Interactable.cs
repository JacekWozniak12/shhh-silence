using ShhhSilence.Base.Data;
using ShhhSilence.Base.Interfaces;
using ShhhSilence.Game.Behaviours;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Settings;
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

        public IEventInteractable<GameObject> interaction;

        [SerializeField]
        private AudioData audioOnUse;

        [SerializeField]
        private AudioBase audioBase;

        private void Awake()
        {
            layer = LayerMask.NameToLayer(Layers.INTERACTABLE_LAYER);
            gameObject.layer = layer;
            interaction = GetComponent<EventOnUserInteraction>();
        }

        /// <summary>
        /// Object that are interacting with interactable
        /// </summary>
        public void Interact(GameObject gameObject)
        {
            interaction.Interact(gameObject);
        }
    }
}