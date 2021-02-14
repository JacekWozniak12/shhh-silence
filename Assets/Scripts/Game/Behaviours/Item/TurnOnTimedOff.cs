using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using ShhhSilence.Base.Data;
using System.Collections;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class TurnOnTimedOff : MonoBehaviour
    {
        private EventOnUserInteraction eventOn;
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
            eventOn = GetComponent<EventOnUserInteraction>();
            item = GetComponent<AudioAmbienceItem>();
        }

        private void CreateOnOff()
        {
            eventOn.AddListener(Activate);
        }

        private void Activate(GameObject agent)
        {
            foreach (GameObject item in toTurnOn)
            {
                item.SetActive(true);
            }
            if (activated != null) item?.Play(activated);
            StartCoroutine(TimedOff());

        }

        private void DeActivate(GameObject agent)
        {
            foreach (GameObject item in toTurnOn)
            {
                item.SetActive(false);
            }
            if (deactivated != null) item?.Play(deactivated);
        }

        private IEnumerator TimedOff()
        {
            yield return new WaitForSeconds(period);
            DeActivate(this.gameObject);
        }
    }
}
