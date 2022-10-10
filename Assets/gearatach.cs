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

 void Start() {

        
}

 void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collides ");
        if(collision.gameObject.CompareTag(taggear)){
        isKey= true;
       
        foundIt= collision.gameObject;
 
}
else{
     isKey= false;
}
    }

 public void check() {
    Debug.Log("checking");
    if(isKey && foundIt)
    {
        
         Rigidbody m_Rigidbody= foundIt.GetComponent< Rigidbody>();
         foundIt.transform.position= new Vector3(-13.063f,0.989f, -10.483f);
         foundIt.transform.rotation= new Quaternion(0,0,0,0);
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ |  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationX;
        keyHolder.SetActive(false);
        me.SetActive(false);
    }
}
  
}
