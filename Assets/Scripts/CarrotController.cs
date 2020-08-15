using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{

    Animator carrots;

    public static bool burnedCarrots;
    public static bool fireCarrots;

    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        smoke.Pause();
        carrots = gameObject.GetComponent<Animator>();
        carrots.SetBool("IsBurning", false);
        burnedCarrots = false;
        fireCarrots = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Todos los casos donde las zanahorias se quemarán

        if (Collider.acid == true && Collider.carrots == true)
        {
            //smoke.Play() son las particulas de humo
           smoke.Play();
           carrots.SetBool("IsBurning", true);
           burnedCarrots = true;

        }

        if(CupcakeController.cupcakeDead == true && Collider.acid == true && Collider.carrots == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;
        }

        if (Collider.acidWin == true && Collider.carrotExtra == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;

        }

        if (Collider.acidWin == true && Collider.carrotWin == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;

        }

        if(Collider.acid == true && Collider.carrotExtra == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;
        }

        if(Collider.carrotFire == true && Collider.acidWin == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;
        }

        if(fireCarrots == true && Collider.carrotFire == true)
        {
            smoke.Play();
            carrots.SetBool("IsBurning", true);
            burnedCarrots = true;
        }
     

    }

 
}
