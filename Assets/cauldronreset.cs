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
    Vector3 positionovenright= new Vector3(-23.4699993f,0.761495471f,-19.1900005f);
    Vector3 positionovenleft= new Vector3(-25.0480003f,0.879999995f,-8.93500042f);
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.transform.position;
        InitialRotation = gameObject.transform.rotation;
       if(name== null || name==""){
        name= gameObject.name;
       }
    }
    void Update()
    {
// if it falls it has to reset
    if(gameObject.transform.position.y< -1.5f){
            gameObject.transform.position= InitialPosition;
            gameObject.transform.rotation= InitialRotation;
    }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "cauldron")
        {
            gameObject.transform.position= InitialPosition;
            gameObject.transform.rotation= InitialRotation;
        }
        if(other.gameObject.tag== "oven")
        {
            var prefabGameObject = PrefabUtility.GetCorrespondingObjectFromSource(this.gameObject);
            GameObject otherPotion;
            if(InitialPosition.z>-10f)
            {
                otherPotion= PhotonNetwork.Instantiate(name, positionovenright, Quaternion.identity, 0);

            }
            else{
               otherPotion=  PhotonNetwork.Instantiate(name, positionovenleft, Quaternion.identity, 0);
            }
            cauldronreset code = otherPotion.GetComponent<cauldronreset>();
            code.name= this.gameObject.name;
            PhotonNetwork.Instantiate(name, InitialPosition, Quaternion.identity, 0);
            code = otherPotion.GetComponent<cauldronreset>();
            code.name= this.gameObject.name;

            Destroy(gameObject);
        }
        if( other.gameObject.tag == "trash")
        {
            if(InitialPosition==positionovenright || InitialPosition== positionovenleft)
            {
                Destroy(gameObject);
            }
            else{
                gameObject.transform.position= InitialPosition;
                gameObject.transform.rotation= InitialRotation;

            }
        }

    }
}
