using System;
using ShhhSilence.Game.Entities;
using ShhhSilence.Game.Static.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    /// <summary>
    /// Handles interactions like picking items or using them
    /// </summary>
    public class PlayerGrabberController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Used to provide settings for Controller")]
        private PlayerControlsProvider controlsProvider;

        [SerializeField]
        private PlayerHandController handController;

        [SerializeField]
        private Transform view;

        [SerializeField]
        private Pickable grabbed;

        private void Update()
        {
            GrabInput();
            ThrowInput();
            DropInput();
        }

        private void GrabInput()
        {
            if (grabbed != null) return;

            if (!Input.GetButtonDown(controlsProvider.Pick))
            {
                return;
            }

            if (handController?.WithinHand?.GetComponent<Pickable>() is Pickable pickable)
            {
                grabbed = pickable;
                grabbed?.PickWith(handController.transform);
            }
        }

        private void ThrowInput()
        {
            if (Input.GetButtonDown(controlsProvider.Throw))
            {
                grabbed?.LetGo(Vector3.Normalize(view.forward) * 250f);
                grabbed = null;
            }
        }

        private void DropInput()
        {
            if (Input.GetButtonDown(controlsProvider.Drop))
            {
                grabbed?.LetGo(Vector3.zero);
                grabbed = null;
            }
        }

    }
}