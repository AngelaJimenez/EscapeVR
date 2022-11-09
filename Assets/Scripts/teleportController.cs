using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class teleportController : MonoBehaviour
{
    public GameObject tp;
    public GameObject father;
    private GameObject current;
    private GameObject lastCurrent;

    private GameObject Room2andhallway;
    private GameObject finalroom;

    private GameObject mainRoom1;
    private GameObject[] prison = new GameObject[6];
    private bool[] door_prision = new bool[6];
    private bool[] new_door_prision = new bool[6];
    private Animator[] dooranimator= new  Animator[6];
    private bool needcheck=false;
    private   teleportationAreaOnChange teleporareachange;
    private TextMeshPro pista2Object;

    private string deshabilitado= "ABRE LA PUERTA";
    private string pista2= "El �ltimo invitado se fue antes de medianoche. 3 horas antes hab�an preparado la cena. El cocinero anuncio que el postre saldr�a 15 minutos despu�s del plato principal. Despu�s de una charla de 1 hora y 30 minutos, Amir y el invitado hab�an vaciado sus platos. El postre llego y Amir me envi� a buscar una botella de ron. Despues de 20 minutos regrese con la botella y media hora m�s tarde, el invitado habr�a completado su visita.";

    private void decideclues()
    {
        pista2Object.text = deshabilitado;


        if (door_prision[4])
        {
            pista2Object.text = pista2;
        }
    }

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
            if(t.gameObject.name== "Room2")
                {
                finalroom=  t.gameObject;
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
        pistajail3controller pistaskeleton = GameObject.Find("Botones").GetComponent<pistajail3controller>();;
        pistaskeleton.tpcontroller = this;
         deactivateAll();
         activeCurrent();
        pista2Object = GameObject.Find("Prison/pista2/Text").GetComponent<TextMeshPro>();
        decideclues();
    }
    private void deactivateAll()
    {
        foreach (var item in prison)
         {
            item.SetActive(false);
         }
         mainRoom1.SetActive(false);
          Room2andhallway.SetActive(false);
finalroom.SetActive(false);
    }
    private void activateAll()
    {
        foreach (var item in prison)
         {
            item.SetActive(true);
         }
         Room2andhallway.SetActive(true);
         mainRoom1.SetActive(true);
finalroom.SetActive(true);
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
        decideclues();
        needcheck =false;
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
    public void openfinalRoom()
    {
        finalroom.SetActive(true);
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
