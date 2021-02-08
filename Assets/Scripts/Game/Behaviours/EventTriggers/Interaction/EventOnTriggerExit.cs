using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnTriggerExit : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnTriggerExit(Collider other)
        {
            Event?.Invoke();
        }
    }
}