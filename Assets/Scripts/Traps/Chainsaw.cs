using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public float speed;
    public float xDist;
    public Rigidbody2D rb;

    private Vector2 targetPos;
    private Vector2 startPos;
    private Vector2 currentPos;

    void Start(){
        startPos = transform.position;
        targetPos = new Vector2(startPos.x + xDist, startPos.y);
    }

    void Update(){
        currentPos = transform.position;
        rb.velocity = new Vector2(Mathf.Sign(targetPos.x - currentPos.x) * speed, 0);
        if(currentPos == targetPos){
            targetPos = startPos;
            startPos = currentPos;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Debug.Log("get sent back to checkpoint");
        }
    }
}
