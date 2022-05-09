using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor rightRayInteractor;
    public XRRayInteractor leftRayInteractor;

    public bool enableRightTeleport {get; set;} = true;
    public bool enableLeftTeleport {get; set;} = true;

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;

        if(leftTeleportRay){
            bool isLeftInteracterRayHovering = leftRayInteractor.TryGetHitInfo(out pos, out norm, out index, out validTarget);

        
            leftTeleportRay.gameObject.SetActive(!isLeftInteracterRayHovering && enableLeftTeleport && CheckIfActivated(leftTeleportRay));
        }
        if (rightTeleportRay){
            bool isRightInteracterRayHovering = rightRayInteractor.TryGetHitInfo(out pos, out norm, out index, out validTarget);
            rightTeleportRay.gameObject.SetActive(!isRightInteracterRayHovering && enableRightTeleport && CheckIfActivated(rightTeleportRay));
        }
    }

    private bool CheckIfActivated(XRController controller){
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton,out bool isActivated, activationThreshold);
        return isActivated;
    }
}
