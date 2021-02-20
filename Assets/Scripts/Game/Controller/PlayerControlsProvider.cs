using UnityEngine;

namespace ShhhSilence.Game.Controller
{
    public class PlayerControlsProvider : MonoBehaviour
    {
        #region Keyboard

        [Header("Keyboard Movement")]
        public string VerticalAxis = "Vertical";
        public string HorizontalAxis = "Horizontal";
        public string Jump = "Jump";

        [Header("Pick / Use")]
        public string Pick = "Pick";
        public string Use = "Use";

        [Header("Menu provider")]
        public string MainMenuButton = "MainMenu";

        #endregion

        #region Mouse

        [Header("Mouse")]
        public float MouseSpeed = 2;

        public string Throw = "Fire1";
        public string Drop = "Fire2";

        public string MouseAxisX = "Mouse X";
        public string MouseAxisY = "Mouse Y";

        public void SetCursorLockState(CursorLockMode mode)
        {
            Cursor.lockState = mode;
        }

        public void ShowCursor(bool isTrue = true)
        {
            Cursor.visible = isTrue;
        }

        #endregion
    }
}

