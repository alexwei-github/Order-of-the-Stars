using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 startPosition;

    public float moveSpeed;
    private bool movingToTargetPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        movingToTargetPos = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToTargetPos==true){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if(transform.position == targetPosition){
                movingToTargetPos = false;
            }
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if(transform.position == startPosition){
                movingToTargetPos = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){

            //other.transform.position = CheckPointManager.instance.checkPointPos;
            StartCoroutine(Stop());
        }
    }

    IEnumerator Stop(){
        PlayerMovement.instance.canMove = false;
        PlayerMovement.instance.rb.transform.position = CheckPointManager.instance.checkPointPos;
        PlayerMovement.instance.rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(0.2f);
        PlayerMovement.instance.canMove = true;
    }
}
