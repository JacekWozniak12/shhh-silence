using ShhhSilence.Base.Managers;
using ShhhSilence.Base.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using ShhhSilence.Game.Entities;
using ShhhSilence.Base.Data;

namespace ShhhSilence.Game.Managers
{
    public class GameSoundManager : BaseManager<GameSoundManager>
    {

        [SerializeField]
        private List<AudioGroup> groups;

        private List<IAudioHandler> handlers = new List<IAudioHandler>();

        private void Start()
        {
            groups.ForEach(x => x.GenerateVariations());
            RefreshAudio();
        }

        [ContextMenu("Refresh Colors")]
        private void RefreshAudio()
        {
            groups.ForEach(x => x.GenerateVariations());
            handlers.ForEach(x => x.RefreshAudio());
        }

        public AudioData GetAudioFromGroup(string groupName)
        {
            return groups.Find(x => x.GroupName == groupName).GetRandomAudio();
        }

        public void Subscribe(IAudioHandler item)
        {
            handlers.Add(item);
        }

        public void UnSubscribe(IAudioHandler item)
        {
            handlers.Remove(item);
        }
    }
}