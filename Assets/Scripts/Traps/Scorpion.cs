using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float force;
    private bool canDash = true;
    private float dashCooldown = 0f;
    public float cooldown;


    public Transform firepoint;
    public GameObject bullet;
    




    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if(dashCooldown > 0){
            dashCooldown -= Time.deltaTime;
        }
        else{
            canDash = true;
        }
        if(Vector2.Distance(player.transform.position,transform.position)<7 && canDash){
            canDash = false;
            StartCoroutine(Lunge());
            
        }

        if (rb.velocity.x > 0) {
            transform.eulerAngles = new Vector3(0, 180, 90);
            
        } else if (rb.velocity.x < 0) {
            transform.eulerAngles = new Vector3(0, 0, 90);
            
        }   

    }

    IEnumerator Lunge(){
        dashCooldown = cooldown;
        rb.velocity = new Vector2(force * Mathf.Sign( transform.position.x - player.transform.position.x),0f);
        //rb.AddForce(new Vector2(force * Mathf.Sign( transform.position.x - player.transform.position.x), 0f));
        yield return new WaitForSeconds(1f);
        Debug.Log("backed off");
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(0.5f);
        Shoot();

    }

    void Shoot(){
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }




}
