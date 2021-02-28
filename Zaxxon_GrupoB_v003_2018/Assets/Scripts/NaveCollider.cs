using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveCollider : MonoBehaviour
{
    [SerializeField] GameObject naves;
    SpaceshipMove spaceshipMove;

    //Variables para las animaciones
    public GameObject vidaBackground;
    public GameObject vidaFill;

    public int vidas = 3;

    public GameObject panelRestart;
    public Text record;

    //Variable bool para que el objeto parpadee solo cuando se choque
    bool parpadeo = false;

    [SerializeField] Text TextDistance;


    [SerializeField] Animator anim, vidaAnim;

    public GameObject explosion;

    public DatabaseController databaseController;

    private MeshRenderer myMesh;
    private CapsuleCollider myCollider;

    public AudioSource explosionSource;
    public AudioClip explosionClip;
    public AudioSource startMSource;
    public AudioClip startMClip;

    private bool tiempoChoque = true;

    // Start is called before the first frame update
    void Start()
    {
        startMSource = GameObject.Find("musicGame").GetComponent<AudioSource>();
        explosionSource = GameObject.Find("sonidoExplosion").GetComponent<AudioSource>();

        myMesh = GetComponent<MeshRenderer>();
        myCollider = GetComponent<CapsuleCollider>();
        spaceshipMove = GameObject.Find("Naves").GetComponent<SpaceshipMove>();

        //variable gameObjecto = al game object llamado VidaFill
        vidaFill = GameObject.Find("VidaFill");

        //variable Animator = al animator del gameObject vidaFill
        vidaAnim = vidaFill.GetComponent<Animator>(); 

        panelRestart.SetActive(false);

        gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si se choca con un gameObject con el tag obstacle
        if (collision.gameObject.tag == "obstacle")
        {
            if (tiempoChoque)
            {
                //Le disminuye una vida
                StartCoroutine("quitarVida");
                //Realiza la animacion de cuando se baja una vida
                vidaAnim.SetInteger("vidas", vidas);
                //Baja la velocidad de la nave un 50% de la que tenia
                spaceshipMove.speed = (float)(spaceshipMove.speed * 0.5);
                //Llama a la funcion parpadear
                parpadear();
                //Invoca al metodo parpadear por 2segundos
                Invoke("parpadear", 2f);
                //Si la vida es igual a 0 
                if (vidas == 0)
                {
                    spaceshipMove.speed = 0;
                    //Invocamos el panel restart a los 2 segundos
                    Invoke("mostrarRestart", 2f);
                    explosionSource.PlayOneShot(explosionClip);
                    databaseController.colocarPuntuacion(spaceshipMove.distance);
                    Instantiate(explosion, transform.position, Quaternion.identity);
                    myMesh.enabled = false;
                    myCollider.enabled = false;
                    StartCoroutine(FadeOut(0.3f));
                }
            }
        }
    }

    IEnumerator quitarVida()
    {
        tiempoChoque = false;
        vidas--;

        yield return new WaitForSeconds(1f);

        tiempoChoque = true;

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
        spaceshipMove.TextDistance.text = "";
        //Quita la vida
        vidaBackground.SetActive(false);
        vidaFill.SetActive(false);
        //Activa el panel
        panelRestart.SetActive(true);
        //Sale el record text con la distancia ultima registrada
        record.text = "RECORD: " + spaceshipMove.distance;
    }


     IEnumerator FadeOut(float FadeTime)
    {
        float startVolume = startMSource.volume;

        while (startMSource.volume > 0)
        {
            startMSource.volume -= startVolume * Time.deltaTime;

            yield return null;
        }

        //startMSource.Stop();
        startMSource.volume = FadeTime;
    }
}
