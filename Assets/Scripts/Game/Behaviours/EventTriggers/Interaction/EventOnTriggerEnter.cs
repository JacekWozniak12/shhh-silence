using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnTriggerEnter : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnTriggerEnter(Collider other)
        {
            Event?.Invoke();
        }
    }
}