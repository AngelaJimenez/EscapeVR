using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionBoxLever : MonoBehaviour
{
    public GameObject upanddown;
    private Vector3 firstAngle;
    private Animator animate;
    private bool isDown;
    private bool isTransition;
    private Quaternion angles;
    private Quaternion final;
    private float firstx;

    private float currentx;
    // Start is called before the first frame update
    void Start()
    {
        animate= upanddown.GetComponent<Animator>();
        angles = this.transform.rotation;
        final = new Quaternion(0.70680f, 0.02080f, 0.70680f, -0.02080f);
        this.transform.rotation=final;
        firstx=firstx= this.transform.rotation.x;
        isDown=false;
        isTransition=false;

    }

    // Update is called once per frame
    void Update()
    {
        currentx= this.transform.rotation.x;
        if(currentx<-0.58f){
            isDown=true;
            isTransition=true;
            animate.SetBool("isdown",isDown);
            animate.SetBool("transition",isTransition);
        }
        if(animate.GetCurrentAnimatorStateInfo(0).IsName("toUp"))
        {
            isTransition=false;
            isDown=true;

            animate.SetBool("transition",isTransition);

        }
        if(animate.GetCurrentAnimatorStateInfo(0).IsName("up") && (currentx>-0.40f )){
            isDown=false;
            isTransition=false;
            animate.SetBool("isdown",isDown);
            animate.SetBool("transition",isTransition);
        }
        if(animate.GetCurrentAnimatorStateInfo(0).IsName("toDown"))
        {
            isDown=false;
            isTransition=true;
            animate.SetBool("isdown",isDown);
            animate.SetBool("transition",isTransition);

        }


        // -0.6 Debug.Log(this.transform.rotation.x);
    }
}
