using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Managers
{
    public class CorruptionManager : BaseManager<CorruptionManager>
    {
        TimeValueTulp<float> howOften;
        TimeValueTulp<float> howFast;

        CorruptionItem[] items;
    }
}