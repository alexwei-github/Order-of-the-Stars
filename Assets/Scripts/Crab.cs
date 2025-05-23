using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public Transform player;
    private Vector3 playerPos;
    public int knockbackAmount = 20;

    public float moveSpeed = 10;
    private bool runOrShoot; //run = true, shoot = false

    float timePassed = 0f;

    public Transform firepoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        runOrShoot = true;
    }

    // Update is called once per frame
    void Update()
    { 
        //make sure crab does not go out of bounds
        if (transform.position.y >= 38){
            transform.position = new Vector2(transform.position.x, 35); 
        }

        timePassed += Time.deltaTime;
        if(timePassed > 5f)
        {
            if(runOrShoot == true){
                runOrShoot = false;
                StartCoroutine(WaitShoot());
            }
            else{
                playerPos = player.position;
                runOrShoot = true;
            }
            
            timePassed = 0f;
        } 

        if(runOrShoot==true){
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

            if(transform.position == playerPos){
                runOrShoot = false;
                StartCoroutine(WaitShoot());
                timePassed = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<CombatManager>().TakeDamage(10, transform.position, knockbackAmount);
        }
    }

    void Shoot(){
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }
    
    IEnumerator WaitShoot()
    {
        yield return new WaitForSeconds (3.0f);
        Shoot();
    }
}
