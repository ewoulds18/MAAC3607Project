using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour{
    public int health = 30;
    public AudioClip[] goblinSounds;
    int goblinSoundTimer;

    void Start(){
        goblinSoundTimer = (int) Random.Range(1 , 2);
    }

    // Update is called once per frame
    void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
        
    }   
    
    //function to decrease health by damage amount
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Goblin takes " + damage + " damage");
    }

    //function ot play a random sound from the goblin's list of sounds
    private void PlayRandomSound(){
        int soundIndex = Random.Range(0, goblinSounds.Length);
        AudioSource.PlayClipAtPoint(goblinSounds[soundIndex], transform.position);
        Debug.Log("Goblin played sound " + soundIndex);
    }

}
