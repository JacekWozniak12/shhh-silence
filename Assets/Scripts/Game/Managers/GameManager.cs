using ShhhSilence.Base.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Managers
{
    public class GameManager : BaseManager<GameManager>
    {
        public UnityEvent corruptionExceedThreshold;

        [SerializeField]
        private float corruptionThreshold = 100f;

        [SerializeField]
        private float changePerSecond  = 0.5f;

        
    }
}