using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawner : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        this.GetComponent<GoblinSpawner>().enabled = false;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            this.GetComponent<GoblinSpawner>().enabled = true;
        }else{
            Debug.Log("Not Player");
        }
    }
}
