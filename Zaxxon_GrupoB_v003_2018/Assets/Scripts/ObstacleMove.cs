  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    //Creamos la variable a la que se moverá el obtáculo
    //Este valor deberá depender de la velocidad de la nave
    private float obstacleSpeed;

    
    SpaceshipMove spaceshipMove;

    [SerializeField] GameObject[] naves;
    Play play;

    // Start is called before the first frame update
    void Start()
    {
        play = GameObject.Find("Naves").GetComponent<Play>();
        naves = play.getNaves();
        
        spaceshipMove = GameObject.Find("Naves").GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {

        //Deja de desplazar columnas dependiendo de las vidas
        if(spaceshipMove.vidas != 0)
        {
            //Comprobamos si la instancia ha rebasado a la nave y la destruimos
            //NOTA: habría que pasar esto a una CORRUTINA para consumir menos recursos
            float PosZ = transform.position.z;
            if (PosZ < -12)
            {
                Destroy(gameObject);
            }

            //Asignamos una velocidad fija (de momento)
            obstacleSpeed = spaceshipMove.speed * 2.5f;
            transform.Translate(Vector3.back * Time.deltaTime * obstacleSpeed);

        }

    }
}
