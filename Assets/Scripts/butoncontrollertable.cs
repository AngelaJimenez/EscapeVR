using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butoncontrollertable : MonoBehaviour
{
    public GameObject buttondown;
    public GameObject buttonUp;
    public GameObject buttonright;
    public GameObject buttonleft;
    
    private ButtonVR buttondownVr;
    private ButtonVR buttonUpVr;
    private ButtonVR buttonrightVr;
    private ButtonVR buttonleftVr;
    public GameObject father;
    private butoncontrollerAllTables butoncontrollerAllTables;
    public int tableId;
    // Start is called before the first frame update
    void Start()
    {
       buttondownVr=buttondown.transform.Find("collider").GetComponent<ButtonVR>();
       buttonUpVr=buttonUp.transform.Find("collider").GetComponent<ButtonVR>();
       buttonrightVr=buttonright.transform.Find("collider").GetComponent<ButtonVR>();
       buttonleftVr=buttonleft.transform.Find("collider").GetComponent<ButtonVR>();
       
        butoncontrollerAllTables= father.GetComponent<butoncontrollerAllTables>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void verifychanges(int id)
    {
        butoncontrollerAllTables.changeValue(tableId,id);
        if(id==0)
        {
            buttonUpVr.changeButton(false);
            buttonrightVr.changeButton(false);
            buttonleftVr.changeButton(false);
        }
        else if(id==1)
        {
            buttondownVr.changeButton(false);
            buttonrightVr.changeButton(false);
            buttonleftVr.changeButton(false);
        }
        else if(id==2)
        {
            buttonUpVr.changeButton(false);
            buttondownVr.changeButton(false);
            buttonleftVr.changeButton(false);
        }
        else if(id==3)
        {
            buttonUpVr.changeButton(false);
            buttonrightVr.changeButton(false);
            buttondownVr.changeButton(false);
        }

    }
}
