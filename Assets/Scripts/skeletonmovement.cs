using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonmovement : MonoBehaviour
{

    public GameObject upperarmR;
    public GameObject upperarmL;
    public GameObject forearmR;
    public GameObject forearmL;
    public GameObject head;
    public GameObject LeverupperarmL;
    public GameObject LeverupperarmR;
    public GameObject LeverforearmL;
    public GameObject LeverforearmR;
    public GameObject LeverHeadR;
    public GameObject LeverHeadT;

    private Vector3 initialH;
    private Vector3 initialAL;
    private Vector3 initialAR;
    private Vector3 initialFL;
    private Vector3 initialFR;
    // Start is called before the first frame update
    void Start()
    {
        initialAL= new Vector3(upperarmL.transform.eulerAngles.x, upperarmL.transform.eulerAngles.y, upperarmL.transform.eulerAngles.z);
        initialAR= new Vector3(upperarmR.transform.eulerAngles.x, upperarmR.transform.eulerAngles.y, upperarmR.transform.eulerAngles.z);
        initialFL= new Vector3(forearmL.transform.eulerAngles.x, forearmL.transform.eulerAngles.y, forearmL.transform.eulerAngles.z);
        initialFR= new Vector3(forearmR.transform.eulerAngles.x, forearmR.transform.eulerAngles.y, forearmR.transform.eulerAngles.z);
        initialH= new Vector3(head.transform.eulerAngles.x, head.transform.eulerAngles.y, head.transform.eulerAngles.z);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAnglesAL = new Vector3(LeverupperarmL.transform.eulerAngles.x-90f, initialAL.y, initialAL.z);
        upperarmL.transform.rotation = Quaternion.Euler(eulerAnglesAL);
        
        Vector3 eulerAnglesAR = new Vector3(LeverupperarmR.transform.eulerAngles.x-90f, initialAR.y, initialAR.z);
        upperarmR.transform.rotation = Quaternion.Euler(eulerAnglesAR);

        Vector3 eulerAnglesML = new Vector3( initialFL.x,initialFL.y,LeverforearmL.transform.eulerAngles.y);
        forearmL.transform.rotation = Quaternion.Euler(eulerAnglesML);
        
        Vector3 eulerAnglesMR = new Vector3( initialFR.x,initialFR.y,LeverforearmR.transform.eulerAngles.y-180f);
        forearmR.transform.rotation = Quaternion.Euler(eulerAnglesMR);

        Vector3 eulerAnglesH = new Vector3(LeverHeadR.transform.eulerAngles.x,LeverHeadT.transform.eulerAngles.y, initialH.z);
        head.transform.rotation = Quaternion.Euler(eulerAnglesH);
    }
}
