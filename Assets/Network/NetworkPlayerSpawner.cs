using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public Vector3 firstPosition;
    public Quaternion firstRotation;
    public  Vector3 secondPosition;
    
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if(PhotonNetwork.PlayerList.Length>1)
        {
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("playertest", secondPosition, transform.rotation);
        spawnedPlayerPrefab.gameObject.tag="secondPlayer";
        }
        else
        {
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("playertest", firstPosition, firstRotation);
        spawnedPlayerPrefab.gameObject.tag="firstPlayer";
        }
        
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
