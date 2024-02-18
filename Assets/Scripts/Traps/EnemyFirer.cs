using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirer : MonoBehaviour
{
    
    public Transform firepoint;
    public GameObject bullet;
    public float fireRate;
    public float damage;
    public float cooldown;
    private float timer;

    void Start(){
        timer = cooldown;
    }
    void Update(){
        if(timer>0){
            timer -= Time.deltaTime;
        }else{
            Fire();
            timer = cooldown;
        }

    }

    void Fire(){
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }



}
