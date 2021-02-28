using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoBotones : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("musicBoton").GetComponent<AudioSource>();
        gameObject.AddComponent<AudioSource>();

        button.onClick.AddListener(PlaySound);
    }

    // Update is called once per frame
    void PlaySound()
    {
        source.PlayOneShot(clip);
    }
}
