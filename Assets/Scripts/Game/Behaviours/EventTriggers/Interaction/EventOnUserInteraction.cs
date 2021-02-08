using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnUserInteraction : MonoBehaviour
    {
        /// <summary>
        /// Passes agent which interacted.
        /// </summary>
        public UnityEvent<GameObject> Event;

        public void Interact(GameObject agent)
        {
            Event?.Invoke(agent);
        }
    }
}