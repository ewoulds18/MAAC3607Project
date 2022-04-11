using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour{
    //prefab
    public GameObject goblinPrefab;
    public Transform player;
    public int maxGoblins = 10;
    void Start(){
        
    }
    void Update(){
       if(maxGoblins >= 0){
            StartCoroutine(Spawn());
       }
    }
    
    IEnumerator Spawn(){
        int rand = Random.Range(60,120);
        maxGoblins--;
        Debug.Log("Timer started at " + rand);
        yield return new WaitForSeconds(rand);
        Instantiate(goblinPrefab, transform.position, transform.rotation);
        Debug.Log("spawned");
        //set goblin to follow player
        // find player tranform
        goblinPrefab.GetComponent<GoblinController>().setPlayer(player);
    }
}
