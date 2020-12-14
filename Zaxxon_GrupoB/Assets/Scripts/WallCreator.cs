using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{

    public GameObject Pared;
    public Transform IniPos;

    public GameObject Nave;
    private SpaceshipMove spaceshipMove;

    public int distanciaInicial;
    
    private float speed, cooldown;

    // Start is called before the first frame update
    void Start()
    {
        for(int n = 1; n <= 17; n++)
        {
            float z = IniPos.position.z - (n * 10);
            Vector3 FinalPos = new Vector3(IniPos.position.x, IniPos.position.y, z);
            Instantiate(Pared, FinalPos, Quaternion.identity);
        }
        
        StartCoroutine("InstanciadorPared");
        spaceshipMove = Nave.GetComponent<SpaceshipMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spaceshipMove.vidas != 0)
        {
            speed = spaceshipMove.speed;
        } else
        {
            StopCoroutine("InstanciadorPared");

        }
    }


    void CrearPared()
    {
        Vector3 FinalPos = IniPos.position;
        Instantiate(Pared, FinalPos, Quaternion.identity);
    }

    IEnumerator InstanciadorPared()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearPared();

            //Relacin entre la velocidad de la nave y el tiempo para instanciar columnas
            cooldown = 1f - (speed * 0.06f);
            
            
            yield return new WaitForSeconds(cooldown);
        }

    }
}
