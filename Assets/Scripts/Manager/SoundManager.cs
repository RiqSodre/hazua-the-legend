using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSound;                        //efeitos sonoros
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRage = 1.05f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSound.clip = clip;
        efxSound.Play();
    }

    public void RandomizeSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRage);

        efxSound.pitch = randomPitch;
        efxSound.clip = clips[randomIndex];
        efxSound.Play();
    }
}
