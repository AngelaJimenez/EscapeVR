using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonjail3 : MonoBehaviour
{
    public pistajail3controller controller; 
    public int id;
     void OnTriggerEnter(Collider other)
    {
        controller.check(id);
    }
}
