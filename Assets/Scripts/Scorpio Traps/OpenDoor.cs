using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Rigidbody2D door;
    public Vector2 currentPos;
    public static OpenDoor instance;

    void Awake(){
        currentPos = transform.position;

        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){   
            door.gravityScale = 3;
        }

    }
}
