using ShhhSilence.Base.Managers;
using UnityEngine;
using UnityEngine.Audio;

namespace ShhhSilence.Base.Behaviours
{
    public class SnapshotModifierSetter : MonoBehaviour
    {
        [SerializeField]
        AudioMixerSnapshot snapshotOn;

        [SerializeField] 
        AudioMixerSnapshot snapshotOff;

        [SerializeField]
        bool state = true;

        public void Toggle()
        {
            state = !state;
            SetActive(state);
        }

        public void SetActive(bool isTrue)
        {
            state = isTrue;
            if (state)
            {
                StateOn();
            }
            else StateOff();
        }

        public void StateOn()
        {
            AddSnapshot(snapshotOn);
            DeleteSnapshot(snapshotOff);
        }

        public void StateOff()
        {
            AddSnapshot(snapshotOn);
            DeleteSnapshot(snapshotOff);
        }

        private void Start() => SetActive(state);
        public void AddSnapshot(AudioMixerSnapshot snapshot) => AudioManager.Instance.AddSnapshot(snapshot);
        public void DeleteSnapshot(AudioMixerSnapshot snapshot) => AudioManager.Instance.DeleteSnapshot(snapshot);
    }
}

