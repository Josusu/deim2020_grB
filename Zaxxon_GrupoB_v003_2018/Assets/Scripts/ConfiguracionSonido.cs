using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ConfiguracionSonido : MonoBehaviour
{

    public GameObject botonFx;
    public Text encendido;
    private bool cambio = true;
    private AudioSource botonSource;
    private AudioSource explosionSource;
    private AudioClip botonClip;
    private AudioClip explosionClip;
    public GameObject volumeSlider;
    public AudioMixer volumeMixer;

    // Start is called before the first frame update
    void Start()
    {
        botonSource = GameObject.Find("musicBoton").GetComponent<AudioSource>();
        explosionSource = GameObject.Find("sonidoExplosion").GetComponent<AudioSource>();
        botonClip = GameObject.Find("musicBoton").GetComponent<AudioClip>();
        explosionClip = GameObject.Find("sonidoExplosion").GetComponent<AudioClip>();

    }

    public void OnButtonClicked()
    {
        cambio = !cambio;
        if(cambio)
        {
            encendido.text = "encendido";
            botonFx.GetComponent<Image>().color = new Color(0.02745098f, 0.7215686f, 0.4941177f);
            botonSource.mute = false;
            explosionSource.mute = false;
        }
        else
        {
            encendido.text = "apagado";
            botonFx.GetComponent<Image>().color = new Color(0.7450981f, 0, 0.172549f);
            botonSource.mute = true;
            explosionSource.mute = true;

        }
    }

    public void SetVolume (float sliderValue)
    {
        volumeMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
