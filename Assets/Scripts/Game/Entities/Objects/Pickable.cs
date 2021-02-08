using ShhhSilence.Base.Data;
using ShhhSilence.Game.Behaviours;
using ShhhSilence.Game.Behaviours.Events;
using ShhhSilence.Game.Static.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(EventOnVelocity))]
    [RequireComponent(typeof(EventOnUserInteraction))]
    [RequireComponent(typeof(AudioBase))]
    /// <summary>
    /// Handles user picking object
    /// Overrides layer to "Interactable"
    /// </summary>
    public class Pickable : MonoBehaviour
    {
        [SerializeField]
        private AudioData hit;

        private new Rigidbody rigidbody;
        private new Transform transform;
        private Transform defaultParent;
        private AudioBase audioBase;
        private EventOnUserInteraction userEvt;

        private Vector3 offset;
        private bool grabbed;
        private LayerMask layer;

        private void Awake()
        {
            SetPhysics();
            SetAudioEvents();
        }

        private void SetAudioEvents()
        {
            EventOnVelocity velocityEvt = GetComponent<EventOnVelocity>();
            userEvt = GetComponent<EventOnUserInteraction>();
            audioBase = GetComponent<AudioBase>();
            velocityEvt.Event.AddListener(HitSound);
            userEvt.Event.AddListener(HitSound);
        }

        private void HitSound() => audioBase.Play(hit);
        private void HitSound(GameObject agent) => audioBase.Play(hit);

        private void SetPhysics()
        {
            layer = LayerMask.NameToLayer(Layers.INTERACTABLE_LAYER);
            gameObject.layer = layer;

            offset += GetComponent<Renderer>().bounds.extents;
            rigidbody = GetComponent<Rigidbody>();
            transform = GetComponent<Transform>();
            defaultParent = transform.parent;
        }

        private void FixedUpdate()
        {
            if (!grabbed) return;

            Vector3 offsetPoint = transform.parent.TransformDirection(offset);

            if (transform.position != transform.parent.position + offsetPoint)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    transform.parent.position + offsetPoint,
                    5f * Time.fixedDeltaTime);
            }

            transform.rotation = Quaternion.Euler(new Vector3(transform.parent.rotation.x, 0, transform.parent.rotation.z));
        }

        public void PickWith(Transform grabAgent)
        {
            userEvt.Interact(grabAgent.gameObject);
            transform.parent = grabAgent;
            grabbed = true;
            rigidbody.useGravity = false;
        }

        public void LetGo(Vector3 force)
        {
            userEvt.Interact(null);
            transform.parent = defaultParent;
            grabbed = false;
            rigidbody.useGravity = true;
            rigidbody.AddForce(force, ForceMode.Force);
        }
    }
}