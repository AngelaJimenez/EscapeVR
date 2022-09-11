using System.Collections;
using UnityEngine;
    
public class triggerLever : MonoBehaviour
{
    private bool collides;
    private bool triggering;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        collides= false;
        triggering= false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    if(collides )
    {
        Debug.Log("IN");
        anim.SetBool("LeverUp", true);
    }   
    }
     void OnCollisionEnter(Collision collision)
    {
        Debug.Log("IN");
        collides= true;
    }
     void OnCollisionExit(Collision collision)
    {
        collides= false;
    }
void OnCollisionStay(Collision collision)
    {
        Debug.Log("IN");
    }
}
