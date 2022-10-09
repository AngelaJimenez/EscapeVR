using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class setxrOrigin : MonoBehaviour
{
    private PhotonView photonview;
    public GameObject myxrOrigin; 
    // Start is called before the first frame update
    void Start()
    {
         photonview = GetComponent<PhotonView>();
     if(photonview.IsMine)
        {
            myxrOrigin.SetActive(true);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
