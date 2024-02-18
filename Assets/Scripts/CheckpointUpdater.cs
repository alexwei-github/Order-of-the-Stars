using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdater : MonoBehaviour
{
    CheckPointManager instance;

    void Awake(){
        instance = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckPointManager>();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            instance.UpdateCheckpoint(transform.position);
        }
    }
}
