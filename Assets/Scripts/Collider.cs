using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{

   public static bool carrots;
    public static bool carrotWin;
    public static bool acidWin;
    public static bool acid;
    public static bool bunny;
    public static bool bunnyExtra;
    public static bool carrotExtra;
    public static bool extraMoveCarrot;
    public static bool acidExtra;
    public static bool lamp;
    public static bool carrotFire;
    public static bool cupcake;


    public bool acidDetector = false;
    public bool carrotDetector = false;
    public bool acidWinDetector = false;
    public bool carrotWinDetector = false;
    public bool bunnyDetector = false;
    public bool bunnyDetectorExtra = false;
    public bool carrotDetectorExtra = false;
    public bool acidDetectorExtra = false;
    public bool extraMoveCarrotDetector = false;
    public bool lampDetector = false;
    public bool carrotFireDetector = false;
    public bool cupcakeDetector = false;


    // Start is called before the first frame update
    void Start()
    {


        carrots = false;
        carrotWin = false;
        carrotExtra = false;
        acidWin = false;
        acid = false;
        bunny = false;
        bunnyExtra = false;
        extraMoveCarrot = false;
        acidExtra = false;
        lamp = false;
        carrotFire = false;
        cupcake = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Solo si el bunny esta directamente en la posicion donde  caen zanahorias
        if(bunnyDetector)
        {
            if (other.tag == "Player")
            {
                bunny = true;
                Door.opened = true;
            }
        }

        //detector extra de acido
        if(acidDetectorExtra)
        {
            if (other.tag == "Acid")
            {
                acidExtra = true;
                
            }
        }

        //Para movimientos que necesiten mover una barra antes 
        if (extraMoveCarrotDetector)
        {
            //before bar
                if (other.tag == "Carrot")
                {
                    extraMoveCarrot = true;

                }
        }



        //Si el bunny no esta directamente en la posicion donde  caen zanahorias
        if (bunnyDetectorExtra)
        {
            if (other.tag == "Player")
            {
                bunnyExtra = true;
               
            }
        }

        //Solo detecta zanahorias
        if (carrotDetector)
        {
            if (other.tag == "Carrot")
            {
                carrots = true;
            }
        }

        //solo detecta acido
        if (acidDetector)
        {
            if (other.tag == "Acid")
            {
                acid = true;
            }
        }


        //colliders directos donde las zanahorias deben estar para ganar
        if (carrotWinDetector)
        {
            if (other.tag == "Carrot")
            {
                carrotWin = true;
            }
        }


        //Colllider de ayuda para niveles 
        if (carrotDetectorExtra)
        {
            if (other.tag == "Carrot")
            {
                carrotExtra = true;
            }
        }


        //Para el mimso lugar donde caen las zanahorias para ganar directamente
        if (acidWinDetector)
        {
            if (other.tag == "Acid")
            {
                acidWin = true;
            }
        }

        //Si el acido cae en la lampara
        if (lampDetector)
        {
            if (other.tag == "Acid")
            {
                lamp = true;
            }
        }

        //Si la zanahoria esta sobre un knob 
        if(carrotFireDetector)
        {
            if(other.tag == "Carrot")
            {
                carrotFire = true;
            }
        }

        //Detector de cupcake
        if (cupcakeDetector)
        {
            if (other.tag == "Enemy")
            {
                cupcake = true;
            }
        }
    }

}
