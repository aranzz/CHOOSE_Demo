using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeController : MonoBehaviour
{

    Animator cupcake;

    public static bool cupcakeDead;
    public static bool fireCupcake;

    public bool door;
    public bool deleteCollider;
    public bool attack;

    public GameObject colliderToDelete;

   

    
    // Start is called before the first frame update
    void Start()
    {
        fireCupcake = false;
        cupcake = gameObject.GetComponent<Animator>();
        cupcakeDead = false;
        cupcake.SetBool("IsDying", false);
        cupcake.SetBool("IsAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
       //Si el cupcake se encuentra en un lugar con ácido, morirá y desaparecerá junto con su collider
        if (Collider.acidWin == true && Collider.cupcake == true)
        {
            
            cupcake.SetBool("IsDying", true);
            if(deleteCollider)
            {
                colliderToDelete.SetActive(false);
             
            }
          
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2 (2,2);
            
            cupcakeDead = true;

        }

        if(attack)
        {
            if (LimitY.play == true)
            {

                cupcake.SetBool("IsAttacking", true);


            }
        }
   
        //Si el cupcake se encuentra encima de un knob y esta encendido
        if(fireCupcake == true && Collider.cupcake == true)
        {
            cupcake.SetBool("IsDying", true);
            cupcakeDead = true;
        }

        
        if(door)
        {
            if (Door.opened && Collider.cupcake)
            {
               
                cupcake.SetBool("IsAttacking", true);
            }
        }
     

    }
}
