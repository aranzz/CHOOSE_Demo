using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHangingController : MonoBehaviour
{
    Animator bunnyH;
    public static bool fireBunny;

    bool fire1;
    bool fire2;

    public KnobController knob1;
    public KnobController knob2;

    public bool door;
    public bool smoke;

    public ParticleSystem smokeParticles;

    // Start is called before the first frame update
    void Start()
    {
        //Los mismos indicadores de Game Over y Win que BunnyController
        BunnyController.fail = false;
        BunnyController.success = false;

        if(smoke)
        {
            smokeParticles.Pause();
        }
     
        bunnyH = gameObject.GetComponent<Animator>();
        bunnyH.SetBool("IsMoving", false);
        bunnyH.SetBool("IsDying", false);
        bunnyH.SetBool("IsSad", false);
        bunnyH.SetBool("IsScreaming", false);
        bunnyH.SetBool("Win", false);
        fireBunny = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Corre animación de movimiento si el jugador está sujetando la barra
        if (MoveBarsX.isMoving == true)
        {
          
           bunnyH.SetBool("IsMoving", true);
        }else
        {
           
            bunnyH.SetBool("IsMoving", false);
        }

        //El conejo morirá si se encuentra en uno de los dos knobs respectivos
        if(fire1)
        {
            if (knob1.GetComponent<KnobController>().isOn == true)
            {
                if (smoke)
                {
                    smokeParticles.Play();
                    bunnyH.SetBool("IsDying", true);
                    BunnyController.fail = true;
                   
                }
                bunnyH.SetBool("IsDying", true);
                BunnyController.fail = true;
            }

        }

        if (fire2)
        {
            if (knob2.GetComponent<KnobController>().isOn == true)
            {
                if (smoke)
                {
                    smokeParticles.Play();
                    bunnyH.SetBool("IsDying", true);
                    BunnyController.fail = true;
                }
                bunnyH.SetBool("IsDying", true);
                BunnyController.fail = true;
            }
        }

        if(CarrotController.burnedCarrots == true)
        {
            bunnyH.SetBool("IsSad", true);
            BunnyController.fail = true;
        }
     
        if(LimitY.play == true && CupcakeController.cupcakeDead == false)
        {
            bunnyH.SetBool("IsScreaming", true);
            BunnyController.fail = true;
        }

        
        if(door)
        {
            if(Door.opened == true && CupcakeController.cupcakeDead == true )
            {
                if(LimitX.changed == true)
                {
                    bunnyH.SetBool("Win", true);
                    BunnyController.success = true;
                }
              
            }
        }
        
        

    }

    //Solo poner collliders con tag y los correspondientes knobs en el inspector
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag =="fire1")
        {
            fire1 = true;
        }
        else { fire1 = false; }

        if (other.tag == "fire2")
        {
            fire2 = true;
        }
        else { fire2 = false; }

        if(other.tag == "Carrot")
        {
            bunnyH.SetBool("Win", true);
            BunnyController.success = true;
        }

    }

}
