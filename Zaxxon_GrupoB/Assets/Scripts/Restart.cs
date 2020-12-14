using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Metodo para cargar una escena
    public void restartScene()
    {
        SceneManager.LoadScene("zaxxon_scene3");
    }
    public void goMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
