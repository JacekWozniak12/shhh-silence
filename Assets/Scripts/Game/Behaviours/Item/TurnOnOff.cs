using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using ShhhSilence.Base.Data;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventQueueOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class TurnOnOff : MonoBehaviour
    {
        private EventQueueOnUserInteraction state;
        private new Transform transform;

        [SerializeField]
        private TurnedOff[] toTurnOn;

        [SerializeField]
        private AudioData activated;

        [SerializeField]
        private AudioData deactivated;

        private AudioAmbienceItem item;

        private void Start()
        {
            GetComponents();
            CreateOnOff();
        }

        private void GetComponents()
        {
            state = GetComponent<EventQueueOnUserInteraction>();
            item = GetComponent<AudioAmbienceItem>();
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
            foreach (TurnedOff item in toTurnOn)
            {
                item?.SetActive(true);
            }
            if (activated != null) item?.Play(activated);
        }

        private void DeActivate(GameObject agent)
        {
            foreach (TurnedOff item in toTurnOn)
            {
                item.SetActive(false);
            }
            if (deactivated != null) item?.Play(deactivated);
        }
    }
}
