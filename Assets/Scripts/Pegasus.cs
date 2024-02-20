using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pegasus : MonoBehaviour
{
    public static Pegasus instance;
    public bool cutscene = false; 
    private Animator anim;
    public GameObject child;
    public SpriteRenderer sr;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(cutscene){
            StartCoroutine(Cutscene());
            
        }
    }

    IEnumerator Cutscene(){
        //PlayerMovement.instance.canMove = false;
        //PlayerMovement.instance.rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(3f);
        anim.SetBool("meet", true);
        yield return new WaitForSeconds(2f);
        //PlayerMovement.instance.rb.AddForce(new Vector2(1,0));
        //PlayerMovement.instance.canMove = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1); //brings player back to overworld
        
    }
}
