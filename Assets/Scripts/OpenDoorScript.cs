using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject[] puerta = new GameObject[2];
    private Animator animator1;
    private Animator animator2;
    private bool estado1;
    private bool estado2;
    private bool cambio = true;
    

    // Start is called before the first frame update
    void Start()
    {
      this.transform.rotation = new Quaternion(-0.4f,0,0,0);
      animator1 = puerta[0].GetComponent<Animator>();
      animator2 = puerta[1].GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {

      if((this.transform.rotation.x>0.4f ||this.transform.rotation.x<-0.3f) && !cambio)
      {
          estado1 = animator1.GetBool("Open");
          estado2 = animator2.GetBool("Open");
          animator1.SetBool("Open",!estado1);
          animator2.SetBool("Open",!estado2);
          cambio = true;
        
      }
      if(cambio && this.transform.rotation.x>-0.2f && this.transform.rotation.x<0.2f)
      {
        cambio = false;
        

      }

    }
}
