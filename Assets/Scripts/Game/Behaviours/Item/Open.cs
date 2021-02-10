using System.Collections;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using ShhhSilence.Game.Settings;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventQueueOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class Open : MonoBehaviour
    {
        private EventQueueOnUserInteraction state;

        private new Transform transform;

        [SerializeField]
        private bool swapWithBackward = false;

        [SerializeField]
        private Vector3 direction = Vector3.up * 90;

        private Vector3 closeRotation;

        [SerializeField]
        private RotateMode rotateMode = RotateMode.Fast;

        [SerializeField]
        private float timeToFull = 1;

        private void Start()
        {
            GetComponents();
            RegisterRotations();
            CreateOpenClose();
        }

        private void GetComponents()
        {
            transform = GetComponent<Transform>();
            state = GetComponent<EventQueueOnUserInteraction>();
        }

        private void RegisterRotations()
        {
            closeRotation = transform.rotation.eulerAngles;
            direction += transform.rotation.eulerAngles;
        }

        private void CreateOpenClose()
        {
            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[0].AddListener(Activate);

            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[1].AddListener(DeActivate);
        }

        private void Activate(GameObject agent)
        {
            transform.DORotate(direction, timeToFull, rotateMode);
        }

        private void DeActivate(GameObject agent)
        {
            transform.DORotate(closeRotation, timeToFull, rotateMode);
        }
    }
}

