using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpioTreasure : MonoBehaviour
{
    private GameObject player;
    private Animator anim;


    void Awake(){
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Bye());
        }
    }

    IEnumerator Bye(){
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
