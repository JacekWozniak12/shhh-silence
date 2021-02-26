using System;
using ShhhSilence.Base.Managers;
using UnityEngine;
using System.Collections.Generic;
using ShhhSilence.Game.Behaviours.Events;

namespace ShhhSilence.Game.Managers
{
    public class TimeManager : BaseManager<TimeManager>
    {
        [SerializeField]
        [Tooltip("in seconds")]
        private float timeFromStartGame;

        [SerializeField]
        public List<EventOnTime> Events;

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