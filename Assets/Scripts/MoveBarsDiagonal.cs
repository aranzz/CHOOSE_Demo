using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarsDiagonal : MonoBehaviour
{
    private bool dragging;

    Vector2 lastMouseCoordinate;

    public float angle;

    public float difx;
    public float dify;

    public bool mas;
    public bool menos;

    float move;

    void Start()
    {

    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;

    }

    void FixedUpdate()
    {
        move = transform.localPosition.y;

        //Si el usuario arrastra la barra
        if (dragging)
        {

            //Dos casos para mover la barra diagonal, difx y dify son coordenadas de un punto en la recta de la barra
            if (menos)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 A = new Vector2(difx, dify);

                Vector2 resultante = Quaternion.Euler(0, 0, angle) * new Vector2(pos.y, 0);

                transform.localPosition = new Vector2(resultante.x - Mathf.Abs(difx), resultante.y - Mathf.Abs(dify));
            }

            if (mas)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 A = new Vector2(difx, dify);

                Vector2 resultante = Quaternion.Euler(0, 0, angle) * new Vector2(pos.y, 0);

                transform.localPosition = new Vector2(resultante.x - Mathf.Abs(difx), resultante.y + Mathf.Abs(dify));
            }




        }

    }


}
