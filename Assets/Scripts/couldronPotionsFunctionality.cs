using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class couldronPotionsFunctionality : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

        animator1 = puerta.GetComponent<Animator>();

        mezcla = new int[]{0,0,0,0,0,0,0,0,0,0,0};
        cafe = new int[]{1,1,0,0,1,0,0,0,0,0,0};
        chocolate = new int[]{1,0,1,1,0,0,0,0,0,0,0};
        leche = new int[]{0,1,0,1,0,1,0,0,0,0,0};
        azucar = new int[]{0,0,1,0,1,0,0,0,0,0,0};
        crema = new int[]{0,0,0,0,0,0,0,0,1,1,0};
        final = new int[]{0,0,0,0,0,0,1,1,1,1,1};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag== "potion")
       {
        string pocion = other.gameObject.name;
        Debug.Log(other.gameObject.name);

        if(pocion == "E")
        {
            mezcla[0] += 1;
        }
          if(pocion == "G")
        {
            mezcla[1] += 1;
        }
          if(pocion == "H")
        {
            mezcla[2] += 1;
        }
          if(pocion == "J")
        {
            mezcla[3] += 1;
        }
          if(pocion == "K")
        {
            mezcla[4] += 1;
        }
          if(pocion == "L")
        {
            mezcla[5] += 1;
        }

        if(pocion == "Cafe")
        {
            mezcla[6] += 1;
        }
         if(pocion == "Chocolate")
        {
          mezcla[7] += 1;
        }
          if(pocion == "Leche")
        {
          mezcla[8] += 1;
        }
          if(pocion == "Azucar")
        {
          mezcla[9] += 1;
        }
          if(pocion == "Crema")
        {
          mezcla[10] += 1;
        }
         
       }
    }

    public void checkMix()
    {
      Debug.Log("isChecking");
        if(comparar(mezcla,cafe))
            {
                //audioSource.Play();
                Debug.Log("Cafe");
                PhotonNetwork.Instantiate("Cafe", aparicion, Quaternion.identity, 0);
            }
        if(comparar(mezcla,chocolate))
        {
          //audioSource.Play();
          Debug.Log("Chocolate");
          PhotonNetwork.Instantiate("Chocolate", aparicion, Quaternion.identity, 0);
        }
        if(comparar(mezcla,leche))
        {
          //audioSource.Play();
          PhotonNetwork.Instantiate("Leche", aparicion, Quaternion.identity, 0);
        }
        if(comparar(mezcla,azucar))
        {
          //audioSource.Play();
          PhotonNetwork.Instantiate("Azucar", aparicion, Quaternion.identity, 0);
        }
        if(comparar(mezcla,crema))
        {
          //audioSource.Play();
          PhotonNetwork.Instantiate("Crema", aparicion, Quaternion.identity, 0);
        }
        if(comparar(mezcla,final))
        {
          //audioSource.Play();
          estado1 = animator1.GetBool("Open");
          animator1.SetBool("Open",!estado1);
        }
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
  
    void resetMix()
    {
      mezcla = new int[]{};

    }

}
