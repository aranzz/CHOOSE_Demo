using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobController : MonoBehaviour
{

    bool dragging;

    float rotz ;
    float sensitivity = 15f;

    public GameObject fire;

    public static bool opened = false;

    public bool isOn;
    public bool burnCarrots;
    public bool burnBunny;
    public bool burnCupcake;

    public bool fireOn;

    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        //Si el Knob inicia encendido o apagado
        alpha = fire.GetComponent<SpriteRenderer>().color;
        if (fireOn)
        {
            alpha.a = 4;
            rotz = 90;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 90 );
            opened = true;
            isOn = true;
        }
        else
        {
          
            alpha.a = 0;
            rotz = 0;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
            opened = false;
            isOn = false;
        }
      
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;

    }


    // Update is called once per frame
    void Update()
    {

        if (dragging)
        {
             rotz += Input.GetAxis("Mouse Y") * sensitivity;
             rotz = Mathf.Clamp(rotz, 0, 90);
             transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotz);
        }

        if (rotz <= 20)
        {

            //Knob cerrado
            opened = false;
            isOn = false;
            alpha.a -= Time.deltaTime*6;

            //El alpha simulará el fuego apagado o prendido
           if(alpha.a <= 0)
            {
                alpha.a = 0;
            }
           

            if (burnCarrots == true)
            {
                CarrotController.fireCarrots = false;
                CupcakeController.fireCupcake = false;
                
            }

        }

        if (rotz >= 70)
        {
            //Knob abierto

            opened = true;
            isOn = true;
            alpha.a += Time.deltaTime*3;

            //El alpha simulará el fuego apagado o prendido
            if (alpha.a >= 4)
            {
                alpha.a = 4;
            }

            if(burnCarrots == true)
            {
                CarrotController.fireCarrots = true;
            }
            if (burnCupcake == true)
            {
                CupcakeController.fireCupcake = true;
            }
            if (burnBunny == true)
            {
                BunnyController.fireBunny = true;
                BunnyHangingController.fireBunny = true;
            }

        }
        
        fire.GetComponent<SpriteRenderer>().color = alpha;

    }
}
