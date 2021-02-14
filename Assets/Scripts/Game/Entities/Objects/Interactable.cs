using ChrisNolet;
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
    [RequireComponent(typeof(Outline))]
    public class Interactable : MonoBehaviour
    {
        private Outline outline;
        private LayerMask layer;
        private bool selected = true;

        public IEventInteractable<GameObject>[] interactions;

        private void Awake()
        {
            outline = GetComponent<Outline>();
            outline.OutlineWidth = 10;
            outline.OutlineColor = Color.red;
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            
            layer = LayerMask.NameToLayer(Layers.INTERACTABLE_LAYER);
            gameObject.layer = layer;
            interactions = GetComponents<IEventInteractable<GameObject>>();
            Deselect();
        }

        /// <summary>
        /// Object that are interacting with interactable
        /// </summary>
        public void Interact(GameObject gameObject)
        {
            foreach(IEventInteractable<GameObject> item in interactions)
            {
                item.Interact(gameObject);
            }
        }

        public void Select()
        {
            if (!selected)
            {
                outline.enabled = true;
                selected = true;
            }
        }

        public void Deselect()
        {
            if (selected)
            {
                outline.enabled = false;
                selected = false;
            }
        }
    }
}