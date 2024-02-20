using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public SpriteRenderer attackSprite;
    public AudioSource swordSound;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;   
         
    }

    void Awake(){
        Input.GetMouseButtonDown(0);
        attacking = true; 
        //attacking = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            StartCoroutine(Attack());
            attackSprite.enabled = true; //reveals attack sprite
        }
        else{
            attackSprite.enabled = false;
        }

        if(attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    IEnumerator Attack(){
        swordSound.Play();
        anim.SetBool("attack", true);
        attacking = true;
        attackArea.SetActive(attacking); 
        yield return new WaitForSeconds(1f);
        anim.SetBool("attack", false);
    }
}
