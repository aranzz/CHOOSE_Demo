using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitY : MonoBehaviour
{
    //Limite de movimmiento de barras

    public float limitYMax;
    public float limitYMin;


    public bool playAnimation = false;
    public bool changeLimit;
    

    public float newLimitMin;
    public float newLimitMax;

    public GameObject changeLimitBar;

    public static bool play;
    public static bool changed;
    public static bool changed2;

    void Start()
    {
        play = false;
        changed = false;
        changed2 = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Collider que permite cambiar el límite de otra barra y simular que ésta deja de ser bloqueada
        if (changeLimit)
        {

            if (other.tag == "ChangeLimit")
            {
                changed = true;
                changeLimitBar.GetComponent<LimitY>().limitYMax = newLimitMax;
                changeLimitBar.GetComponent<LimitY>().limitYMin = newLimitMin;
               
            }
        }

        if(other.tag =="Changed")
        {
            changed2 = true;
        }


        if (playAnimation && CupcakeController.cupcakeDead == false)
        {

            if (other.tag == "PlayAnimation")
            {
                
                play = true;
                
            }
            
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
      
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, limitYMin, limitYMax);
       
        transform.position = pos;


    }
}
