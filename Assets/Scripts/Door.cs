using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool opened;
    Animator doorAnim;
   

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        doorAnim.SetBool("Click", false);
        opened = false;
    }

   

    private void OnMouseDown()
    {
        //'Abre' una puerta al click
      
        opened = true;
        doorAnim.SetBool("Click", true);
      
    }
}
