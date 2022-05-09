using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour{
    public bool showController = false;
    public List<GameObject> controllerPrefabs;
    public GameObject handPrefab;
    private GameObject spawnedController;
    private GameObject spawnedHand;
    private List<InputDevice> devices;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics controllerCharacteristics;
    private Animator handAnimator;
    void Start(){
        devices = new List<InputDevice>();
        TryInitialize();
    }

    void Update(){
        //try to initalize targetDevice 
        if(devices.Count < 0 || !targetDevice.isValid){
            TryInitialize();
            Debug.Log("No devices found");
        }else{ //get inputs from targetDevice once it is intialized
            if(showController){
                spawnedController.SetActive(true);
                spawnedHand.SetActive(false);

            }else{
                spawnedController.SetActive(false);
                spawnedHand.SetActive(true);
                UpdateHandAnimation();
            }
        }
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
            Debug.Log("Primary Button Pressed");
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Primary Touchpad: " + primary2DAxisValue);
        }
    }

    private void TryInitialize(){
        InputDevices.GetDevices(devices);
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if(devices.Count > 0){
            targetDevice = devices[0];
            GameObject controller = controllerPrefabs.Find(x => x.name == targetDevice.name);
            if(controller){
                spawnedController = Instantiate(controller, transform);
            }else{
                Debug.Log("No controller prefab found for device: " + targetDevice.name + " with characteristics: " + targetDevice.characteristics);
                //check if right controller 
                if(targetDevice.characteristics.HasFlag(InputDeviceCharacteristics.Right) ){ //right handed controller
                    spawnedController = Instantiate(controllerPrefabs[1], transform);
                }else{ //left handed controller
                    spawnedController = Instantiate(controllerPrefabs[0], transform);
                }
            }
            spawnedHand = Instantiate(handPrefab, transform);
            handAnimator = spawnedHand.GetComponent<Animator>();
        }
    }

    private void UpdateHandAnimation(){
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.001f){
            Debug.Log("Trigger Pressed: " + triggerValue);
            handAnimator.SetFloat("Trigger", triggerValue);
        }else{
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.001f){
            Debug.Log("Grip Pressed: " + gripValue);
            handAnimator.SetFloat("Grip", gripValue);
        }else{
            handAnimator.SetFloat("Grip", 0);
        }
    }
}
