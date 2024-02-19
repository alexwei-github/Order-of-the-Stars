using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Vector2 checkPointPos {get; private set;}
    public static CheckPointManager instance;


    private void Start(){
        checkPointPos = transform.position;
    }

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void UpdateCheckpoint(Vector2 pos){
        checkPointPos = pos;
        Debug.Log(checkPointPos);
    }
}
