using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    /// <summary>
    /// Handles camera view and body rotation.
    /// </summary>
    public class PlayerCameraController : MonoBehaviour
    {

        [SerializeField]
        private Transform view;

        [SerializeField]
        private CharacterController body;

        [SerializeField]
        private Transform bodyTransform;

        [SerializeField]
        [Tooltip("Used to provide settings for Controller")]
        private PlayerControlsProvider controlsProvider;

        #region private variables

        private const float MINIMAL_CAMERA_ROT_X = -75f;
        private const float MAXIMAL_CAMERA_ROT_X = 85f;

        private Vector3 currentBodyRotation;
        private float desiredBodyRotationY = 0f;

        private Vector3 currentCameraRotation;
        private float desiredCameraRotationX = 0f;

        #endregion

        private void Awake()
        {
            controlsProvider.ShowCursor(false);
            controlsProvider.SetCursorLockState(CursorLockMode.Locked);
            GetInformations();
        }

        private void GetInformations()
        {
            view = view ?? GetComponentInChildren<Camera>().transform;
            body = body ?? GetComponentInChildren<CharacterController>();
            currentCameraRotation = view.rotation.eulerAngles;
            currentBodyRotation = body.transform.rotation.eulerAngles;
        }

        private void Update() => Move();

        public void Move()
        {
            HandleHorizontalRotation();
            HandleVerticalRotation();
        }

        private void HandleVerticalRotation()
        {
            float inputAxisY = Input.GetAxis(controlsProvider.MouseAxisY);

            if (inputAxisY != 0)
            {
                CalculateDesiredCameraRotationX(inputAxisY);
            }

            CalculateVerticalRotation();
            SetVerticalRotation();
        }

        private void SetVerticalRotation()
        {
            view.localRotation = Quaternion.Euler(currentCameraRotation);
        }

        private void CalculateVerticalRotation()
        {
            currentCameraRotation = Vector3.Lerp(
                currentCameraRotation,
                desiredCameraRotationX * Vector3.left,
                Time.deltaTime * controlsProvider.MouseSpeed);
        }

        private void CalculateDesiredCameraRotationX(float inputAxisY)
        {
            desiredCameraRotationX += inputAxisY;

            desiredCameraRotationX = Mathf.Clamp(
                desiredCameraRotationX,
                MINIMAL_CAMERA_ROT_X,
                MAXIMAL_CAMERA_ROT_X);
        }

        private void HandleHorizontalRotation()
        {
            float inputAxisX = Input.GetAxis(controlsProvider.MouseAxisX);

            if (inputAxisX != 0)
            {
                desiredBodyRotationY += inputAxisX;
            }

            currentBodyRotation = Vector3.Lerp(
                currentBodyRotation,
                desiredBodyRotationY * Vector3.up,
                Time.deltaTime * controlsProvider.MouseSpeed);

            bodyTransform.rotation = Quaternion.Euler(currentBodyRotation);
        }
    }
}
