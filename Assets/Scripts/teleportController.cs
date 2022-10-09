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
    private GameObject finalPath;
    private GameObject mainRoom1;
    private GameObject[] prison = new GameObject[6];
    private bool[] door_prision = new bool[6];
    // Start is called before the first frame update
    void Start()
    {
        GameObject teleport = Instantiate(tp,new Vector3(0,0,0),new Quaternion(0,0,0,0));
        Transform[] ts = teleport.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 6; i++)
        {
            door_prision[i]=false;
        }
        
         foreach (Transform t in ts) {
            Debug.Log(t.gameObject.name );
            if(t.gameObject.name== "Room2andhallway")
                {
                Room2andhallway=  t.gameObject;
                }
            if(t.gameObject.name== "finalPath")
                {
                finalPath=  t.gameObject;
                }
            if(t.gameObject.name== "mainRoom1")
                {
                mainRoom1=  t.gameObject;
                }
            if(t.gameObject.name== "prison1")
                {
                prison[0]=  t.gameObject;
                }
            if(t.gameObject.name== "prison2")
                {
                prison[1]=  t.gameObject;
                }
            if(t.gameObject.name== "prison3")
                {
                prison[2]=  t.gameObject;
                }
            if(t.gameObject.name== "prison4")
                {
                prison[3]=  t.gameObject;
                }
            if(t.gameObject.name== "prison5")
                {
                prison[4]=  t.gameObject;
                }
            if(t.gameObject.name== "prison6")
                {
                prison[5]=  t.gameObject;
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
    }
    
    private void activeCurrent()
    {
        current.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
