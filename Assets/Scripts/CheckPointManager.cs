using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    Vector2 checkPointPos;
    public CheckPointManager instance;


    private void Start(){
        checkPointPos = transform.position;
    }

    public void UpdateCheckpoint(Vector2 pos){
        checkPointPos = pos;
        Debug.Log(checkPointPos);
    }
}
