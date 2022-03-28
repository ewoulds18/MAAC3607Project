using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour{
    public int health = 30;
    public bool isFollowing = false;
    public int maxDistance = 10;
    public int minDistance = 2;
    public int speed = 5;

    // Update is called once per frame
    void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
        if(isFollowing){
            FollowPlayer();
        }
    }
    
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Goblin takes " + damage + " damage");
    }

    private void FollowPlayer(){
        //Get player position
        Transform playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playerPosition);
        if(Vector3.Distance(playerPosition.position, transform.position) > maxDistance){
            speed = 0;
        }else{
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    // Follow player using astar pathfinding
}
