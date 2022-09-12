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
    
    // Start is called before the first frame update
    void Start()
    {
        isPressed= false;
        firstPositionButton=button.transform.localPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition= firstPositionButton- new Vector3(0,0.02f,0);
            presser= other.gameObject;
            onPress.Invoke();
            isPressed= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition= firstPositionButton;
            onRelease.Invoke();
            isPressed=false;
        }
    }
}
