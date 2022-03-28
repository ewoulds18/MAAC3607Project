using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour{
    public int health = 30;
    // Update is called once per frame
    void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
    
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Goblin takes " + damage + " damage");
    }
}
