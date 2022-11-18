using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openwithKey : MonoBehaviour
{
        public GameObject door;
        private bool isKey=false;
        private Animator animator;
        private GameObject finalpath;
        public GameObject skeleton;
        private Animator skeletonAnimator;
 void Start() {
        animator= door.GetComponent<Animator>();
        skeletonAnimator= skeleton.GetComponent<Animator>();
        
}
 void Update() {
 if(!finalpath && GameObject.Find("TP(Clone)/TeleportArea/finalPath"))
       {
finalpath= GameObject.Find("TP(Clone)/TeleportArea/finalPath");

finalpath.SetActive(false);
       }    
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
        skeletonAnimator.SetBool("finish",true);

    }
}
  
}
