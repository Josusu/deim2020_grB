using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    [SerializeField] Transform Target;
    Vector3 camaraVelocity = Vector3.zero;
    [SerializeField] float smoothVelocity = 0.1f;

    [SerializeField] GameObject[] naves;
    Play play;
    int naveSeleccionada;

    // Start is called before the first frame update
    void Start()
    {
        play = GameObject.Find("Naves").GetComponent<Play>();
        naves = play.getNaves();
        Invoke("setTarget",0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y + 0.2f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }

    public void setTarget()
    {
        Debug.Log(play.getNaveSeleccionada());
        Target = naves[play.getNaveSeleccionada()].GetComponent<Transform>();
    }
}
