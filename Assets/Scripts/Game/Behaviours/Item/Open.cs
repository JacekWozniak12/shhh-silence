using System.Collections.Generic;
using System.Collections;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(EventQueueOnUserInteraction))]
    [RequireComponent(typeof(Interactable))]
    public class Open : MonoBehaviour
    {
        private EventQueueOnUserInteraction state;
        private new Transform transform;

        [SerializeField]
        private float openRotation = 90;

        [SerializeField]
        private float closeRotation = 0;

        [SerializeField]
        private float speed = 1;

        private void Start()
        {
            transform = GetComponent<Transform>();
            state = GetComponent<EventQueueOnUserInteraction>();
            closeRotation = transform.rotation.eulerAngles.y;
            openRotation += transform.rotation.eulerAngles.y;

            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[0].AddListener(Activate);
            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[1].AddListener(DeActivate);
        }

        private void Activate(GameObject agent)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeRotation(openRotation));
        }

        private void DeActivate(GameObject agent)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeRotation(closeRotation));
        }

        private IEnumerator ChangeRotation(float rotation)
        {
            rotation = Mathf.Deg2Rad * rotation;

            while (transform.rotation.eulerAngles.y != rotation)
            {
                Quaternion target = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation, transform.rotation.eulerAngles.y);
                transform.rotation = Quaternion.Lerp(transform.rotation, target,  Time.deltaTime * speed);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}

