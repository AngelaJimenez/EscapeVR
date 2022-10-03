using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject[] puerta;
    
    

    // Start is called before the first frame update
    void Start()
    {
      this.transform.rotation = new Quaternion(-0.4f,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
