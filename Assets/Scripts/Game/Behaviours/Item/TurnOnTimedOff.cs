using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using ShhhSilence.Base.Data;
using System.Collections;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventQueueOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class TurnOnTimedOff : MonoBehaviour
    {
        private EventQueueOnUserInteraction state;
        private new Transform transform;

        [SerializeField]
        private GameObject[] toTurnOn;
        
        [SerializeField]
        private AudioData activated;

        [SerializeField]
        private AudioData deactivated;

        [SerializeField]
        private float period = 2f;

        private AudioAmbienceItem item;

        private void Start()
        {
            GetComponents();
            CreateOnOff();
        }

        private void GetComponents()
        {
            state = GetComponent<EventQueueOnUserInteraction>();
        }

        private void CreateOnOff()
        {
            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[0].AddListener(Activate);

            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[1].AddListener(DeActivate);
        }

        private void Activate(GameObject agent)
        {
            foreach (GameObject item in toTurnOn)
            {
                item.SetActive(true);
            }
            if (activated != null) item?.Play(activated);
            
        }

        private void DeActivate(GameObject agent)
        {
            foreach (GameObject item in toTurnOn)
            {
                item.SetActive(false);
            }
            if (deactivated != null) item?.Play(deactivated);
            StopAllCoroutines();
        }

        private IEnumerator TimedOff()
        {
            yield return new WaitForSeconds(period);
            state.Interact(this.gameObject);
        }
    }
}
