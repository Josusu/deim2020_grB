using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_cubo : MonoBehaviour
{

    private float speed;

    [SerializeField] Text SpeedText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float getSpeed()
    {
        return speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        
    }

    public void UpdateText(string pesco)
    {
        SpeedText.text = pesco;
    }
}
