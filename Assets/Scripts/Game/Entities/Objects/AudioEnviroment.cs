using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Managers;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(BoxCollider))]
    public class AudioEnviroment : MonoBehaviour
    {
        private new Collider collider;
        [SerializeField] AudioAmbience Ambience;

        private void OnEnable()
        {
            collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG)) AudioManager.Instance.CurrentAmbience = Ambience;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG)
                && AudioManager.Instance.CurrentAmbience != Ambience) AudioManager.Instance.CurrentAmbience = Ambience;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG)) AudioManager.Instance.CurrentAmbience = AudioManager.Instance.DefaultAmbience;
        }
    }
}