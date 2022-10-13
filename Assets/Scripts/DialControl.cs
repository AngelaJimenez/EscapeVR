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

    public GameObject locker;

    // Start is called before the first frame update
    void Start()
    {
        animator = body.GetComponent<Animator>();
        dial1.transform.localRotation = Quaternion.Euler(0,0,-0.3f);
        dial2.transform.localRotation = Quaternion.Euler(0,0,-0.3f);
        dial3.transform.localRotation = Quaternion.Euler(0,0,-0.3f);
        dial4.transform.localRotation = Quaternion.Euler(0,0,-0.3f);

    }

    // Update is called once per frame
    void Update()
    {
 
        if( Mathf.Abs(dial1.transform.localRotation.z) > 0.8f && Mathf.Abs(dial1.transform.localRotation.z) < 1.0f
        && Mathf.Abs(dial2.transform.localRotation.z) > 0.5f && Mathf.Abs(dial2.transform.localRotation.z) < 0.7f
        &&Mathf.Abs(dial3.transform.localRotation.z) > -0.1f && Mathf.Abs(dial3.transform.localRotation.z) < 0.1f
        && Mathf.Abs(dial4.transform.localRotation.z) > 0.2f && Mathf.Abs(dial4.transform.localRotation.z)< 0.4f     
             && cambio ==false
            )
        {
            Debug.Log("correcto");
            cambio = true;
            animator.SetBool("Open", true);
            locker.SetActive(false);
                    }
       
    }
}
