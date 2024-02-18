using System.ComponentModel;
using System.Timers;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public int CurHp;
    public int MaxHp;
    public bool IsPlayer;
    public bool canKnockback;
    public Rigidbody2D rb;
    public event UnityAction OnHealthChange;
    public static event UnityAction<CombatManager> OnDie;

    public void TakeDamage (int damageToTake, Vector3 enemyPos, int knockbackAmount){
        CurHp -= damageToTake;

        OnHealthChange?.Invoke();

        knockback(enemyPos,knockbackAmount);

        if(CurHp <= 0)
            Die();
    }

    public void Die(){
        OnDie?.Invoke(this);
        //Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void Heal (int healAmount){
        CurHp += healAmount;

        OnHealthChange?.Invoke();

        if(CurHp>MaxHp){
            CurHp = MaxHp;
        }
    }

    public float GetHealthPercentage(){
        return (float)CurHp/(float)MaxHp;
    }

    public void knockback(Vector3 enemyPos, int knockbackAmount){
        if (canKnockback){
            //Debug.Log(knockbackAmount*(transform.position - enemyPos));
            rb.AddForce(new Vector2(knockbackAmount*(transform.position.x - enemyPos.x),knockbackAmount*(transform.position.y - enemyPos.y + 1)),ForceMode2D.Impulse);
        }
    }
}
