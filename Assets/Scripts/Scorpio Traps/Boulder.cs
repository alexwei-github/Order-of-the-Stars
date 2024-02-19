using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private Vector2 currentPos;
    void Awake(){
        currentPos = transform.position;

    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Stop());
            
        }

    }

    IEnumerator Stop(){
        PlayerMovement.instance.canMove = false;

        PlayerMovement.instance.rb.transform.position = CheckPointManager.instance.checkPointPos;
        PlayerMovement.instance.rb.velocity = new Vector2(0,0);

        OpenDoor.instance.door.transform.position = OpenDoor.instance.currentPos;
        OpenDoor.instance.door.gravityScale = 0;

        transform.position = currentPos;

        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.canMove = true;
    }
}
