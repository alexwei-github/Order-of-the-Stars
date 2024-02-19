using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 10f;
    public float bulletDeathTime;
    private GameObject player;
    public int knockbackAmount;


    
    void Start(){

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        //rb.velocity = transform.right*bulletSpeed;
        rb.velocity = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x) * bulletSpeed,0);
    }

    void Update()
    {

        if(bulletDeathTime>0){
            bulletDeathTime-= Time.deltaTime;
        }else{
            Destroy(gameObject);
        }

        

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){   
            Destroy(gameObject); 
            other.gameObject.GetComponent<CombatManager>().TakeDamage(5, transform.position, knockbackAmount);

        }
        else if(other.gameObject.layer != 8){
            Destroy(gameObject);
        }

    }
}
