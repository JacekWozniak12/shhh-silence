using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Managers
{
    public class CorruptionManager : BaseManager<CorruptionManager>
    {
        [SerializeField]
        TimeValueTulp<float> howOften;

        [SerializeField]
        TimeValueTulp<float> howFast;

        [SerializeField]
        Transform corruptionHolder;

        CorruptionItem[] items;

        private void Start()
        {
            items = corruptionHolder.GetComponentsInChildren<CorruptionItem>();
            // TimeManager.Instance;
        }

        private void FixedUpdate()
        {

        }

        private void ChangeHowOften()
        {

        }

        private void ChangeHowFast()
        {

        }

    }
}