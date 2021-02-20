using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShhhSilence.Menu.Behaviours
{
    public class Pause : MonoBehaviour
    {
        private bool active;

        public void Toggle()
        {
            active = !active;
            Switch(active);
        }

        public void Switch(bool isTrue)
        {
            if (isTrue) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}