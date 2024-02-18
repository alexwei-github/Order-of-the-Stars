using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    private GameObject player;





    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }


}
