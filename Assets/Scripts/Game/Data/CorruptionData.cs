using UnityEngine;

namespace ShhhSilence.Game.Data
{
    [CreateAssetMenu(fileName = "CorruptionData", menuName = "shhh-silence/CorruptionData", order = 0)]
    public class CorruptionData : ScriptableObject
    {
        public TimeValueTulp<float> CorruptionChange;
        public TimeValueTulp<float> VolumeChange;
    }
}




