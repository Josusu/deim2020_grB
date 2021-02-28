using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlMusica : MonoBehaviour
{
    public AudioSource menuSource;
    public AudioSource gameSource;
    public AudioSource explosionSource;
    public AudioSource botonSource;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<AudioSource>();
        StartCoroutine(FadeIn(menuSource));
    }

    public static IEnumerator FadeIn(AudioSource musicSource)
    {
        float startVolume = 0.2f;

        musicSource.volume = 0;
        musicSource.Play();

        while (musicSource.volume < 1.0f)
        {
            musicSource.volume += startVolume * Time.deltaTime;

            yield return null;
        }

        musicSource.volume = 1f;
        musicSource.volume = 1f;
    }

    public void playGameMusic()
    {
        StartCoroutine(FadeIn(gameSource));
        menuSource.Stop();
    }
}
