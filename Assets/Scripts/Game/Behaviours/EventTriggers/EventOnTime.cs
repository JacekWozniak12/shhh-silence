using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours.Events
{
    public class EventOnTime : MonoBehaviour
    {
        public UnityEvent Event;
        public float TimeToEvent;
        
        public void StartCountdown()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(TimeToEvent);
            Event?.Invoke();
        }
    }
}