using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarsY : MonoBehaviour
{

    private bool dragging;

    Vector2 initialPos;
    float move;
    
    private void OnMouseDown()
    {
        dragging = true;
    }
    
    private void OnMouseUp()
    {
        dragging = false;

    }


    void Start()
    {
        
    }

    void Update()
    {
        move = transform.localPosition.y;

        //Si el usuario arrastra la barra
        if (dragging)
        {
            //Movimiento sobre eje Y
            move += Input.GetAxis("Mouse Y") * .2f;
            transform.localPosition = new Vector3(gameObject.transform.position.x, move, gameObject.transform.position.z);

        }
    }

}
