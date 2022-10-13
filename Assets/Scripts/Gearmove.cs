using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearmove : MonoBehaviour
{
        public GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointer.transform.rotation=  Quaternion.Euler(pointer.transform.rotation.x,pointer.transform.rotation.y, this.gameObject.transform.rotation.z);
    }
}
