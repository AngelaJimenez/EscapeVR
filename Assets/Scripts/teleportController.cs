using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportController : MonoBehaviour
{
    public GameObject tp;
    public GameObject father;
    private GameObject current;
    private GameObject lastCurrent;

    private GameObject Room2andhallway;

    private GameObject mainRoom1;
    private GameObject[] prison = new GameObject[6];
    private bool[] door_prision = new bool[6];
    private bool[] new_door_prision = new bool[6];
    private Animator[] dooranimator= new  Animator[6];
    private bool needcheck=false;
    private   teleportationAreaOnChange teleporareachange;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject teleport = Instantiate(tp,new Vector3(0,0,0),new Quaternion(0,0,0,0));
        Transform[] ts = teleport.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 6; i++)
        {
            door_prision[i]=false;
            new_door_prision[i]=false;
        }
        
         foreach (Transform t in ts) {
           
            if(t.gameObject.name== "Room2andhallway")
                {
                Room2andhallway=  t.gameObject;
                }
           
            if(t.gameObject.name== "mainRoom1")
                {
                mainRoom1=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=6;   
                teleporareachange.tpcontroller=this;           
                }
            if(t.gameObject.name== "prison1")
                {
                prison[0]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=0;   
                teleporareachange.tpcontroller=this;           
                }
            if(t.gameObject.name== "prison2")
                {
                prison[1]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=1;   
                teleporareachange.tpcontroller=this;           

                }
            if(t.gameObject.name== "prison3")
                {
                prison[2]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=2;   
                teleporareachange.tpcontroller=this;           
               
                }
            if(t.gameObject.name== "prison4")
                {
                prison[3]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=3;   
                teleporareachange.tpcontroller=this;           
                }
            if(t.gameObject.name== "prison5")
                {
                prison[4]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=4;   
                teleporareachange.tpcontroller=this;           
                }
            if(t.gameObject.name== "prison6")
                {
                prison[5]=  t.gameObject;
                teleporareachange= t.GetComponent<teleportationAreaOnChange>();
                teleporareachange.id=5;   
                teleporareachange.tpcontroller=this;           
                }
         }
         
         if(father.tag == "firstPlayer")
         {
            current=prison[5];
            lastCurrent= prison[5];
         }
         if(father.tag == "secondPlayer")
        {
            current=prison[2];
            lastCurrent= prison[2];
         }
        dooranimator[0]= GameObject.Find("doors/Cell_Door").GetComponent<Animator>();
        dooranimator[1]= GameObject.Find("doors/Cell_Door_2").GetComponent<Animator>();
        dooranimator[2]= GameObject.Find("doors/Cell_Door_3").GetComponent<Animator>();
        dooranimator[5]= GameObject.Find("doors/Cell_Door_4").GetComponent<Animator>();
        dooranimator[4]= GameObject.Find("doors/Cell_Door_5").GetComponent<Animator>();
        dooranimator[3]= GameObject.Find("doors/Cell_Door_6").GetComponent<Animator>();
        clockverification clock = GameObject.Find("clock").GetComponent<clockverification>();;
        clock.tpcontroller = this;
         deactivateAll();
         activeCurrent();
        
   }
    private void deactivateAll()
    {
        foreach (var item in prison)
         {
            item.SetActive(false);
         }
         mainRoom1.SetActive(false);
          Room2andhallway.SetActive(false);

    }
    private void activateAll()
    {
        foreach (var item in prison)
         {
            item.SetActive(true);
         }
         Room2andhallway.SetActive(true);
         mainRoom1.SetActive(true);
    }
    private void activeCurrent()
    {
        current.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            bool current_bool = dooranimator[i].GetBool("Open");
            if(door_prision[i]!=current_bool)
            {
                new_door_prision[i]=current_bool;
                needcheck=true;
            }
        } 
        if(current!= lastCurrent)
        {
            needcheck=true;
        }
        if(needcheck)
        {
            checkingable();
        }
    }
        private void checkingable()
    {
        
        deactivateAll();
        current.SetActive(true);
        if(current.name=="mainRoom1")
        {
              checkinfrommain();
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if(current.name==prison[i].name)
                {
                   
                    if(new_door_prision[i])
                    {
                        mainRoom1.SetActive(true);
                        checkinfrommain();
                    }
                }
                door_prision[i]=new_door_prision[i];
            }
        }
        lastCurrent=current;
        needcheck=false;
    }
        private void checkinfrommain()
    {
        for (int i = 0; i < 6; i++)
        {
            prison[i].SetActive(new_door_prision[i]);
            door_prision[i]=new_door_prision[i];
        }
    }
    public void openRoom2()
    {
        Room2andhallway.SetActive(true);
    }

    public void changecurrent(int id)
    {
        if(id==6)
        {
            current=mainRoom1;
        }
        else{
            current= prison[id];
        }
    }
}
