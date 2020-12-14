using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    //Metodo para cambiar de escena
    public void iniciarJuego()
    {
        SceneManager.LoadScene("zaxxon_scene4");
    }
}
