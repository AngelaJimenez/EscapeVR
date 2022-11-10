using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEditor;
public class cauldronreset : MonoBehaviour
{
    Vector3 InitialPosition;
    Quaternion InitialRotation;
    Vector3 positionovenright= new Vector3(-23.1219997f,0.76149559f,-20.262001f);
    Vector3 positionovenleft= new Vector3(-24.8180008f,1.06000006f,-7.79500103f);
    public string name;
    private PhotonView photonview;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.transform.position;
        InitialRotation = gameObject.transform.rotation;
       if(name== null || name==""){
        name= gameObject.name;
       }
        photonview = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (photonview.IsMine)
        {
            // if it falls it has to reset
            if (gameObject.transform.position.y < -1.5f)
            {
                gameObject.transform.position = InitialPosition;
                gameObject.transform.rotation = InitialRotation;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(photonview.IsMine)
        { 
        if(other.gameObject.tag== "cauldron")
        {
            gameObject.transform.position= InitialPosition;
            gameObject.transform.rotation= InitialRotation;
        }
        if(other.gameObject.tag== "oven")
        {
           
            GameObject otherPotion;
            if(InitialPosition.z>-10f)
            {
                otherPotion= PhotonNetwork.Instantiate(name, positionovenright, Quaternion.identity, 0);

            }
            else{
               otherPotion=  PhotonNetwork.Instantiate(name, positionovenleft, Quaternion.identity, 0);
            }
            cauldronreset code = otherPotion.GetComponent<cauldronreset>();
            code.name= name;
            PhotonNetwork.Instantiate(name, InitialPosition, Quaternion.identity, 0);
            code = otherPotion.GetComponent<cauldronreset>();
            code.name= name;

            Destroy(gameObject);
        }
        if( other.gameObject.tag == "trash")
        {
            if(InitialPosition==positionovenright || InitialPosition== positionovenleft)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            else{
                gameObject.transform.position= InitialPosition;
                gameObject.transform.rotation= InitialRotation;

            }
        }

    }
    }
}
