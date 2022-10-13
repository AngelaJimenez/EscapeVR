using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject[] puerta = new GameObject[2];
    private Animator animator1;
    private Animator animatorLocker;
    private Animator animator2;
    private bool estado1;
    private bool estado2;
    private bool cambio = true;

    // Start is called before the first frame update
    void Start()
    {
      this.transform.localRotation = new Quaternion(-0.4f,0,0,0);
      animator1 = puerta[0].GetComponent<Animator>();
      animator2 = puerta[1].GetComponent<Animator>();

      animatorLocker = GameObject.Find("lock (1)/Body").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      if((this.transform.localRotation.x>0.4f ||this.transform.localRotation.x<-0.3f) && !cambio)
      {
        if(!(puerta[0].gameObject.name=="Cell_Door_3"))
        {
          estado1 = animator1.GetBool("Open");
          animator1.SetBool("Open",!estado1);
        }
        else{
          if(animatorLocker.GetBool("Open")){
          estado1 = animator1.GetBool("Open");
          animator1.SetBool("Open",!estado1);

          }
        }
        if(!(puerta[1].gameObject.name=="Cell_Door_3"))
        {
          estado2 = animator2.GetBool("Open");
          animator2.SetBool("Open",!estado2);
        }
        else{
          if(animatorLocker.GetBool("Open")){
          estado1 = animator1.GetBool("Open");
          animator1.SetBool("Open",!estado1);

          }
          
        }
        
          cambio = true;
        
      }
      if(cambio && this.transform.localRotation.x>-0.2f && this.transform.localRotation.x<0.2f)
      {
        cambio = false;
        

      }

    }
}
