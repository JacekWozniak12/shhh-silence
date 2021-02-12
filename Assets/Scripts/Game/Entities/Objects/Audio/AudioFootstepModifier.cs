using ShhhSilence.Base.Data;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(BoxCollider))]
    public class AudioFootstepModifier : MonoBehaviour
    {
        [SerializeField]
        AudioData footstep;

        public AudioData Footstep
        {
            get => footstep;
            private set => footstep = value;
        }

    }
}