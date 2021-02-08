using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnPositionChange : MonoBehaviour
    {
        /// <summary>
        /// Passes previous and current position
        /// </summary>
        public UnityEvent<Vector3, Vector3> Event;

        [SerializeField]
        private Vector3 position;

        [SerializeField]
        private float treshold = 0.01f;

        [SerializeField]
        private new Transform transform;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            position = transform.position;
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, position) > 0 + treshold)
            {
                Event?.Invoke(position, transform.position);
                position = transform.position;
            }
        }
    }
}