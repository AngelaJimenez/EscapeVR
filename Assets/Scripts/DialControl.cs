using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialControl : MonoBehaviour
{
    public GameObject body;
    public GameObject dial1;
    public GameObject dial2;
    public GameObject dial3;
    public GameObject dial4;

    private Animator animator;

    private bool cambio = false;

    public char[] clave = new char[4];



    // Start is called before the first frame update
    void Start()
    {
        animator = body.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(dial1.transform.localRotation.z > -0.1f && dial1.transform.localRotation.z < 0.1f
            && dial2.transform.localRotation.z > 0.2f && dial2.transform.localRotation.z < 0.4f
            && dial3.transform.localRotation.z > 0.5f && dial3.transform.localRotation.z < 0.7f
             && dial4.transform.localRotation.z > 0.8f && dial4.transform.localRotation.z < 1.0f
             && cambio ==false)
        {
            Debug.Log("correcto");
            cambio = true;
            animator.SetBool("Open", true);
            
        }
       
    }
}
