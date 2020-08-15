using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleController : MonoBehaviour
{

    private bool dragging;

    Vector2 initialPos;

    public GameObject handleOpt1;
    public GameObject handleOpt2;

    public static bool opt1;
    public static bool opt2;

    public GameObject bloquedBarX;

    public float minLimitOpt1;
    public float maxLimitOpt1;
    public float minLimitOpt2;
    public float maxLimitOpt2;



    public GameObject handlerCollider1;
    public GameObject handlerCollider2;

    void Start()
    {
        handlerCollider1.SetActive(true);
        handlerCollider2.SetActive(true);
        (bloquedBarX.GetComponent("MoveBarsX") as MonoBehaviour).enabled = false;
        initialPos = gameObject.transform.position;
        handleOpt1.SetActive(false);
        handleOpt2.SetActive(false);
        opt1 = false;
        opt2 = false;
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        transform.localPosition = initialPos;

    }


    void Update()
    {
        if (dragging)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.localPosition = new Vector2(pos.x, pos.y);

        }

        //Permite mover la barra dependiendo de dónde se ponga el Handler
        if(dragging == false && opt1 == true)
        {
            handlerCollider2.SetActive(false);
            handlerCollider1.SetActive(false);
            handleOpt1.SetActive(true);
            (bloquedBarX.GetComponent("MoveBarsX") as MonoBehaviour).enabled = true;
            bloquedBarX.GetComponent<LimitX>().limitXMin = minLimitOpt1;
            bloquedBarX.GetComponent<LimitX>().limitXMax = maxLimitOpt1;
            gameObject.SetActive(false);

        }

        if (dragging == false && opt2 == true)
        {
            handlerCollider2.SetActive(false);
            handlerCollider1.SetActive(false);
            handleOpt2.SetActive(true);
            (bloquedBarX.GetComponent("MoveBarsX") as MonoBehaviour).enabled = true;
             bloquedBarX.GetComponent<LimitX>().limitXMin = minLimitOpt2;
             bloquedBarX.GetComponent<LimitX>().limitXMax = maxLimitOpt2;
            gameObject.SetActive(false);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.tag == "Handle1")
            {
                opt1 = true;
              
            }
          
            

            if (other.tag == "Handle2")
            {

            opt2 = true;
              
            }
         
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Handle1")
        {
            opt1 = false;
            
        }



        if (other.tag == "Handle2")
        {

            opt2 = false;
        
        }

    }
}