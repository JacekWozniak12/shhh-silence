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

        #endregion

        #region Mouse

        [Header("Mouse")]
        public float MouseSpeed = 2;

        public string Throw = "Fire1";
        public string Drop = "Fire2";

        public string MouseAxisX = "Mouse X";
        public string MouseAxisY = "Mouse Y";

        #endregion
    }
}

