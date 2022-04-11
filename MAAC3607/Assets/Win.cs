using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour{
    public GameObject flower;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("Collected Flower!");
            Destroy(flower);
            Application.Quit();
        }else{
            Debug.Log(other);
        }
    }
}
