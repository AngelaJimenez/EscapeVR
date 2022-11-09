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

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.transform.position;
        InitialRotation = gameObject.transform.rotation;
       Debug.Log(InitialPosition.z);
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
            gameObject.transform.position= InitialPosition;
            gameObject.transform.rotation= InitialRotation;
            var prefabGameObject = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);

            // instanciate other in the other oven if is  gameObject.transform.position.z>2f then it is one otherwise it is another if y<-0.2f also reset
            if(InitialPosition.z>-10f)
            {
                PhotonNetwork.Instantiate(prefabGameObject.name, positionovenright, Quaternion.identity, 0);

            }
            else{
                PhotonNetwork.Instantiate(prefabGameObject.name, positionovenleft, Quaternion.identity, 0);

            }
        }

    }
}
