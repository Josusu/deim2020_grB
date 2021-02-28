using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour
{

    public GameObject panelPause;
    public Text record;

    public static bool pausa = false;

    NaveCollider naveCollider;
    SpaceshipMove spaceshipMove;
    Play play;
    [SerializeField] GameObject[] naves;

    // Start is called before the first frame update
    void Start()
    {
        spaceshipMove = GameObject.Find("Naves").GetComponent<SpaceshipMove>();
        panelPause.SetActive(false);
        play = GameObject.Find("Naves").GetComponent<Play>();
        naves = play.getNaves();
        naveCollider = naves[play.getNaveSeleccionada()].GetComponent<NaveCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausa)
            {
                
                mostrarPause();
            }
            else
            {
                resume();
            }
        }
    }

    public void mostrarPause()
    {
        
        pausa = true;
        //Quita el texto de la distancia
        spaceshipMove.TextDistance.text = "";
        //Quita la vida
        naveCollider.vidaBackground.SetActive(false);
        naveCollider.vidaFill.SetActive(false);
        //Activa el panel
        panelPause.SetActive(true);
        //Sale el record text con la distancia ultima registrada
        record.text = "RECORD: " + spaceshipMove.distance;
        Time.timeScale = 0f;
    }
    
    public void resume()
    {
        //Quita el texto de la distancia
        spaceshipMove.TextDistance.text = "Distancia: " + spaceshipMove.distance;
        //Quita la vida
        naveCollider.vidaBackground.SetActive(true);
        naveCollider.vidaFill.SetActive(true);
        //Activa el panel
        panelPause.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }
}
