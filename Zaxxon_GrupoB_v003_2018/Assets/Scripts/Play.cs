using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject[] naves;
    ElegirNave naveScript;
    int naveSeleccionada;

    
    // Start is called before the first frame update
    void Start()
    {
        naveScript = GameObject.Find("SeleccionNave").GetComponent<ElegirNave>();
        CerrarSeleccion();
        naveSeleccionada = naveScript.getNaveSeleccionada();
        //Debug.Log(naveSeleccionada);
        naves[naveSeleccionada].SetActive(true);
    }
       
    public void CerrarSeleccion()
    {
        for (int i = 0; i < naves.Length; i++)
        {
            naves[i].SetActive(false);
        }
    }

    public GameObject[] getNaves()
    {
        return naves;
    }

    public int getNaveSeleccionada()
    {
        return naveSeleccionada;
    }

}
