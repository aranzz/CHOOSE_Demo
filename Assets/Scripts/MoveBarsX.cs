using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarsX : MonoBehaviour
{

    private bool dragging;

    //Vector2 initialPos;
    Vector3 pos;

    public static bool isMoving;

    float move;

    public string numberTag;


    private void OnMouseDown()
    {
        dragging = true;
        isMoving = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        isMoving = false;

    }


    void Start()
    {
        isMoving = false;
    }

    void Update()
    {
        move = transform.localPosition.x;

        //Si el usuario arrastra la barra
        if (dragging)
        {
           //Movimiento sobre eje Y, funciona mejor en computadora
           // move += Input.GetAxis("Mouse X") * .2f;
           // transform.localPosition = new Vector3(move, gameObject.transform.position.y, gameObject.transform.position.z);
            
            //Movimiento sobre eje Y, recomendado para celular
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(pos.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }


    

}
