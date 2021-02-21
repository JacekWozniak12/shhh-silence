using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace ShhhSilence.Base.Behaviours
{
    /// <summary>
    /// Defines object with Dont Destroy On Load.
    /// </summary>
    public class PersistentGameObject : MonoBehaviour
    {
        private string _name;

        private void Awake()
        {
            if (_name == null || _name.Length < 1) _name = name;
            var objects = new List<PersistentGameObject>(FindObjectsOfType<PersistentGameObject>());
            if (objects.FindAll(x => x._name == this._name).Count > 1)
            {
                Destroy(this);
                return;
            }
            DontDestroyOnLoad(this);
        }
    }
}
