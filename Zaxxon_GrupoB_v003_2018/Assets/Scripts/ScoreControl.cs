using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public DatabaseController databaseController;

    int[] puntuaciones;
    public Text[] textScore;
    // Start is called before the first frame update
    void Start()
    {
        puntuaciones = databaseController.leerPuntuacion();
        for (int i = 0; i < textScore.Length; i++)
        {
            textScore[i].text = ""+ (i+1)+"    " + puntuaciones[i].ToString();
        }   
    }

}
