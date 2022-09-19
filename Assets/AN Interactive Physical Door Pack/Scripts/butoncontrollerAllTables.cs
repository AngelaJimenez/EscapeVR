using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butoncontrollerAllTables : MonoBehaviour
{
    public int[] expectedvalues;
    private int[] currentvalue;
    public GameObject chest; 
    public GameObject table1;
    public GameObject table2;
    public GameObject table3;
    public GameObject table4;
    private butoncontrollertable butoncontrollertable1;
    private butoncontrollertable butoncontrollertable2;
    private butoncontrollertable butoncontrollertable3;
    private butoncontrollertable butoncontrollertable4;
    private Animator animatorChest;

    // Start is called before the first frame update
    void Start()
    {
        butoncontrollertable1=table1.GetComponent<butoncontrollertable>();
        butoncontrollertable2=table2.GetComponent<butoncontrollertable>();
        butoncontrollertable3=table3.GetComponent<butoncontrollertable>();
        butoncontrollertable4=table4.GetComponent<butoncontrollertable>();
        currentvalue = new int[]{ 4, 4, 4, 4 };
        animatorChest = chest.GetComponent<Animator>();;
    }
    void Update()
    {
       
        
    }
    public void changeValue(int tableId, int newValue)
    {
        currentvalue[tableId]=newValue;
       
        check(); 
    }
    public void check(){
        bool good=true;
        
        for (int i = 0; i < expectedvalues.Length && good; i++)
        {
            if(!(expectedvalues[i]==currentvalue[i]))
            {
                good=false;
            }
        }
        if(good)
        {
        openchest();
        }
    }
    private void openchest()
    { 
        animatorChest.SetBool("Open", true);
    }
}
