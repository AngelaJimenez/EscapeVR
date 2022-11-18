using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyactivation : MonoBehaviour
{
    private Animator anim;
    private bool isOpen=false;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpen && anim.GetBool("Open"))
        {
isOpen = true;
        key.SetActive(true);
        }        
    }
}
