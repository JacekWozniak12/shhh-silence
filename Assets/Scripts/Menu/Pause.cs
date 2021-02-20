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

        private void Awake() {
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
            if (isTrue)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            foreach (MonoBehaviour behaviour in deactivateWhenPaused)
            {
                behaviour.enabled = !isTrue;
            }
        }
    }
}