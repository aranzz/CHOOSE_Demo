using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhasController : MonoBehaviour
{

    Animator piranhas;
    Animator lampAnim;

    public GameObject lamp;

    float cont;

    public static bool attacking;
    public static bool dead;

    bool start = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //Contiene un animator que controla la lampara y otro que controla las pirañas

        cont = 0;
        start = false;
        piranhas = gameObject.GetComponent<Animator>();
        lampAnim = lamp.GetComponent<Animator>();
        lampAnim.SetBool("IsDestroyed", false);
        piranhas.SetBool("IsDying", false);
        piranhas.SetBool("IsAttacking", false);
        attacking = false;
        dead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Collider.lamp == true)
        {
            //Si la lampara es destruida, los enemigos morirán
            start = true;
            lampAnim.SetBool("IsDestroyed", true);

        }
        
        if(start)
        {
            //Enemigos esperan 2 segundos para correr animación de muerte
            cont += Time.deltaTime;

            if (cont >= 2)
            {
                piranhas.SetBool("IsDying", true);
                attacking = false;
                dead = true;
                cont = 0;
                start = false;
            }
        }


        if(Door.opened && dead == false)
        {
            attacking = true;
            piranhas.SetBool("IsAttacking", true);
        }
    }
}
