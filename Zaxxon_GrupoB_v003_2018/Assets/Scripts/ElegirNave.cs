using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirNave : MonoBehaviour
{
    [SerializeField] GameObject[] naves;
    private int posActual, naveSeleccionada;
    private static ElegirNave elegirNave;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        /*if(elegirNave == null)
        {
            elegirNave = this;
        }
        else
        {
            DestroyObject(gameObject);
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        //posActual = 0;
        naveSeleccionada = 0;
        CerrarSeleccion();
    }

    public void IniciarSeleccion()
    {
        naves[naveSeleccionada].SetActive(true);
    }

    public void CerrarSeleccion()
    {
        for (int i = 0; i < naves.Length; i++)
        {
            naves[i].SetActive(false);
            naves[i].SetActive(false);
        }
    }


    public void PasarIzquierda()
    {
        if(posActual == 0)
        {
            naves[0].SetActive(false);
            naves[naves.Length-1].SetActive(true);
            posActual = naves.Length - 1;
        }
        else
        {
            naves[posActual].SetActive(false);
            naves[posActual- 1].SetActive(true);
            posActual--;
        }
    }

    public void PasarDerecha()
    {
        if (posActual == naves.Length-1)
        {
            naves[naves.Length - 1].SetActive(false);
            naves[0].SetActive(true);
            posActual = 0;
        }
        else
        {
            naves[posActual].SetActive(false);
            naves[posActual + 1].SetActive(true);
            posActual++;
        }
    }

    public void Guardar()
    {
        naveSeleccionada = posActual;
    }

    public void playConSeleccion()
    {
        //naves[naveSeleccionada].SetActive(true);
    }

    public int getNaveSeleccionada()
    {
        return naveSeleccionada;
    }
}
