using System.Collections;
using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Data;
using ShhhSilence.Game.Entities;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
class AudioAmbienceItem : AudioBase
{
    public AudioAmbience Ambience;

    private bool setted = true;

    private float SettedVolume;

    private void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        if (Ambience == null) Ambience = AudioManager.Instance.DefaultAmbience;
        SettedVolume = audioSource.volume;
    }
    private void FixedUpdate()
    {
        if (Ambience != AudioManager.Instance.CurrentAmbience)
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