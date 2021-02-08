using ShhhSilence.Base.Managers;
using ShhhSilence.Base.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using ShhhSilence.Game.Entities;

namespace ShhhSilence.Game.Managers
{
    public class ColorManager : BaseManager<ColorManager>
    {
        [SerializeField]
        private List<ColorGroup> groups;

        private List<IColorHandler> handlers = new List<IColorHandler>();

        private void Start()
        {
            groups.ForEach(x => x.GenerateVariations());
            RefreshColors();
        }

        [ContextMenu("Refresh Colors")]
        private void RefreshColors()
        {
            groups.ForEach(x => x.GenerateVariations());
            handlers.ForEach(x => x.RefreshColor());
        }

        public Material GetRandomColorFromGroup(string groupName)
        {
            return groups.Find(x => x.GroupName == groupName).GetRandomMaterial();
        }

        public void Subscribe(IColorHandler item)
        {
            handlers.Add(item);
        }

        public void UnSubscribe(IColorHandler item)
        {
            handlers.Remove(item);
        }
    }
}