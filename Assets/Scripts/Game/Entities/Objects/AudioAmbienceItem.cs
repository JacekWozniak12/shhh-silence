using System.Collections;
using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
class AudioAmbienceItem : AudioBase
{

    [SerializeField] AudioAmbience audioAmbience;

    private bool setted = true;

    private float SettedVolume;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        if (audioAmbience == null) audioAmbience = AudioManager.Instance.DefaultAmbience;
        SettedVolume = audioSource.volume;
    }

    private void FixedUpdate()
    {
        if (audioAmbience != AudioManager.Instance.CurrentAmbience)
        {
            if (setted)
            {
                StopAllCoroutines();
                StartCoroutine(SlowlyChangeVolume(5, 0.1f, 0));
                setted = false;
            }
        }
        else
        {
            if (!setted)
            {
                StopAllCoroutines();
                StartCoroutine(SlowlyChangeVolume(5, 0.1f, SettedVolume));
                setted = true;
            }
        }
    }

    private IEnumerator SlowlyChangeVolume(float time, float step, float volume)
    {
        var temp = 0f;
        while (temp < time)
        {
            yield return new WaitForSeconds(step);
            temp += Time.deltaTime + step;
            audioSource.volume = Mathf.Lerp(audioSource.volume, volume, temp / time);
        }
        yield return new WaitForEndOfFrame();
    }

}