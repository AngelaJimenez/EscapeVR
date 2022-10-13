using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openwithKeyChesy : MonoBehaviour
{
        public GameObject door;
    public GameObject key;
    public GameObject keyHolder;
    public GameObject me;

    private bool isKey=false;
    private Animator animator;

     
 void Start() {
        animator= door.GetComponent<Animator>();

        
}

 void OnCollisionEnter(Collision collision)
    {
      
    if(collision.gameObject.CompareTag("keyChesGears")){
        isKey= true;

    }
 }

 public void check() {
 
    if(isKey)
    {
        animator.SetBool("Open",true);

            keyHolder.SetActive(false);
            key.SetActive(false);
            me.SetActive(false);
        }
}
  
}
