using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    private Transform theObject;
    public Vector2 hRange = Vector2.zero;
    public Vector2 vRange = Vector2.zero;

    //variable que determina si estoy en los márgenes
    //bool inMarginMove = true;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;


    
    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        theObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 10)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n;

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);
        }
        
    }



    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");


        theObject.position = new Vector3(

            Mathf.Clamp(transform.position.x, hRange.x, hRange.y),
            Mathf.Clamp(transform.position.y, vRange.x, vRange.y)
            );

        

        /*float myPosX = transform.position.x;
        float myPosY = transform.position.y;

        if(myPosX <= -4.5 && desplX < 0)
        {
            inMarginMove = false;
        }

        else if(myPosX >= 4.5 && desplX > 0)
        {
            inMarginMove = true;
        }

        if (inMarginMove == true)
        {
            

        }*/

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);



    }
}
