using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBannerMove : MonoBehaviour
{
    public GameObject colliderOut;
    private Animator animator1;
    private bool primera = true;

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localRotation = new Quaternion(-0.4f,0,0,0); 
        animator1 = colliderOut.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

      if(this.transform.localRotation.x>0.4&&primera)
      {
        Debug.Log("paso");
        animator1.SetBool("TurnOn",true);
        primera = false;
      }

      if(animator1.GetCurrentAnimatorStateInfo(0).IsName("animation"))
      {
            animator1.SetBool("TurnOn",false);
      }

      if(this.transform.localRotation.x<0.3)
      {
        animator1.SetBool("TurnOn",false);
        primera = true;
      }  



    }
}
