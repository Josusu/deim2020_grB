using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject[] Obstaculos;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber, randomNumber1, speed, cooldown;
    Vector3 RandomPos;

    //Variables para asociarse con un gameObject y un Script de ese gameObject
    [SerializeField] GameObject[] naves;
    Play play;
    private SpaceshipMove spaceshipMove;
    private GameObject SpaceShip;

    private NaveCollider naveCollider;

    private int distance;

    private int valorMaximo;


    //distancia a la que se crean las columnas iniciales
    [SerializeField] int distanciaInicial;
    
    // Start is called before the first frame update
    void Start()
    {

        

        //Lanzo la corrutina
        

        //Busco dentro del gameObject un script suyo
        play = GameObject.Find("Naves").GetComponent<Play>();
        naves = play.getNaves();
        
        spaceshipMove = GameObject.Find("Naves").GetComponent<SpaceshipMove>();
        naveCollider = naves[play.getNaveSeleccionada()].GetComponent<NaveCollider>();

        StartCoroutine("InstanciadorColumnas");

        for (int n = 1; n <= 15; n++)
        {
            CrearColumna(-n * distanciaInicial);
        }
    }

    private void Update()
    {
        //Velocidad instanciador de columnas dependiendo de las vidas
        if(spaceshipMove.vidas != 0)
        {
            speed = spaceshipMove.speed;
        } else
        {
            StopCoroutine("InstanciadorColumnas");

        }
        
    }


    //Función que crea una columna en una posición Random
    void CrearColumna(float posZ = 0f)
    {
        
        if (spaceshipMove.distance < 500)
        {
            valorMaximo = 2;
        }else if (spaceshipMove.distance > 500 && spaceshipMove.distance < 1000)
        {
            valorMaximo = 3;
        }
        else if (spaceshipMove.distance > 1000 && spaceshipMove.distance < 1500)
        {
            valorMaximo = 4;
        }
        else if (spaceshipMove.distance > 1500 && spaceshipMove.distance < 2000)
        {
            valorMaximo = 5;
        }
        else if (spaceshipMove.distance > 2000 && spaceshipMove.distance < 2500)
        {
            valorMaximo = 6;
        }
        else if (spaceshipMove.distance > 2500 && spaceshipMove.distance < 3000)
        {
            valorMaximo = 7;
        }
        else if (spaceshipMove.distance > 3000)
        {
            valorMaximo = 8;
        }
        int randomObstaculos = Random.Range(0, valorMaximo);
        randomNumber = Random.Range(-3f, 7f);
        randomNumber1 = Random.Range(1f, 4.5f);
        RandomPos = new Vector3(randomNumber, randomNumber1, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Obstaculos[randomObstaculos], FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna(0);

            //Relacin entre la velocidad de la nave y el tiempo para instanciar columnas
            cooldown = 1f - (speed * 0.05f);
            
            
            yield return new WaitForSeconds(cooldown);
        }

    }

    
}
