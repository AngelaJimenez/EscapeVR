using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistajail3controller : MonoBehaviour
{
    private int[] solution = new int[4];
    public int[] rightorder = new int[4];

    public GameObject[] boxes;

    public Material right;
    public Material wrong;
    public Material selected;
    public Material normal;
    public GameObject door;
    private Animator dooranimator;

    private float initial=0f;
    private float final=0f;
    private float delta=0f;
    private bool startTimer=false;
    private int finalstate=-1;

 void Start() {
for (int i = 0; i < solution.Length; i++)
{
     solution[i]= -1;
}           
        }

   public void check(int id)
    {
        if(finalstate!=1)
        {
                bool isIn= false;
    int lastcero= -1;
    bool isfirstcero=true;
    for (int i = 0; i < solution.Length && !isIn; i++)
    {
        if(id == solution[i]) {
                isIn=true;
        }
        if(solution[i]==-1 && isfirstcero)
        {
            isfirstcero=false;
            lastcero=i;
        }
    }
    if(!isIn && !isfirstcero)
    {
        solution[lastcero]= id;
        // change material to make it shine
        boxes[id].GetComponent<Renderer>().material= selected;
    }
    if(lastcero==3)
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
                
            }
        }
        if(finalstate==0 && !startTimer )
        {
            delta =  Time.time - initial;
            if(delta>1.5f){
                // reset everything
                for (int i = 0; i < solution.Length; i++)
                {
                    solution[i]=-1;
                    boxes[i].GetComponent<Renderer>().material= normal;

                }
                finalstate=-1;
                startTimer=false;
            }
        }
    }
}
