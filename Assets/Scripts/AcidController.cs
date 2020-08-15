using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidController : MonoBehaviour
{

    Animator acid;

    public static bool disappear;

    // Start is called before the first frame update
    void Start()
    {
        acid = gameObject.GetComponent<Animator>();
        acid.SetBool("Disappear", false);
    }

    // Update is called once per frame
    void Update()
    {
        //El ácido solo desaparecerá con el tag Flour
        if(FlourCollider.disappear)
        {
            acid.SetBool("Disappear", true);
            disappear = true;
            Collider.acidWin = false;
        }
    }
}
