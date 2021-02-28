using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameObject musicaSonido;
    private GameObject elegirNave;
    PanelPause panelPause;

    private void Start()
    {
        musicaSonido = GameObject.Find("MusicaSonidos");
        panelPause = GameObject.Find("Canvas").GetComponent<PanelPause>();
    }

    //Metodo para cargar una escena
    public void restartScene()
    {
        panelPause.resume();
        SceneManager.LoadScene("Game");
    }
    public void goMenu()
    {
        panelPause.resume();
        Destroy(musicaSonido);
        SceneManager.LoadScene("Menu");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
