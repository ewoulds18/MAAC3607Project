using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    int swordDamage = 10;

    //Check if sword is hits something
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goblin"){
            Debug.Log("Hit");
            other.gameObject.GetComponent<GoblinController>().TakeDamage(swordDamage);
            other.gameObject.GetComponent<GoblinController>().playSoundOnHit();
        }else{
            Debug.Log("Miss " + other.gameObject);
        }
    }
    
}
