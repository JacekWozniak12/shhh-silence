using System;
using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    public class PlayerBodyController : MonoBehaviour
    {
        #region Unity components

        [SerializeField]
        private CharacterController body;

        [SerializeField]
        private Transform bodyTransform;

        [SerializeField]
        [Tooltip("Used to provide settings for Controller")]
        private PlayerControlsProvider controlsProvider;

        #endregion

        [SerializeField]
        private float speed = 5f;

        private void Awake()
        {
            if (body == null) GetComponentInChildren<CharacterController>();
        }

        private Vector3 currentVelocity;

        private Vector3 oldMoveVelocity = Vector3.zero;

        private float jumpTime = 0;

        [SerializeField]
        private float jumpForce = 0.15f;

        private void Update()
        {
            GetMovement();
            GetJump();
            Move();
        }

        private void GetMovement()
        {
            float inputAxisX = Input.GetAxis(controlsProvider.HorizontalAxis);
            float inputAxisY = Input.GetAxis(controlsProvider.VerticalAxis);

            if (inputAxisX != 0 || inputAxisY != 0)
            {
                var direction = bodyTransform.TransformDirection(Vector3.Normalize(new Vector3(inputAxisX, 0, inputAxisY)));
                var newVelocity = direction;
                currentVelocity = ((oldMoveVelocity + newVelocity) / 2) * speed;
                oldMoveVelocity = newVelocity;
            }
            else
            {
                currentVelocity = (oldMoveVelocity / 2) * speed;
                oldMoveVelocity = (oldMoveVelocity / 2);
            }
        }

        private void GetJump()
        {
            if (jumpTime > 0)
            {
                jumpTime -= Time.deltaTime;
                currentVelocity += Vector3.up * jumpForce - Physics.gravity;
            }

            if (!body.isGrounded) return;

            if (Input.GetButtonDown(controlsProvider.Jump))
            {
                jumpTime = 0.15f;
            }
        }

        private void Move()
        {
            Vector3 completeVelocity = (currentVelocity * speed + Physics.gravity) * Time.deltaTime;
            body.Move(completeVelocity);
        }
    }
}