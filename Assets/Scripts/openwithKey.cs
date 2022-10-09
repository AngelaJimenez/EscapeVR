using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openwithKey : MonoBehaviour
{
        public GameObject door;
        private bool isKey=false;
        private Animator animator;
        private GameObject finalpath;
 void Start() {
        animator= door.GetComponent<Animator>();

        finalpath= GameObject.Find("/TP/TeleportArea/finalPath");
}
 void OnCollisionEnter(Collision collision)
    {
       
if(collision.gameObject.CompareTag("finalDoorKey")){
isKey= true;

}
    }

 public void check() {
    
    if(isKey)
    {
        animator.SetBool("Open",true);
        finalpath.SetActive(true);
    }
}
  
}
