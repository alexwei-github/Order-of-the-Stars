using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionCombat : CombatManager

{
    private Animator anim;
    public GameObject spriteanimator;
    //public GameObject parent;

    void Awake(){
        anim = spriteanimator.GetComponent<Animator>();
    }

    
    IEnumerator Death(){
        Debug.Log("this one");
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
