using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pruebas : MonoBehaviour
{

    public float speed;

    public int vidas = 3, distance = 0;

    [SerializeField] Text TextDistance;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;

        StartCoroutine("Velocidad");
        StartCoroutine("Distancia");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Distancia()
    {
        distance = 0;

        //Bucle infinito que suma 10*velocidad de la nave
        //Depende del numero de vidas
        while (vidas != 0)
        {
            distance += (int)(10 * speed);
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + distance;

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);
        }

    }

    IEnumerator Velocidad()
    {

        //Bucle infinito mientras sea verdad
        for (int n = 0; ; n++)
        {
            //Limite hasta 20 y va sumando 0.1 cada segundo
            if (speed < 20)
            {
                speed += 0.1f;
            }
            //Ejecuto cada ciclo esperando 1 segundo
            print("Speed " + n + ": " + speed);
            yield return new WaitForSeconds(1f);
        }

    }
}
