using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject floor;
    public GameObject[] enemies;

    void Update(){
        Debug.Log(enemies[0]);
        if(enemies[0] == null && enemies[1] == null|| enemies == null){
            Debug.Log("finished");
            
            Destroy(floor);
        }
    }
}
