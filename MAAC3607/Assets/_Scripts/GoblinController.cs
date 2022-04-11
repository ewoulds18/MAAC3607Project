using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinController : MonoBehaviour{
    public int health = 30;
    public AudioClip[] goblinSounds;
    public NavMeshAgent navMeshAgent;
    public Transform player;
    private AudioSource audioSource;
    private bool isAlive = true;
    // Update is called once per frame
    void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
            isAlive = false;
        }
        if(isAlive){
            navMeshAgent.SetDestination(player.position);
        }
    }   
    
    //function to decrease health by damage amount
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Goblin takes " + damage + " damage");
    }
    public void playSoundOnHit(){
        GameObject sound = new GameObject();
        sound.transform.position = transform.position;
        int randomSound = Random.Range(0, goblinSounds.Length-1);
        audioSource = sound.AddComponent<AudioSource>();
        audioSource.clip = goblinSounds[randomSound];
        audioSource.Play();
        Destroy(sound, goblinSounds[randomSound].length);
    }

    public void setPlayer(Transform player){
        this.player = player;
    }
}
