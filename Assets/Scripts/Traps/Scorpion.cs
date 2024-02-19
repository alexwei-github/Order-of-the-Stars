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
    private Animator anim;
    public GameObject spriteanimator;


    public Transform firepoint;
    public GameObject bullet;
    




    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = spriteanimator.GetComponent<Animator>();
    }

    void Update(){
        if(dashCooldown > 0){
            dashCooldown -= Time.deltaTime;
        }
        else{
            canDash = true;
        }
        if(Vector2.Distance(player.transform.position,transform.position) < 10 && canDash){
            canDash = false;
            StartCoroutine(Lunge());
            
        }

        if (rb.velocity.x > 0) {
            transform.eulerAngles = new Vector3(0, 0, 90);
            
        } else if (rb.velocity.x < 0) {
            transform.eulerAngles = new Vector3(0, 180, 90);
            
        }   

    }

    IEnumerator Lunge(){
        dashCooldown = cooldown;
        anim.SetBool("run", true);
        rb.velocity = new Vector2(force * Mathf.Sign( transform.position.x - player.transform.position.x),0f);
        //rb.AddForce(new Vector2(force * Mathf.Sign( transform.position.x - player.transform.position.x), 0f));
        yield return new WaitForSeconds(1f);
        anim.SetBool("run", false);
        anim.SetBool("attack", true);
        Shoot();
        Debug.Log("backed off");
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("attack", false);
        

    }

    void Shoot(){
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }




}
