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
    public bool IsBoss;
    public bool canKnockback;
    public Rigidbody2D rb;
    public event UnityAction OnHealthChange;
    public static event UnityAction<CombatManager> OnDie;

    public void TakeDamage (int damageToTake, Vector3 enemyPos, int knockbackAmount){
        CurHp -= damageToTake;

        OnHealthChange?.Invoke();

        if(CurHp <= 0)
            Die();

        knockback(enemyPos,knockbackAmount);
    }

    public void Die(){
        OnDie?.Invoke(this);
        if(IsPlayer)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if(IsBoss)
            SceneManager.LoadScene(1);
        else
            StartCoroutine(Death());
            
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
            rb.velocity = new Vector2(0,0);
            rb.AddForce(new Vector2(knockbackAmount*(transform.position.x - enemyPos.x),knockbackAmount*(transform.position.y - enemyPos.y + 1)),ForceMode2D.Impulse);
            StartCoroutine(cannotMove());
        }
    }

    IEnumerator Death(){
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    IEnumerator cannotMove(){
        PlayerMovement.instance.canMove = false;
        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.canMove = true;
    }
}
