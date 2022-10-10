using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SpinDial : MonoBehaviour
{
    public GameObject rightHand;
    public Transform rightHandParent;
    private bool usingRight = false;

    public GameObject leftHand;
    private Transform leftHandParent;
    private bool usingLeft = false;

    public Transform[] numberPositions;

    public float currentDialRotation = 0;

    public Transform directionalObject;

    private InputDevice targetDevice;

     public XRController rightController;

    public float activationthreshot = 0.1f;

    private bool activated;

    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button grip;
    

    private void Start()
    {
      
    }

    private void Update()
    {
        releaseHand();
        handRotationToDial();
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(rightController.inputDevice, grip, out bool isActivated, activationthreshot);

        activated = isActivated;

        if(other.CompareTag("PlayerHand"))
        {
            
            if(usingRight == false && activated)
            {

                placeHandOnDial( ref rightHand,  ref rightHandParent, ref usingRight);
            }
        }
    }

    private void placeHandOnDial( ref GameObject hand, ref Transform parent, ref bool agarro)
    {
        var shortestDistance = Vector3.Distance(numberPositions[0].position, hand.transform.position);
        var bestNumber = numberPositions[0];

        foreach (var number in numberPositions)
        {
            if(number.childCount==0)
            {
                var distance = Vector3.Distance(number.position, hand.transform.position);

                if(distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestNumber = number;
                }
            }
        }

      parent = hand.transform.parent;

        hand.transform.parent = bestNumber.transform ;
        hand.transform.position = bestNumber.transform.position;


        agarro = true;      

    }


    private void handRotationToDial()
    {
        if(usingRight==true &&usingLeft==false)
        {
            Quaternion newRot = Quaternion.Euler(0,0,rightHandParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            directionalObject.position = rightHand.transform.position;
            transform.parent = directionalObject;
        }
    }

    private void releaseHand()
    {
       
        if(usingRight==true&& activated == false)
        {
            
            rightHand.transform.parent = rightHandParent;
            rightHand.transform.position = rightHandParent.position;
            rightHand.transform.rotation = rightHandParent.rotation;
            usingRight = false;
        }

        if(usingRight==false && usingLeft==false )
        {
            transform.parent = null;
        }
    }



   
}
