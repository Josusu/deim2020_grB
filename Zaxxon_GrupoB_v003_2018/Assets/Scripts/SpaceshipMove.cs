using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    //Numero de vidas y la distancia recorrida
    public int vidas, distance = 0 ;

    //Variables para determinar el espacio de movimiento
    private Transform theObject;
    public Vector2 hRange = Vector2.zero;
    public Vector2 vRange = Vector2.zero;

    //Capturo el texto del UI que indicará la distancia recorrida
    public Text TextDistance;

    private NaveCollider naveCollider;

    [SerializeField] GameObject[] naves;
    Play play;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        //Llamo a la corrutina que hace aumentar la velocidad
        
        StartCoroutine("Velocidad");
        StartCoroutine("Distancia");
        theObject = GetComponent<Transform>();


        play = GameObject.Find("Naves").GetComponent<Play>();
        naves = play.getNaves(); 

        naveCollider = naves[play.getNaveSeleccionada()].GetComponent<NaveCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
            //Ejecutamos la función propia que permite mover la nave con el joystick
            //Dependiendo del numero de vidas
            vidas = naveCollider.vidas;
            if (vidas != 0)
            {
                MoverNave();
            }
    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        distance = 0;

        //Bucle infinito que suma 10*velocidad de la nave
        //Depende del numero de vidas
        while (vidas != 0)
        {
            distance += (int) (10 * speed);
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + distance;

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);
        }
        
    }

    IEnumerator Velocidad()
    {
        
        //Bucle infinito mientras sea verdad
        for(int n = 0; ; n++)
        {
            //Limite hasta 20 y va sumando 0.1 cada segundo
            if(speed < 20)
            {
                speed += 0.1f;
            }
            //Ejecuto cada ciclo esperando 1 segundo
            
            yield return new WaitForSeconds(1f);
        }

    }



    void MoverNave()
    {
        moveSpeed = speed + 3f;
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Restringimos los limites de la pantalla
        theObject.position = new Vector3(

            Mathf.Clamp(transform.position.x, hRange.x, hRange.y),
            Mathf.Clamp(transform.position.y, vRange.x, vRange.y)
            );

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

        //if (Input.GetKeyDown(KeyCode.X)) x = 1 - x;
        //if (Input.GetKeyDown(KeyCode.Y)) y = 1 - y;
        //if (Input.GetKeyDown(KeyCode.D) && z < 90) z = 1 + z;
        //if (Input.GetKeyDown(KeyCode.A) && z > -90) z = 1 - z;

        //currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        //transform.eulerAngles = currentEulerAngles;
    }
}
