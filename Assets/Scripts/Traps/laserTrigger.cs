using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            //other.transform.position = CheckPointManager.instance.checkPointPos;
            StartCoroutine(Stop());
        }
    }

    IEnumerator Stop(){
        PlayerMovement.instance.rb.transform.position = CheckPointManager.instance.checkPointPos;
        PlayerMovement.instance.rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1f);

    }
}
