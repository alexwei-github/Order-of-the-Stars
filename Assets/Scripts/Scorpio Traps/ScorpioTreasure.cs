using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpioTreasure : MonoBehaviour
{
    private GameObject player;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Bye());
        }
    }

    IEnumerator Bye(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
