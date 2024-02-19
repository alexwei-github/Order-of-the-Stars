using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    private GameObject player;
    public float cooldown;
    private float laserTimer;
    private bool onLaser;
    public GameObject laser;

    void Awake(){
        //onLaser = cooldown;
        //sr = GetComponent<SpriteRenderer>();
        onLaser = true;
        laserTimer = cooldown;
    }

    void Update(){
        if(laserTimer > 0){
            laserTimer -= Time.deltaTime;
        }
        else{
            if(onLaser){
                laser.SetActive(false);
                onLaser = false;
            }
            else{
                laser.SetActive(true);
                onLaser = true;
            }
            laserTimer = cooldown;
        }

    }
}
