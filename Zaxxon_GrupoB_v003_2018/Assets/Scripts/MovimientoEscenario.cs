using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoEscenario : MonoBehaviour
{


    Renderer rend;
    private MeshRenderer renderPiso;
    private MeshRenderer renderTecho;
    private MeshRenderer renderMuroAbajoIzq;
    private MeshRenderer renderMuroArribaIzq;
    private MeshRenderer renderMuroAbajoDcho;
    private MeshRenderer renderMuroArribaDcho;

    SpaceshipMove spaceshipMove;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        spaceshipMove = GameObject.Find("Naves").GetComponent<SpaceshipMove>();



        renderPiso = GameObject.Find("Piso").GetComponent<MeshRenderer>();
        renderTecho = GameObject.Find("Techo").GetComponent<MeshRenderer>();
        renderMuroArribaIzq = GameObject.Find("MuroArribaIzquierdo").GetComponent<MeshRenderer>();
        renderMuroArribaDcho = GameObject.Find("MuroArribaDerecho").GetComponent<MeshRenderer>();
        renderMuroAbajoIzq = GameObject.Find("MuroAbajoIzquierdo").GetComponent<MeshRenderer>();
        renderMuroAbajoDcho = GameObject.Find("MuroAbajoDerecho").GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


        float offset = Time.time * spaceshipMove.speed/4;
        renderPiso.material.mainTextureOffset = new Vector2(0, -offset);
        renderTecho.material.mainTextureOffset = new Vector2(0, offset);
        renderMuroArribaIzq.material.mainTextureOffset = new Vector2(offset, 0);
        renderMuroArribaDcho.material.mainTextureOffset = new Vector2(-offset, 0);
        renderMuroAbajoIzq.material.mainTextureOffset = new Vector2(offset, 0);
        renderMuroAbajoDcho.material.mainTextureOffset = new Vector2(-offset, 0);

        if (spaceshipMove.vidas == 0)
        {
            spaceshipMove.speed = 0;
        }
    }
}
