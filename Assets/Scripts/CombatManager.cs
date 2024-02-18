using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public int CurHp;
    public int MaxHp;
    public bool IsPlayer;
    public uint  ui;

    public event UnityAction OnHealthChange;
    public static event UnityAction<Character> OnDie;

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void 
}
