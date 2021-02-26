using ShhhSilence.Base.Interfaces;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(AudioAmbienceItem))]
    [RequireComponent(typeof(Interactable))]
    public class CorruptionItem : MonoBehaviour
    {
        private float minValue = 0.1f;
        private float maxValue = 1f;
        private float valueStepPerTick = 0.1f;

        private void OnEnable()
        {
            
        }
        private void OnDisable() 
        {
            
        }
    }
}