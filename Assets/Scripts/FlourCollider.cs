using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourCollider : MonoBehaviour
{

    //  public bool flourDetector;
    // public bool acidDetector;

    bool acid;
    bool flour;

    public static bool disappear;

    public GameObject acidParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        disappear = false;
        acid = false;
        flour = false;
    }

    // Update is called once per frame


    void Update()
    {
        if(acid && flour)
        {
           // Debug.Log("Los 2");
            disappear = true;
            
            //acidParticles.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.tag == "Acid")
            {
              //  Debug.Log("Acid");
                  acid = true;

            }
       
            if (other.tag == "Flour")
            {
              // Debug.Log("Flour");
                 flour = true;

            }


       



    }


}
