using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class couldronPotionsFunctionality : MonoBehaviourPun
{
    //public AudioSource audioSource;
    public GameObject puerta;
    public Vector3 aparicion;
    private Animator animator1;
    private bool estado1;

    private int[] cafe;
    private int[] chocolate;
    private int[] leche;
    private int[] azucar;
    private int[] crema;
    
    private int[] final;

    private int[] mezcla;

    private PhotonView photonview;
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
        animator1 = puerta.GetComponent<Animator>();

        mezcla = new int[]{0,0,0,0,0,0,0,0,0,0,0};
        cafe = new int[]{1,1,0,0,1,0,0,0,0,0,0};
        chocolate = new int[]{0,0,1,1,0,1,0,0,0,0,0};
        leche = new int[]{0,1,1,0,1,0,0,0,0,0,0};
        azucar = new int[]{1,0,0,0,0,1,0,0,0,0,0};
        crema = new int[]{0,0,0,0,0,0,0,0,1,1,0};
        final = new int[]{0,0,0,0,0,0,1,1,1,1,1};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonview.IsMine)
        {
            if (other.gameObject.tag == "potion")
            { 
                string pocion = other.gameObject.name;
                Debug.Log(pocion);
                dropPotion(pocion);
            }
        }
    }

    [PunRPC]
    public void dropPotion(string pocion)
    {
         if (pocion == "E")
                {
                    mezcla[0] += 1;
                }
                if (pocion == "G")
                {
                    mezcla[1] += 1;
                }
                if (pocion == "H")
                {
                    mezcla[2] += 1;
                }
                if (pocion == "J")
                {
                    mezcla[3] += 1;
                }
                if (pocion == "K")
                {
                    mezcla[4] += 1;
                }
                if (pocion == "L")
                {
                    mezcla[5] += 1;
                }

                if (pocion == "Cafe")
                {
                    mezcla[6] += 1;
                }
                if (pocion == "Chocolate")
                {
                    mezcla[7] += 1;
                }
                if (pocion == "Leche")
                {
                    mezcla[8] += 1;
                }
                if (pocion == "Azucar")
                {
                    mezcla[9] += 1;
                }
                if (pocion == "Crema")
                {
                    mezcla[10] += 1;
                }
    }

    [PunRPC]
    public void checkMix()
    {
            Debug.Log("isChecking");

            for (int i = 0; i < mezcla.Length; i++)
            {
                Debug.Log(mezcla[i]);
            }
            GameObject instance;
            if (comparar(mezcla, cafe))
            {
                //audioSource.Play();
                Debug.Log("Cafe");
                instance = PhotonNetwork.Instantiate("Cafe", aparicion, Quaternion.identity, 0);
                PhotonView pvcreated = instance.GetComponent<PhotonView>();
            pvcreated.RPC("RPC_ChangeName", RpcTarget.All, "Cafe");
            }
            if (comparar(mezcla, chocolate))
            {
                //audioSource.Play();
                Debug.Log("Chocolate");
                instance = PhotonNetwork.Instantiate("Chocolate", aparicion, Quaternion.identity, 0);
                PhotonView pvcreated = instance.GetComponent<PhotonView>();
            pvcreated.RPC("RPC_ChangeName", RpcTarget.All, "Chocolate");
            }
            if (comparar(mezcla, leche))
            {
                //audioSource.Play();
                instance = PhotonNetwork.Instantiate("Leche", aparicion, Quaternion.identity, 0);
                PhotonView pvcreated = instance.GetComponent<PhotonView>();
            pvcreated.RPC("RPC_ChangeName", RpcTarget.All, "Leche");
            }
            if (comparar(mezcla, azucar))
            {
                //audioSource.Play();
                instance = PhotonNetwork.Instantiate("Azucar", aparicion, Quaternion.identity, 0);
                PhotonView pvcreated = instance.GetComponent<PhotonView>();
            pvcreated.RPC("RPC_ChangeName", RpcTarget.All, "Azucar");
            }
            if (comparar(mezcla, crema))
            {
                //audioSource.Play();
                instance = PhotonNetwork.Instantiate("Crema", aparicion, Quaternion.identity, 0);
                PhotonView pvcreated = instance.GetComponent<PhotonView>();
            pvcreated.RPC("RPC_ChangeName", RpcTarget.All, "Crema");
            }
            if (comparar(mezcla, final))
            {
                //audioSource.Play();
                animator1.SetBool("Open", true);
            }
            mezcla = new int[]{0,0,0,0,0,0,0,0,0,0,0};
    }

    private bool comparar(int[] a1, int[] a2)
    {

      if(a1.Length!=a2.Length)
      {
        return false;
      }

      for(int i = 0;i<a1.Length;i++)
      {
        if(a1[i]!=a2[i])
        {
          return false;
        }
      }

      return true;
    }
  
    [PunRPC]
    public void resetMix()
    {
      mezcla = new int[]{0,0,0,0,0,0,0,0,0,0,0};
      Debug.Log("Se reseteo");

    }

}
