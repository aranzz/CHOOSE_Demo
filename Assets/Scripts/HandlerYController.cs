using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerYController : MonoBehaviour
{

    private bool dragging;

    Vector2 initialPos;

    public GameObject handleOpt1;
   

    public static bool opt1;
   

    public GameObject bloquedBarY;

    public GameObject handlerCollider;



    void Start()
    {
        handlerCollider.SetActive(true);
        (bloquedBarY.GetComponent("MoveBarsY") as MonoBehaviour).enabled = false;
        initialPos = gameObject.transform.position;
        handleOpt1.SetActive(false);
    
        opt1 = false;
      
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

        if (dragging == false && opt1 == true)
        {
            //Bloquea el movimiento de la barra hasta que se le ponga un Handler

            handlerCollider.SetActive(false);
            handleOpt1.SetActive(true);
            (bloquedBarY.GetComponent("MoveBarsY") as MonoBehaviour).enabled = true;
           
            gameObject.SetActive(false);

        }

   
    }

    //Para que el jugador pueda mover libremente el Handler

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Handle1")
        {
            opt1 = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Handle1")
        {
            opt1 = false;

        }

    }
}