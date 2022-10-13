using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gearatach : MonoBehaviour
{
        private bool isKey=false;
        public string taggear;
        private GameObject foundIt;
        public GameObject keyHolder;
        public GameObject me;
        public Vector3 position =  new Vector3(-13.063f,0.989f, -10.483f);
        public GameObject pointer;

 void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(taggear)){
        isKey= true;
       
        foundIt= collision.gameObject;
 
}
else{
     isKey= false;
}
    }

 public void check() {
    if(isKey && foundIt )
    {
        
         Rigidbody m_Rigidbody= foundIt.GetComponent< Rigidbody>();
         foundIt.transform.position=position;
         foundIt.transform.rotation= new Quaternion(0,0,0,0);
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ |  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationX;
        keyHolder.SetActive(false);
        me.SetActive(false);
        Gearmove script= foundIt.AddComponent<Gearmove>();
        script.pointer= pointer;
    }
}
  
}
