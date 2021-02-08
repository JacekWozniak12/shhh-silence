using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnMouseKeyPress : MonoBehaviour
    {
        public UnityEvent Event;

        [SerializeField]
        private int mouseButton;

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseButton))
            {
                Event?.Invoke();
            }
        }
    }
}