using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialControl : MonoBehaviour
{
    private float posicion;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localRotation = new Quaternion(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        posicion = this.transform.localRotation.z;
    }
}
