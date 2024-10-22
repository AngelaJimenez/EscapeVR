using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using Photon.Pun;
public class moveCylinder : XRGrabInteractable
{    private PhotonView photonview;
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
    }
    protected override void Awake()
    {
        base.Awake();
        CreateAttachTransform();
    }
     protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        photonview.RequestOwnership();
        base.OnSelectEntered(interactor);
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        MatchAttachPoint(args.interactorObject);
        
    }

    protected void MatchAttachPoint(IXRInteractor interactor)
    {
        if (IsFirstSelecting(interactor))
        {
            bool isDirect = interactor is XRDirectInteractor;
            
            attachTransform.position = isDirect ? interactor.GetAttachTransform(this).position : transform.position;
            attachTransform.rotation = isDirect ? interactor.GetAttachTransform(this).rotation : transform.rotation;
        }
    }

    private bool IsFirstSelecting(IXRInteractor interactor)
    {
        return interactor == firstInteractorSelecting;
    }


       private void CreateAttachTransform()
    {
        if (attachTransform == null)
        {
            GameObject createdAttachTransform = new GameObject();
            createdAttachTransform.transform.parent = this.transform;
            attachTransform = createdAttachTransform.transform;
        }
    }
}