using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class couldronPotionsFunctionality : MonoBehaviour
{

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

       
       }
    }

    void CheckMix()
    {
        for(int i = 0;i<mezcla.Length;i++)
        {
            if(mezcla==cafe|| mezcla == chocolate || mezcla == azucar || mezcla == leche)
            {
                
            }
        }
    }

}
