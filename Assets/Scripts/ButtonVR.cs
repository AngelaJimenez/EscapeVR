using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;

    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private Vector3 firstPositionButton; 
    private bool isPressed;
    private bool othersnotpressed;
    public GameObject buttoncontroller;
    private butoncontrollertable butoncontrollertable;
    public int idbutton;
    // Start is called before the first frame update
    void Start()
    {
        isPressed= false;
        firstPositionButton=button.transform.localPosition;
        butoncontrollertable = buttoncontroller.GetComponent<butoncontrollertable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(!isPressed)
        {
            butoncontrollertable.verifychanges(idbutton);
            button.transform.localPosition= firstPositionButton- new Vector3(0,0.02f,0);
            presser= other.gameObject;
            button.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            onPress.Invoke();
            isPressed= true;
        }
    }
    public void unpressButton()
    {
        button.transform.localPosition= firstPositionButton;
        button.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

        onRelease.Invoke();

    }
    public bool getButton()
    {
        return isPressed;
    }
    public void changeButton(bool change)
    {
        isPressed=change;
        if(!change)
        {
            unpressButton();
        }
    }

}
