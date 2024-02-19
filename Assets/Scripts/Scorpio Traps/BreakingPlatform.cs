using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{   
    public float timer;
    private SpriteRenderer sr;
    private BoxCollider2D bc;


    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Break());
        }

    }

    IEnumerator Break(){
        yield return new WaitForSeconds(timer);
        sr.gameObject.SetActive(false);
        bc.gameObject.SetActive(false);
        yield return new WaitForSeconds(timer);
        sr.gameObject.SetActive(true);
        bc.gameObject.SetActive(true);
        //Destroy(gameObject);
    }
}
