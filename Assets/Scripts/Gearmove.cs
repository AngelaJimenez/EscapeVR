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
        Vector3 eulerRotation = new Vector3(pointer.transform.eulerAngles.x, pointer.transform.eulerAngles.y, transform.eulerAngles.z);
        pointer.transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
