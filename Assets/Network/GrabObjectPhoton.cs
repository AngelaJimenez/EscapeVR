using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrabObjectPhoton : MonoBehaviour
{
    private PhotonView pv;

    public void selected()
    {
        pv = GetComponent<PhotonView>();
        pv.TransferOwnership(PhotonNetwork.LocalPlayer);
    }

}
