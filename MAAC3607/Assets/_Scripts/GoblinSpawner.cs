using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpawner : MonoBehaviour{
    //Public Variables
    public GameObject prefabToSpawn;
    public float numberOfGoblinsToSpawn = 13f;
    private float TOTAL_GOBLINS;
    public float killedGoblins = 0f;
    public Image progressBar;
    public Text progressText;
    public float spawnTime;
    public float spawnTimeRandom;
    //Private Variables
    private float spawnTimer;
    
    //Used for initialisation
    void Start(){
        TOTAL_GOBLINS = numberOfGoblinsToSpawn;
        progressText.text ="0/" + TOTAL_GOBLINS;
        ResetSpawnTimer();
    }
    //Update is called once per frame
    void Update(){
        if(numberOfGoblinsToSpawn > 0 ){
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0.0f){
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                ResetSpawnTimer();
                numberOfGoblinsToSpawn--;
            }
        }else if(GameObject.FindGameObjectsWithTag("Goblin").Length <=0 ){
            GameObject.FindGameObjectWithTag("Flower").GetComponent<BoxCollider>().enabled = true;
            progressText.text = "You Win!";
        }
    }
    //Resets the spawn timer with a random offset
    void ResetSpawnTimer(){
        spawnTimer = (float)(spawnTime + Random.Range(0, spawnTimeRandom * 100) / 100.0);
    }
    private void UpdateKillCount(){
        progressBar.fillAmount = 1f - (killedGoblins / TOTAL_GOBLINS);
        progressText.text = killedGoblins + "/" + TOTAL_GOBLINS;
        Debug.Log("Progress: " + progressBar.fillAmount);
    }

    public void GoblinKilled(){
        killedGoblins++;
        UpdateKillCount();
    }

}
