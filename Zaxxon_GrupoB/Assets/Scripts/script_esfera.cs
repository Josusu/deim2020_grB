using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class script_esfera : MonoBehaviour
{

    private float speed;

    //public script_cubo ClaseCubo;

    public GameObject Cubo;
    private script_cubo ClaseCubo;
    

    // Start is called before the first frame update
    void Start()
    {
        ClaseCubo = Cubo.GetComponent<script_cubo>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = ClaseCubo.getSpeed() / 2;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        print(ClaseCubo.getSpeed());
        ClaseCubo.SendMessage("UpdateText", speed.ToString());
    }
}
