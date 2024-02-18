using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    Vector2 checkPointPos;

    private void Start(){
        checkPointPos = transform.position;
    }
}
