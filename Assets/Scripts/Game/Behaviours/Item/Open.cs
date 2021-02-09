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
            closeRotation = transform.rotation.y;
            openRotation += transform.rotation.y;

            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[0].AddListener(Activate);
            state.Queue.Add(new UnityEvent<GameObject>());
            state.Queue[1].AddListener(DeActivate);
        }

        private void Activate(GameObject agent)
        {
            StartCoroutine(ChangeRotation(openRotation));
            print("a");
        }

        private void DeActivate(GameObject agent)
        {
            StartCoroutine(ChangeRotation(closeRotation));
            print("b");
        }

        private IEnumerator ChangeRotation(float rotation)
        {
            rotation = Mathf.Deg2Rad * rotation;

            while (transform.rotation.y != rotation)
            {
                transform.rotation = Quaternion.Euler(
                    transform.rotation.y,
                    Mathf.LerpAngle(
                        transform.rotation.y,
                        rotation,
                        Time.deltaTime * speed),
                    transform.rotation.z);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}

