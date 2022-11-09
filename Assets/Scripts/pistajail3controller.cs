using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistajail3controller : MonoBehaviour
{
    private int[] solution = new int[9];
    public int[] rightorder = new int[9];

    public GameObject[] boxes;

    public Material right;
    public Material wrong;
    public Material selected;
    public Material normal;
    public GameObject door;
    public GameObject door2;
    private Animator dooranimator;
    private Animator dooranimator2;

    private float initial=0f;
    private float final=0f;
    private float delta=0f;
    private bool startTimer=false;
    private int finalstate=-1;
    private int count=0;

 void Start() {
                for (int i = 0; i < solution.Length; i++)
                {
                    solution[i]=0;
                    boxes[i].GetComponent<Renderer>().material= normal;
                }
                dooranimator= door.GetComponent<Animator>();
                dooranimator2= door2.GetComponent<Animator>();
        }

   public void check(int id)
    {
        if(finalstate!=1)
        {
            if(solution[id]==0)
                {
                    count +=1;
                    solution[id]=1;
                    Debug.Log(id);
                boxes[id].GetComponent<Renderer>().material= selected;
                }
            if(count==3)
            {
                endingcheck();
            }
        }
    }

    private void endingcheck(){
    bool different= false;
    for (int i = 0; i < solution.Length && !different; i++)
    {
        if(!((solution[i])==rightorder[i]))
        {
            different= true;
        }
    }
startTimer=true;

    if(different)
    {
        // Wrong
finalstate=0;
    }
    else{
        // right
finalstate=1;
    }
        }

    void Update(){
        if(finalstate!=-1 && startTimer)
        {
            startTimer=false;
            if(finalstate==0)
            {
                for (int i = 0; i < boxes.Length; i++)
                {
                    boxes[i].GetComponent<Renderer>().material= wrong;
                    initial= Time.time;
                }
            }
            else{
                //usuable (finish)
                                for (int i = 0; i < solution.Length; i++)
                {
                    boxes[i].GetComponent<Renderer>().material= right;

                }
                dooranimator.SetBool("Open",true);
                dooranimator2.SetBool("Open",true);
                
            }
        }
        if(finalstate==0 && !startTimer )
        {
            delta =  Time.time - initial;
            if(delta>1.5f){
                // reset everything
                for (int i = 0; i < solution.Length; i++)
                {
                    solution[i]=0;
                    boxes[i].GetComponent<Renderer>().material= normal;

                }
                finalstate=-1;
                startTimer=false;
                count=0;
            }
        }
    }
}
