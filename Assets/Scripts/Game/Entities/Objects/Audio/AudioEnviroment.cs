using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(BoxCollider))]
    public class AudioEnviroment : MonoBehaviour
    {
        private new Collider collider;
        [SerializeField] AudioAmbience Ambience;

        private void Start()
        {
            collider = GetComponent<Collider>();
            collider.isTrigger = true;
            Collider[] itemColliders = Physics.OverlapBox(
                transform.position,
                collider.bounds.extents,
                transform.rotation);

            foreach (Collider item in itemColliders)
            {
                if (item.GetComponent<AudioAmbienceItem>() == null)
                {
                    continue;
                }

                if (item.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem ambienceItem)
                {
                    ambienceItem.SetAudioAmbience(Ambience);
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
                item.SetAudioAmbience(Ambience);
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
                item.SetAudioAmbience(AudioManager.Instance.DefaultAmbience);
            }
        }
    }
}