using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using ShhhSilence.Game.Controller.FPP;

namespace ShhhSilence.Menu.Behaviours
{
    public class Pause : MonoBehaviour
    {
        private bool active;

        [SerializeField]
        private List<MonoBehaviour> deactivateWhenPaused;

        private void OnEnable() {
            deactivateWhenPaused = new List<MonoBehaviour>();
            deactivateWhenPaused?.Add(FindObjectOfType<PlayerBodyController>());
            deactivateWhenPaused?.Add(FindObjectOfType<PlayerGrabberController>());
            deactivateWhenPaused?.Add(FindObjectOfType<PlayerFootstepController>());
            deactivateWhenPaused?.Add(FindObjectOfType<PlayerHandController>());
            deactivateWhenPaused?.Add(FindObjectOfType<PlayerInteractionController>());
        }

        public void Toggle()
        {
            active = !active;
            Switch(active);
        }

        public void Switch(bool isTrue)
        {
            foreach (MonoBehaviour behaviour in deactivateWhenPaused)
            {
                behaviour.enabled = !isTrue;
            }
        }
    }
}