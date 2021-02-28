using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu, select, options, highScore;

    private void Start()
    {
        select.SetActive(false);
        options.SetActive(false);
        highScore.SetActive(false);
    }

    //Metodo para cambiar de escena
    public void iniciarJuego()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoSelect()
    {
        select.SetActive(true);
        highScore.SetActive(false);
        menu.SetActive(false);
    }

    public void GoOptions()
    {
        options.SetActive(true);
        highScore.SetActive(false);
        menu.SetActive(false);
    }

    public void GoMenu()
    {
        options.SetActive(false);
        select.SetActive(false);
        highScore.SetActive(false);
        menu.SetActive(true);
    }
    public void GoHighScore()
    {
        highScore.SetActive(true);
        options.SetActive(false);
        select.SetActive(false);
        menu.SetActive(false);
    }
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("saliendo");
    }
}