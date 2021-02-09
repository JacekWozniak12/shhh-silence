using System.Collections;
using ShhhSilence.Game.Entities;
using UnityEngine;

namespace ShhhSilence.Game.Behaviours
{
    [RequireComponent(typeof(Interactable))]
    public class Open : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Interactable>();
        }


    }
}

