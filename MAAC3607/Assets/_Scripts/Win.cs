using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour{
    public GameObject flower;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Hands"){
            Debug.Log("Collected Flower!");
            Destroy(flower);
            Application.Quit();
        }
    }
}
