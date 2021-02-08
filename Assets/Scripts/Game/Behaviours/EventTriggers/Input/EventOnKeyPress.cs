using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnKeyPress : MonoBehaviour
    {
        public UnityEvent Event;

        [SerializeField]
        private KeyCode key;

        private void Update()
        {
            if(Input.GetKeyDown(key))
            {
                Event?.Invoke();
            }
        }
    }
}