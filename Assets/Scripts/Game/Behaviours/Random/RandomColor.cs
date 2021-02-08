using UnityEngine;
using ShhhSilence.Game.Managers;
using ShhhSilence.Base.Interfaces;

namespace ShhhSilence.Game.Behaviours.Random
{
    public class RandomColor : MonoBehaviour, IColorHandler
    {
        public string colorGroup;

        private void Awake()
        {
            AddToManager();
        }

        private void AddToManager()
        {
            ColorManager.Instance.Subscribe(this);
        }

        public void RefreshColor()
        {
            GetComponent<Renderer>().material = ColorManager.Instance.GetRandomColorFromGroup(colorGroup);
        }
    }
}
