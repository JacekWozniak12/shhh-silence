using System.Collections;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using ShhhSilence.Game.Settings;
using ShhhSilence.Base.Data;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventQueueOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class PullPush : MonoBehaviour
    {
        private EventQueueOnUserInteraction state;

        private new Transform transform;

        [SerializeField]
        private Vector3 pullDirection;

        private Vector3 pushPosition;

        [SerializeField]
        private float timeToFull = 1;

        [SerializeField]
        private AudioData activated;

        [SerializeField]
        private AudioData deactivated;

        private AudioAmbienceItem item;

        private void Start()
        {
            GetComponents();
            CreatePushPull();
        }

        private void GetComponents()
        {
            transform = GetComponent<Transform>();
            pushPosition = transform.position;
            state = GetComponent<EventQueueOnUserInteraction>();
        }

        private void CreatePushPull()
        {
            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[0].AddListener(Activate);

            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[1].AddListener(DeActivate);
        }

        private void Activate(GameObject agent)
        {
            Vector3 position = transform.position + transform.TransformDirection(pullDirection);
            transform.DOMove(position, timeToFull);
            if (activated != null) item?.Play(activated);
        }

        private void OnCollisionEnter(Collision other)
        {
            transform.DOKill();
        }

        private void DeActivate(GameObject agent)
        {
            transform.DOMove(pushPosition, timeToFull);
            if (deactivated != null) item?.Play(deactivated);
        }
    }
}
