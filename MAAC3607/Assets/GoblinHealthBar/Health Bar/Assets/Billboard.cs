using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour{
	public Transform player;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void LateUpdate(){
		  transform.LookAt(transform.position + player.forward);
    }
}
