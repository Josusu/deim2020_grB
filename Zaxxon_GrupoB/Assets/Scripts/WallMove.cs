using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private float paredSpeed;

    public GameObject SpaceShip;
    SpaceshipMove spaceshipMove;

    // Start is called before the first frame update
    void Start()
    {
        SpaceShip = GameObject.Find("Spaceship");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();
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
            paredSpeed = spaceshipMove.speed * 1f;
            transform.Translate(Vector3.back * Time.deltaTime * paredSpeed);

        }

    }
}
