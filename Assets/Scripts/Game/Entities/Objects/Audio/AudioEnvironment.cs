using ShhhSilence.Base.Behaviours;
using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Settings;
using UnityEngine;

namespace ShhhSilence.Game.Entities
{
    [RequireComponent(typeof(BoxCollider))]
    public class AudioEnvironment : MonoBehaviour
    {
        private new Collider collider;
        [SerializeField] AudioAmbience Ambience;
        [SerializeField] SnapshotModifierSetter setter;

        private void Start()
        {
            collider = GetComponent<Collider>();
            setter = GetComponent<SnapshotModifierSetter>();
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
                setter.SetActive(true);
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
                setter.SetActive(false);
                return;
            }
            if (other.GetComponent<AudioAmbienceItem>() is AudioAmbienceItem item)
            {
                item.SetAudioAmbience(AudioManager.Instance.DefaultAmbience);
            }
        }
    }
}