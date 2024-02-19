using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    public int knockback = 15;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<CombatManager>() != null){
            collider.GetComponent<CombatManager>().TakeDamage(damage, transform.position, knockback);
        }
    }
}
