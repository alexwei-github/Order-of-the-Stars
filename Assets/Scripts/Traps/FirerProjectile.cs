using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 10f;
    public float bulletDeathTime;
    public int knockbackAmount;


    
    void Start(){

        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right*bulletSpeed;
    }

    void Update()
    {

        if(bulletDeathTime>0){
            bulletDeathTime-= Time.deltaTime;
        }else{
            Destroy(gameObject);
        }

        rb.velocity = new Vector2(0,-1 *bulletSpeed);

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){  
            other.gameObject.GetComponent<CombatManager>().TakeDamage(5, transform.position, knockbackAmount); 
            Destroy(gameObject); 

        }
        else{
            Destroy(gameObject);
        }

    }
}
