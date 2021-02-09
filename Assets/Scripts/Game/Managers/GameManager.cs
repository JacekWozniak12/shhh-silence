using ShhhSilence.Base.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace ShhhSilence.Game.Managers
{
    public class GameManager : BaseManager<GameManager>
    {
        public UnityEvent SoundExceedTreshold;

        public int SoundTreshold;

        
    }
}