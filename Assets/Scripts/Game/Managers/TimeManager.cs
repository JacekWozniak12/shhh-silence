using ShhhSilence.Base.Managers;
using UnityEngine;

namespace ShhhSilence.Game.Managers
{
    public class TimeManager : BaseManager<TimeManager>
    {
        private float timeFromNewGame;
        public float TimeFromStartGame
        {
            get => timeFromNewGame;
            private set => timeFromNewGame = value;
        }
    }
}