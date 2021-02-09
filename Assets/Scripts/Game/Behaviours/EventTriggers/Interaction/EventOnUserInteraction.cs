using ShhhSilence.Base.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnUserInteraction : MonoBehaviour, IEventInteractable<GameObject>
    {
        /// <summary>
        /// Passes agent which interacted.
        /// </summary>
        public UnityEvent<GameObject> Event = new UnityEvent<GameObject>();

        public void AddListener(UnityAction<GameObject> action)
        {
            Event?.AddListener(action);
        }

        public void Interact(GameObject agent)
        {
            Event?.Invoke(agent);
        }

        public void RemoveListener(UnityAction<GameObject> action)
        {
            Event?.RemoveListener(action);
        }
    }
}