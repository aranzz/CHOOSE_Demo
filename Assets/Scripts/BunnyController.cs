using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    Animator bunnyAnim;

    bool idle;
    bool happy;

    public static bool win;
    public static bool fireBunny;

    public bool door;
    public bool smoke;
    public bool piranhas;
    public bool lvl1;
    public bool knob;

    public ParticleSystem smokeParticles;

    public static bool success;
    public static bool fail;

  

    // Start is called before the first frame update
    void Start()
    {
        success = false;
        fail = false;
        win = false;

        if (smoke)
        {
            smokeParticles.Pause();
        }

        fireBunny = false;
        bunnyAnim = gameObject.GetComponent<Animator>();
        bunnyAnim.SetBool("IsWorried", false);
        bunnyAnim.SetBool("IsSad", false);
        bunnyAnim.SetBool("IsHappy", false);
        bunnyAnim.SetBool("Win", false);
        bunnyAnim.SetBool("IsDying", false);
        bunnyAnim.SetBool("IsScreaming", false);
       

    }

    // Update is called once per frame
    void Update()
    {
        Animations();

       
    }

    void Animations()
    {
        
        //para ganar - detecta zanahorias en collider donde deben estar zanahorias
        if (Collider.carrotWin == true)
        {
           // Debug.Log("esta aqui");
            bunnyAnim.SetBool("IsHappy", true);


            if (Door.opened == true) //&& Master.Win gana el nivel si solo zanahorias estan ahi 
            {
                bunnyAnim.SetBool("Win", true);
                win = true; //bloquear movimientos
                success = true;
            }

            if (Collider.carrotExtra)
            {
                bunnyAnim.SetBool("Win", true);
                success = true;
            }

            //para perder - detecta acido en el collider en el que deben estar las zanahorias

            if (Collider.acidWin == true)
            {
                bunnyAnim.SetBool("IsHappy", false);
                bunnyAnim.SetBool("IsSad", true);
                fail = true;

                if (Collider.bunny == true)
                {

                    //si acido y bunny estan en el mismo collider, muere
                    bunnyAnim.SetBool("IsSad", false);
                    bunnyAnim.SetBool("IsWorried", false);
                    bunnyAnim.SetBool("IsDying", true);
                    fail = true;
                }
            }
        }


        //detecta si hay acido en cualquier collider
        if (Collider.acid == true || Collider.acidWin == true)
        {
         
            bunnyAnim.SetBool("IsWorried", true);

            if (CupcakeController.cupcakeDead)
            {
                bunnyAnim.SetBool("IsWorried", false);
               // Collider.acid = false;
            }

            //si hay zanahorias en cualquier collider donde tambien hay acido
            if (Collider.carrots == true && Collider.carrotWin)
            {
                bunnyAnim.SetBool("IsWorried", false);
                bunnyAnim.SetBool("IsSad", true);
                fail = true;
            }

            if (Collider.bunny == true)
            {
                
                //si acido y bunny estan en el mismo collider, muere
                bunnyAnim.SetBool("IsWorried", false);
                bunnyAnim.SetBool("IsDying", true);
                fail = true;
            }
        }

     

        if(AcidController.disappear == true)
        {
            bunnyAnim.SetBool("IsWorried", false);
            bunnyAnim.SetBool("IsSad", false);
           
        }

      if(Collider.acidExtra == true && Collider.bunnyExtra)
        {
            bunnyAnim.SetBool("IsWorried", false);
            bunnyAnim.SetBool("IsSad", false);
            bunnyAnim.SetBool("IsDying", true);
            fail = true;
        }
       
   
       if(CarrotController.burnedCarrots == true)
        {
            Collider.carrotWin = false;
            bunnyAnim.SetBool("IsHappy", false);
            bunnyAnim.SetBool("IsSad", true);
            bunnyAnim.SetBool("IsWorried", false);
            bunnyAnim.SetBool("Win", false);
            fail = true;

        }

  



       //Para el nivel que tiene a los enemigos piranhas
        if(piranhas == true)
        {

            if (LimitY.play == true || PiranhasController.attacking == true)
            {
                bunnyAnim.SetBool("IsScreaming", true);
                fail = true;

            }

            if (PiranhasController.dead == true)
            {
               // Debug.Log("esta aqui");

                bunnyAnim.SetBool("IsHappy", true);

                if (Door.opened && Collider.carrotExtra == true)
                {
                    // Debug.Log("WIIIN");
                    bunnyAnim.SetBool("IsHappy", false);
                    bunnyAnim.SetBool("Win", true);
                    success = true;
                }

            }
        }

        
       
        //Si el conejo esta sobre Knob y el fuego de Knob está encendido, morirá
        if(fireBunny == true && Collider.bunny)
        {
            if(smoke)
            {
                smokeParticles.Play();
                bunnyAnim.SetBool("IsDying", true);
                fail = true;
            }
           
        }

        //Si el nivel tiene puerta
        if(door)
        {
            if (CupcakeController.cupcakeDead == false && Door.opened == true && Collider.cupcake == true)
            {
                bunnyAnim.SetBool("IsScreaming", true);
                fail = true;
            }

        }
        if (CupcakeController.cupcakeDead == true && CarrotController.burnedCarrots == false)
        {
            bunnyAnim.SetBool("IsHappy", true);
            // Debug.Log("esta aqui");
            if (LimitY.changed2 == true && Collider.carrotExtra == true)
            {

                bunnyAnim.SetBool("Win", true);
                success = true;
            }

            if (LimitY.changed2 == true && Collider.extraMoveCarrot == true)
            {

                bunnyAnim.SetBool("Win", true);
                success = true;
            }
          
            if (CarrotController.burnedCarrots == true)
            {
                bunnyAnim.SetBool("IsHappy", false);
                bunnyAnim.SetBool("Win", false);
                bunnyAnim.SetBool("IsSad", true);
                fail = true;
            }


            if (door)
            {
                if (Door.opened)
                {
                    if (Collider.carrotFire)
                    {
                        bunnyAnim.SetBool("Win", true);
                        success = true;
                    }
                }

            }


        }

        //Niveles con el enemigo cupcake

        if (lvl1 == false)
        {
            if (LimitY.play == true && CupcakeController.cupcakeDead == false)
            {
                bunnyAnim.SetBool("IsScreaming", true);
                fail = true;

            }

            if (CupcakeController.cupcakeDead == true && CarrotController.burnedCarrots == false)
            {
                bunnyAnim.SetBool("IsHappy", true);
               // Debug.Log("esta aqui");
                if (LimitY.changed2 == true && Collider.carrotExtra == true)
                {

                    bunnyAnim.SetBool("Win", true);
                    success = true;
                }

                if (LimitY.changed2 == true && Collider.extraMoveCarrot == true)
                {

                    bunnyAnim.SetBool("Win", true);
                    success = true;
                }
              

                if (CarrotController.burnedCarrots == true)
                {
                    bunnyAnim.SetBool("IsHappy", false);
                    bunnyAnim.SetBool("Win", false);
                    bunnyAnim.SetBool("IsSad", true);
                    fail = true;
                }


                if (door)
                {
                    if (Door.opened)
                    {
                        if (Collider.carrotFire)
                        {
                            bunnyAnim.SetBool("Win", true);
                            success = true;
                        }
                    }

                }


            }

        }
     
      

    }
}
