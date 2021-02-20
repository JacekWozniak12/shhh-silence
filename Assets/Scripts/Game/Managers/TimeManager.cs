using System;
using ShhhSilence.Base.Managers;
using UnityEngine;
using System.Numerics;

namespace ShhhSilence.Game.Managers
{
    public class TimeManager : BaseManager<TimeManager>
    {
        [SerializeField]
        [Tooltip("in seconds")]
        private float timeFromStartGame;

        /// <summary>
        /// in seconds
        /// </summary>
        public float TimeFromStartGame
        {
            get => timeFromStartGame;
            private set => timeFromStartGame = value;
        }

        private void FixedUpdate()
        {
            timeFromStartGame += Time.fixedDeltaTime;
        }

    }
}