using UnityEngine;

namespace ShhhSilence.Game.Controller.FPP
{
    public class PlayerSetter : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layer = LayerMask.NameToLayer("Player");

        [SerializeField]
        private GameObject[] playerObjects;

        private void Awake()
        {
            SetLayer();
        }

        private void SetLayer()
        {
            gameObject.layer = layer;
            foreach (var playerObject in playerObjects)
            {
                playerObject.layer = layer;
            }
        }
    }
}