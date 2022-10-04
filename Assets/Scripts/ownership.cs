using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
public class ownership : MonoBehaviour
{
    private PhotonView photonview;
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void askownership()
    {
          photonview.RequestOwnership();
    }
}
