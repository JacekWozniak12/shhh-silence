using System;
using ShhhSilence.Base.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    [RequireComponent(typeof(AudioAmbienceItem))]
    public class PlayerFootstepController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController body;

        [SerializeField]
        float period = 0.5f;

        [SerializeField]
        private AudioData defaultFootsteps;

        [SerializeField]
        AudioAmbienceItem ambienceItem;

        float timeToNextFootstep;

        private void Start()
        {
            ambienceItem = GetComponent<AudioAmbienceItem>();
        }

        private void FixedUpdate()
        {
            if (body.velocity == Vector3.zero || !body.isGrounded)
            {
                return;
            }

            if (timeToNextFootstep > 0)
            {
                timeToNextFootstep -= Time.fixedDeltaTime;
                return;
            }

            timeToNextFootstep = period;

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.2f))
            {
                if (hit.collider.GetComponent<AudioFootstepModifier>() is AudioFootstepModifier surface)
                {
                    ambienceItem.Play(surface.Footstep);
                    return;
                }
            }

            ambienceItem.Play(defaultFootsteps);
        }

    }
}