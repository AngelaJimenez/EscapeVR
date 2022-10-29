using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockverification : MonoBehaviour
{
    public GameObject[] door;
    public GameObject hours;
    public GameObject minutes;
    private float timem;
    private float timeh;
    private float deltatime;
    private bool waitinghours= false;
    private Animator anim1;
    private Animator anim2;

    private bool waitingmin= false;
    private bool perfect= false;
    private bool perfectmin= false;
    private bool perfecthours= false;
    public teleportController tpcontroller;
    // public float minM= ;
    // public float maxM= ;
    // public float minH= ;
    // public float maxH= ;
    // Start is called before the first frame update
    void Start()
    {
            anim1= door[0].GetComponent<Animator>();
            anim2= door[1].GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(minutes.transform.eulerAngles.z+" minutes");
        //  Debug.Log(hours.transform.eulerAngles.z+" hours");
         
         if(hours.transform.eulerAngles.z>325f && hours.transform.eulerAngles.z<335f &&!waitinghours )
         {
            waitinghours=true;
            timeh= Time.time;
    
            
         }else if(hours.transform.eulerAngles.z>325f && hours.transform.eulerAngles.z<335f &&waitinghours  )
         {
            deltatime =  Time.time - timeh;
            if( deltatime>1.5f )
            {
                perfecthours=true;

            }
         }
         else if(waitinghours && !(hours.transform.eulerAngles.z>325f && hours.transform.eulerAngles.z<335f))
         {
            waitinghours=false;
            
         }


         if(minutes.transform.eulerAngles.z>203f && minutes.transform.eulerAngles.z<217f && !waitingmin){

            waitingmin=true;
            timem= Time.time;
         }
         else if(minutes.transform.eulerAngles.z>203f && minutes.transform.eulerAngles.z<217f && waitingmin){
            deltatime = Time.time - timem;
            if( deltatime>1.5f)
            {
                perfectmin=true;
            }
         }
         else if( waitingmin && !(minutes.transform.eulerAngles.z>203f && minutes.transform.eulerAngles.z<217f))
         {
            waitingmin=false;
         }
        if(perfecthours && perfectmin)
        {
            anim1.SetBool("Open",true);
            anim2.SetBool("Open",true);
            tpcontroller.openRoom2();
        }

    }
}
