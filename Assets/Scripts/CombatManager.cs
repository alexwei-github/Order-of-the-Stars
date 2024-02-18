using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{

    public int CurHp;
    public int MaxHp;
    public bool IsPlayer;
    public uint  ui;

    public event UnityAction OnHealthChange;
    public static event UnityAction<Character> OnDie;

    public void TakeDamage (int damageToTake){
        CurHp -= damageToTake;

        OnHealthChange?.Invoke();

        if(CurHp <= 0)
            Die();
    }

    void Die(){
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


    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void 
}
