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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Attack();
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

    private void Attack(){
        swordSound.Play();
        attacking = true;
        attackArea.SetActive(attacking); 
    }
}
