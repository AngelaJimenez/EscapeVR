using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;
    public Animator rightHandAnimator;
    public Animator leftHandAnimator;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;    
    public GameObject father;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = father.gameObject.transform.Find("XROrigin").GetComponent<XROrigin>();
       
        headRig = rig.transform.Find("  Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        if(photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled=false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
         
        if(headRig== null)
        {
            XROrigin rig = FindObjectOfType<XROrigin>();
            headRig = rig.transform.Find("Camera Offset/Main Camera");
        }
        if(leftHandRig== null)
        {
            XROrigin rig = FindObjectOfType<XROrigin>();
            leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        }
        if(rightHandRig== null)
        { XROrigin rig = FindObjectOfType<XROrigin>();
            rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        }
        if(photonView.IsMine)
        {   
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
            // rightHand.gameObject.SetActive(false);
            // leftHand.gameObject.SetActive(false);
            // head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
        
    }
void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
