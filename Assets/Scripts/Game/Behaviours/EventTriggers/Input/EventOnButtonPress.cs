using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnButtonPress : MonoBehaviour
    {
        public UnityEvent Event;

        [SerializeField]
        private string key;

        private void Update()
        {
            if(Input.GetButtonDown(key))
            {
                Event?.Invoke();
            }
        }
    }
}