using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinGameController : MonoBehaviour{
    private int goblinCount;
    // Start is called before the first frame update
    void Start(){
        //get count of all objects with Goblin tag
        goblinCount = GameObject.FindGameObjectsWithTag("Goblin").Length;
    }

    // Update is called once per frame
    void Update(){
        if(goblinCount <= 0){
            //if all goblins are dead
            Debug.Log("You win!");
            //Do other things here
            //Maybe collect flower
        }
    }
}
