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
    public int vidas = 3, distance = 0 ;

    //Variables para quitar la vida y la distancia de la pantalla cuando pierdes
    public GameObject vidaBackground;
    private GameObject vidaFill;

    //Variables para aparecer el panel restart y el record
    public GameObject panelRestart;
    public Text record;

    //Variables para determinar el espacio de movimiento
    private Transform theObject;
    public Vector2 hRange = Vector2.zero;
    public Vector2 vRange = Vector2.zero;

    //variable que determina si estoy en los márgenes
    //bool inMarginMove = true;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;

    //Variables para las animaciones
    [SerializeField] Animator anim, vidaAnim;

    
    //Variable bool para que el objeto parpadee solo cuando se choque
    bool parpadeo = false;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        StartCoroutine("Velocidad");
        theObject = GetComponent<Transform>();

        //variable gameObjecto = al game object llamado VidaFill
        vidaFill = GameObject.Find("VidaFill");

        //variable Animator = al animator del gameObject vidaFill
        vidaAnim = vidaFill.GetComponent<Animator>();

        //Al iniciar el panel restart estara apagado
        panelRestart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        //Dependiendo del numero de vidas
        if(vidas != 0)
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
        while(vidas!=0)
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
        while (true)
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

        //Restringimos los limites de la pantalla
        theObject.position = new Vector3(

            Mathf.Clamp(transform.position.x, hRange.x, hRange.y),
            Mathf.Clamp(transform.position.y, vRange.x, vRange.y)
            );

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

        
    }

    //Metodo para la colision de la nave con las columnas
     private void OnCollisionEnter(Collision collision)
    {
        //Si se choca con un gameObject con el tag obstacle
       if(collision.gameObject.tag == "obstacle")
        {

            //Le disminuye una vida
            vidas--;
            //Realiza la animacion de cuando se baja una vida
            vidaAnim.SetInteger("vidas", vidas);
            //Baja la velocidad de la nave un 50% de la que tenia
            speed = (float)(speed * 0.5);
            //Llama a la funcion parpadear
            parpadear();
            //Invoca al metodo parpadear por 2segundos
            Invoke("parpadear", 2f);
            //Si la vida es igual a 0 
            if(vidas == 0)
            {
                //Invocamos el panel restart a los 2 segundos
                Invoke("mostrarRestart", 2f);
            }
        } 
    }

    //Metodo de parpadeo de la nave
    private void parpadear()
    {
        //La variable es falsa por lo que la igualamos a su contrario, true para ver la anim
        parpadeo = !parpadeo;
        //Habilita la animacion de parpadeo
        anim.enabled = parpadeo;
    }

    //Metodo para activar el panel restart
    private void mostrarRestart()
    {
        //Quita el texto de la distancia
        TextDistance.text = "";
        //Quita la vida
        vidaBackground.SetActive(false);
        vidaFill.SetActive(false);
        //Activa el panel
        panelRestart.SetActive(true);
        //Sale el record text con la distancia ultima registrada
        record.text = "RECORD:" + distance;
    }
}
