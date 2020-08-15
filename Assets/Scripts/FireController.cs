using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public GameObject fire1;
    public GameObject fire2;

    Animator fireAnim1;
    Animator fireAnim2;

    public static bool knobOpen;
    public static bool knobClosed;

    // Start is called before the first frame update
    void Start()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
        fireAnim1 = fire1.GetComponent<Animator>();
        fireAnim2 = fire2.GetComponent<Animator>();
        fireAnim1.SetBool("Start", false);
        fireAnim2.SetBool("Start", false);
        fireAnim1.SetBool("IsOn", false);
        fireAnim2.SetBool("IsOn", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(knobOpen)
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
            fireAnim1.SetBool("Start", true);
            fireAnim2.SetBool("Start", true);
        }

        
    }
}
