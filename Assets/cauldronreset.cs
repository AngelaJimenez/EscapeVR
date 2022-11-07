using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cauldronreset : MonoBehaviour
{
    Vector3 InitialPosition;
    Quaternion InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.transform.position;
        InitialRotation = gameObject.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "cauldron")
        {
            gameObject.transform.position= InitialPosition;
            gameObject.transform.rotation= InitialRotation;


        }
    }
}
