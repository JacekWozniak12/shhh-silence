using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnCollision : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnCollisionEnter(Collision other)
        {
            Event?.Invoke();
        }
    }
}