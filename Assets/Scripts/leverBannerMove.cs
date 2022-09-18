using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBannerMove : MonoBehaviour
{
    public GameObject colliderOut;
    private bool trigger;
    private bool finish;
    private float timer;
    private Vector3 firstPos;
    private Animator animate;
    private bool isAnimating;
    private bool onProcess;
    

    // Start is called before the first frame update
    void Start()
    {
        trigger= false;
        finish = false;
        timer=0;
        firstPos= colliderOut.transform.position;
        animate= colliderOut.GetComponent<Animator>();
        onProcess=false;
    }

    // Update is called once per frame
    void Update()
    {
        isAnimating= animate.GetBool("TurnOn");
        
        //checking forpull down first time
        if(this.transform.rotation.x>0.4f && !finish && !trigger && !onProcess)
        {
           
            trigger=true;   
        }
        //pull down first time wait for animation to play
        if(trigger && !finish && !isAnimating)
        {
        
         animate.SetBool("TurnOn",true);
            trigger = false;
            onProcess=true;
            
        }
        //finished animation, taking it back 
        if(!trigger && !finish && isAnimating &&  animate.GetCurrentAnimatorStateInfo(0).IsName("animation"))
        {
            animate.SetBool("TurnOn",false);
            finish=true;
            onProcess=false;
            
        }
        
        
        // start again if it is back to the initial angle
        if( finish && this.transform.rotation.x<0.010f)
        {
            trigger=false;   
            finish = false;
            onProcess=false;
        }

    }
    public void moveObject()
    {

        
    }
}
