using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    // private float startYPos;
    // private float startXPos;
    // public float bobHeight;
    // public float bobSpeed;

    // void Start(){
    //     startYPos = transform.position.y;
    //     startXPos = transform.position.x;

    // }

    // void Update(){
    //     float newY = startYPos + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);
    //     float newX = startXPos +( Mathf.Cos(Time.time * bobSpeed)* bobHeight);
    //     transform.position = new Vector3(newX, newY, 0);
        
    // }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            StartCoroutine(Stop());
        }
    }

    IEnumerator Stop(){
        PlayerMovement.instance.canMove = false;
        PlayerMovement.instance.rb.transform.position = CheckPointManager.instance.checkPointPos;
        PlayerMovement.instance.rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.canMove = true;
    }
}
