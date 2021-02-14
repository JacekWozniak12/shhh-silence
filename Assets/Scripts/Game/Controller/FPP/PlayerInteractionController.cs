using ShhhSilence.Base.Data;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    /// <summary>
    /// Handles using items
    /// </summary>
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Used to provide settings for Controller")]
        private PlayerControlsProvider controlsProvider;

        [SerializeField]
        private PlayerHandController handController;

        [SerializeField]
        private AudioData nothingSelected;

        [SerializeField]
        private AudioAmbienceItem item;

        private Interactable lastInteractable;


        private void Update()
        {
            InteractInput();
        }

        private void FixedUpdate()
        {
            if (handController?.WithinHand?.GetComponent<Interactable>() is Interactable interactable)
            {
                if (interactable == lastInteractable) return;

                lastInteractable = interactable;
                lastInteractable.Select();
            }
            else
            {
                if (lastInteractable == null) return;

                lastInteractable.Deselect();
                lastInteractable = null;
            }
        }

        private void InteractInput()
        {
            if (!Input.GetButtonDown(controlsProvider.Use))
            {
                return;
            }

            if (handController?.WithinHand?.GetComponent<Interactable>() is Interactable interactable)
            {
                interactable.Interact(this.gameObject);
            }

            NothingSelected();
        }

        public void NothingSelected()
        {
            item.Play(nothingSelected);
        }
    }
}