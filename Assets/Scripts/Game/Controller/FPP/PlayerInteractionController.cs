using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    [RequireComponent(typeof(EventOnButtonPress))]
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

        private void Awake()
        {
            GetComponent<EventOnButtonPress>();
        }

        private void Update()
        {
            InteractInput();
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
        }
    }
}