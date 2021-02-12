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
            Collider[] itemColliders = Physics.OverlapBox(
                transform.position,
                collider.bounds.extents,
                transform.rotation);

            foreach (Collider item in itemColliders)
            {
                if (item.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem ambienceItem)
                {
                    ambienceItem.Ambience = Ambience;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG))
            {
                AudioManager.Instance.CurrentAmbience = Ambience;
                return;
            }
            if (other.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem item)
            {
                item.Ambience = Ambience;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG) && AudioManager.Instance.CurrentAmbience != Ambience)
            {
                AudioManager.Instance.CurrentAmbience = Ambience;
            }
            if (other.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem item && item.Ambience != Ambience)
            {
                item.Ambience = Ambience;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG))
            {
                AudioManager.Instance.CurrentAmbience = AudioManager.Instance.DefaultAmbience;
                return;
            }
            if (other.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem item)
            {
                item.Ambience = AudioManager.Instance.DefaultAmbience;
            }
        }
    }
}