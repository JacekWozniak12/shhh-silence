using System;
using ShhhSilence.Game.Entities;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    /// <summary>
    /// Handles interactions like picking items or using them
    /// </summary>
    public class PlayerHandController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 handRadius = Vector3.one / 4;

        [SerializeField]
        private Transform view;

        public new Transform transform;
        public GameObject WithinHand;

        [SerializeField]
        private LayerMask interactableLayer;

        private void Awake()
        {
            interactableLayer = 1 << LayerMask.NameToLayer(Layers.INTERACTABLE_LAYER);
        }

        private void FixedUpdate()
        {
            PlaceHand();
            GetObjectWithinHand();
        }

        private void PlaceHand()
        {
            if (Physics.Raycast(
                view.position,
                view.forward,
                out RaycastHit hit,
                1f,
                ~(interactableLayer)))
            {
                transform.position = hit.point;
            }
            else
            {
                transform.position = view.position + view.forward;
            }
        }

        /// <summary>
        /// Get first object from colliders.
        /// </summary>
        private void GetObjectWithinHand()
        {
            Collider[] colliders = Physics.OverlapBox(
                transform.position,
                handRadius,
                transform.rotation,
                interactableLayer);

            WithinHand = null;

            if (colliders.Length > 0)
            {
                WithinHand = colliders[0].gameObject;
            }
        }

    }
}