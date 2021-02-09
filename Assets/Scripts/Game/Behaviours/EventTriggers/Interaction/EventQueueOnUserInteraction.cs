using System.Collections.Generic;
using ShhhSilence.Base.Interfaces;
using ShhhSilence.Library;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventQueueOnUserInteraction : MonoBehaviour, IEventInteractable<GameObject>
    {
        /// <summary>
        /// Passes agent which interacted.
        /// </summary>
        public List<UnityEvent<GameObject>> Queue = new List<UnityEvent<GameObject>>();

        private int currentIndex = 0;

        public void Interact(GameObject agent)
        {
            Queue[currentIndex++]?.Invoke(agent);
            currentIndex = MathL.LoopPositive(currentIndex, Queue.Count - 1);
        }

        /// <summary>
        /// Adds listener to event on current index
        /// </summary>
        public void AddListener(UnityAction<GameObject> action)
        {
            Queue[currentIndex].AddListener(action);
        }

        /// <summary>
        /// Removes listener at event in current index
        /// </summary>
        public void RemoveListener(UnityAction<GameObject> action)
        {
            Queue[currentIndex].RemoveListener(action);
        }

        /// <summary>
        /// Removes listener at event in specified index
        /// </summary>
        public void AddListener(int index, UnityAction<GameObject> action)
        {
            Queue[index].AddListener(action);
        }

        /// <summary>
        /// Adds listener to event in specified index
        /// </summary>
        public void RemoveListener(int index, UnityAction<GameObject> action)
        {
            Queue[index].RemoveListener(action);
        }
    }
}