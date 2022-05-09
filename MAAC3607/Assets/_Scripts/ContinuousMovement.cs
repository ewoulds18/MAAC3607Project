using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour{
    public XRNode inputSource;
    public float speed = 1.0f;
    public float gravity = -9.80f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.20f;

    private float fallingSpeed;
    private XROrigin rig; 
    private Vector2 inputAxis;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start(){
        characterController = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update(){
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    void FixedUpdate(){
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction =headYaw *  new Vector3(inputAxis.x, 0, inputAxis.y);
        characterController.Move(direction * Time.fixedDeltaTime * speed);

        //gravity
        bool isGrounded = CheckIfGrounded();
        if(isGrounded){
            fallingSpeed = 0;
        }else{
            fallingSpeed += gravity * Time.fixedDeltaTime;
            characterController.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
        }
    }

    private bool CheckIfGrounded(){
        Vector3 rayStart = transform.TransformPoint(characterController.center);
        float rayLength = characterController.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, characterController.radius, Vector3.down, out RaycastHit hit, rayLength, groundLayer);
        return hasHit;
    }

    private void CapsuleFollowHeadset(){
        characterController.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        characterController.center = new Vector3(capsuleCenter.x, characterController.height/2 + characterController.skinWidth, capsuleCenter.z);
    }
}
