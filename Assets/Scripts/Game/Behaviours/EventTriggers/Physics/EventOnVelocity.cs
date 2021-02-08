using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnVelocity : MonoBehaviour
    {
        [SerializeField]
        float velocityTreshold = 1;
        
        public UnityEvent Event;

        private void OnCollisionEnter(Collision other)
        {
            if (other.relativeVelocity.magnitude < velocityTreshold) return;
            else Event?.Invoke();
        }
    }
}