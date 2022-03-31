using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinController : MonoBehaviour{
    public int health = 30;
   
    public NavMeshAgent navMeshAgent;
    public Transform player;
    
    // Update is called once per frame
    void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
        navMeshAgent.SetDestination(player.position);
    }   
    
    //function to decrease health by damage amount
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Goblin takes " + damage + " damage");
    }
}
