using UnityEngine;
using ShhhSilence.Library;
using ShhhSilence.Game.Managers;
using ShhhSilence.Base.Interfaces;

namespace ShhhSilence.Game.Behaviours.Random
{
    public class RandomAudio : MonoBehaviour, IAudioHandler
    {
        public string audioGroup;

        private void Awake()
        {
            AddToManager();
        }

        private void AddToManager()
        {
            GameSoundManager.Instance.Subscribe(this);
        }

        public void RefreshAudio()
        {
            throw new System.NotImplementedException();
        }
    }
}
