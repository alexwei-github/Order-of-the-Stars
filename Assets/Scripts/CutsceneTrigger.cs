using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){

            Pegasus.instance.cutscene = true;
        }
    }

}
