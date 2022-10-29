using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potions_Buttons : MonoBehaviour
{
    public GameObject button;

    public UnityEvent onPress;
    public UnityEvent onRelease;
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
            button.transform.localPosition= firstPositionButton - new Vector3(0,0.02f,0);
            onPress.Invoke();
            isPressed= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            onRelease.Invoke();
            unpressButton();
    }

    public void unpressButton()
    {
        button.transform.localPosition = firstPositionButton;
        isPressed = false;
    }


}
