using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class Slowmo : MonoBehaviour
{
    public float slowMotionTimeScale = 0.5f;
    public bool slowMotionEnabled = false;

    public AudioSource slowmosfx;

    public PostProcessVolume volume;
    private Vignette vignette;

    [System.Serializable]

    public class AudioSourceData
    {
        public AudioSource audioSource;
        public float defaultPitch;
    }

    AudioSourceData[] audioSources;



    
    void Start()
    {

        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0.3f;


        //Find all AudioSources in the Scene and save their default pitch values
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        audioSources = new AudioSourceData[audios.Length];

        for (int i = 0; i < audios.Length; i++)
        {
            AudioSourceData tmpData = new AudioSourceData();
            tmpData.audioSource = audios[i];
            tmpData.defaultPitch = audios[i].pitch;
            audioSources[i] = tmpData;
        }

        SlowMotionEffect(slowMotionEnabled);
    }

  
    void Update()
    {
        //Activate/Deactivate slow motion on key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            slowMotionEnabled = !slowMotionEnabled;
            SlowMotionEffect(slowMotionEnabled);
            slowmosfx.Play();
            vignette.intensity.value = 0.4f;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            slowMotionEnabled = !slowMotionEnabled;
            SlowMotionEffect(false);
            slowmosfx.Stop();
            vignette.intensity.value = 0.3f;

        }
    }

    void SlowMotionEffect(bool enabled)
    {
        Time.timeScale = enabled ? slowMotionTimeScale : 1;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].audioSource)
            {
                audioSources[i].audioSource.pitch = audioSources[i].defaultPitch * Time.timeScale;
            }
        }
    }

   
}
