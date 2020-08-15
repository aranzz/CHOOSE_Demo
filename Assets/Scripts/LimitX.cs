using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitX : MonoBehaviour
{

    public float limitXMax;
    public  float limitXMin;

    public bool changeLimit;

    public float newLimitMin;
    public float newLimitMax;

    public GameObject changeLimitBar;

    public static bool changed;

    void Start()
    {
        changed = false; 
    
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Para cambiar el limite de otra barra y simular le bloqueo
        if (changeLimit)
        {
            if (other.tag == "ChangeLimit")
            {
                changeLimitBar.GetComponent<LimitX>().limitXMax = newLimitMax;
                changeLimitBar.GetComponent<LimitX>().limitXMin = newLimitMin;
                changed = true;


            }
        }
      

    }

    // Update is called once per frame
    void LateUpdate()
    {
            Vector3 pos = transform.position;

            pos.x = Mathf.Clamp(pos.x, limitXMin, limitXMax);

            transform.position = pos;
        
    }


 }
